using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Windows.Media;

namespace EasyEscale
{
    public partial class PaginaGRAF : Window
    {
        public PaginaGRAF(Window x)
        {
            if (x != null) x.Close();
            InitializeComponent();
            
            // Força o carregamento das DLLs para a memória
            try {
                Assembly.Load("LiveChartsCore");
                Assembly.Load("LiveChartsCore.SkiaSharpView");
                Assembly.Load("LiveChartsCore.SkiaSharpView.WPF");
            } catch { /* Ignora se já estiverem carregadas */ }
        }

        private void IR(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if (item.Name == "Ini") new MainWindow().Show();
            else if (item.Name == "Professor") new PaginaProfs(this).Show();
            else if (item.Name == "Horario") new PaginaHorarios(this).Show();
            else if (item.Name == "Exames") new PaginaExames(this).Show();
            else if (item.Name == "Epoca") new PaginaEpocaE(this).Show();
            else if (item.Name == "Reuniao") new PaginaReuniao(this).Show();
            else if (item.Name == "EscalasGuarda") new PaginaEscalasGuardadas(this).Show();
            else if (item.Name == "AddProf") new PaginaAddProf(this).Show();
            else if (item.Name == "AddTurma") new PaginaAddTurma(this).Show();
            else if (item.Name == "AddHorario") new PaginaAddHorarios(this).Show();
            else if (item.Name == "Addexames") new PaginaAddExames(this).Show();
            else if (item.Name == "Pdf") new PaginaPDF(this).Show();
            else if (item.Name == "Graf") new PaginaGRAF(this).Show();
            else if (item.Name == "AddSala") new PaginaAddSalas(this).Show();
        }

        private void FecharJanela_Click(object sender, RoutedEventArgs e) => this.Close();
        private void ClearCharts(object sender, RoutedEventArgs e) => ChartsGrid.Children.Clear();

        private void AddVigiasChart(object sender, RoutedEventArgs e)
        {
            var data = FetchData("SELECT p.Nome, COUNT(v.IdProfessor) as Total FROM professor p LEFT JOIN vigiasexames v ON p.IdProfessor = v.IdProfessor GROUP BY p.IdProfessor, p.Nome");
            if (data.values.Count > 0) CreateCartesianChart("Vigilâncias por Professor", data.labels, data.values, "Vigilâncias");
            else MessageBox.Show("Sem dados para exibir.");
        }

        private void AddAulasChart(object sender, RoutedEventArgs e)
        {
            var data = FetchData("SELECT p.Nome, COUNT(a.IdAula) as Total FROM professor p LEFT JOIN aulas a ON p.IdProfessor = a.IdProfessor GROUP BY p.IdProfessor, p.Nome");
            if (data.values.Count > 0) CreateCartesianChart("Aulas por Professor", data.labels, data.values, "Aulas");
            else MessageBox.Show("Sem dados para exibir.");
        }

        private void AddPieChart(object sender, RoutedEventArgs e)
        {
            var data = FetchData("SELECT p.Nome, COUNT(v.IdProfessor) as Total FROM professor p INNER JOIN vigiasexames v ON p.IdProfessor = v.IdProfessor GROUP BY p.IdProfessor, p.Nome");
            if (data.values.Count > 0) CreatePieChart("Distribuição de Vigilâncias", data.labels, data.values);
            else MessageBox.Show("Sem dados para exibir.");
        }

        private (List<string> labels, List<double> values) FetchData(string query)
        {
            var labels = new List<string>();
            var values = new List<double>();
            
            using (MySqlConnection con = Conexao.Nova())
            {
                try {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    using (MySqlDataReader r = cmd.ExecuteReader()) {
                        while (r.Read()) {
                            labels.Add(r[0]?.ToString() ?? "N/A");
                            values.Add(Convert.ToDouble(r[1]));
                        }
                    }
                } catch (Exception ex) { MessageBox.Show("Erro BD: " + ex.Message); }
            }
            return (labels, values);
        }

        private void CreateCartesianChart(string title, List<string> labels, List<double> values, string seriesName)
        {
            try {
                var container = CreateChartContainer(title);
                var chartType = Type.GetType("LiveChartsCore.SkiaSharpView.WPF.CartesianChart, LiveChartsCore.SkiaSharpView.WPF") ?? throw new Exception("DLL SkiaSharpView.WPF não encontrada.");
                var columnSeriesType = Type.GetType("LiveChartsCore.SkiaSharpView.ColumnSeries`1, LiveChartsCore.SkiaSharpView") ?? throw new Exception("DLL SkiaSharpView não encontrada.");
                var axisType = Type.GetType("LiveChartsCore.SkiaSharpView.Axis, LiveChartsCore.SkiaSharpView")!;
                var iSeriesType = Type.GetType("LiveChartsCore.ISeries, LiveChartsCore")!;

                dynamic chart = Activator.CreateInstance(chartType)!;
                chart.Height = 300; // Define tamanho explícito para forçar renderização

                dynamic serie = Activator.CreateInstance(columnSeriesType.MakeGenericType(typeof(double)))!;
                serie.Values = values;
                serie.Name = seriesName;

                dynamic axis = Activator.CreateInstance(axisType)!;
                axis.Labels = labels;

                var seriesList = Activator.CreateInstance(typeof(List<>).MakeGenericType(iSeriesType))!;
                seriesList.GetType().GetMethod("Add")!.Invoke(seriesList, new[] { (object)serie });

                var axesList = Activator.CreateInstance(typeof(List<>).MakeGenericType(axisType))!;
                axesList.GetType().GetMethod("Add")!.Invoke(axesList, new[] { (object)axis });

                chart.GetType().GetProperty("Series")!.SetValue(chart, seriesList);
                chart.GetType().GetProperty("XAxes")!.SetValue(chart, axesList);

                container.Children.Add((UIElement)chart);
                ChartsGrid.Children.Add(container);
            } catch (Exception ex) { MessageBox.Show("Erro Gráfico: " + ex.Message); }
        }

        private void CreatePieChart(string title, List<string> labels, List<double> values)
        {
            try {
                var container = CreateChartContainer(title);
                var chartType = Type.GetType("LiveChartsCore.SkiaSharpView.WPF.PieChart, LiveChartsCore.SkiaSharpView.WPF")!;
                var pieSeriesType = Type.GetType("LiveChartsCore.SkiaSharpView.PieSeries`1, LiveChartsCore.SkiaSharpView")!;
                var iSeriesType = Type.GetType("LiveChartsCore.ISeries, LiveChartsCore")!;

                dynamic chart = Activator.CreateInstance(chartType)!;
                chart.Height = 300;

                var seriesList = Activator.CreateInstance(typeof(List<>).MakeGenericType(iSeriesType))!;

                for (int i = 0; i < labels.Count; i++) {
                    dynamic serie = Activator.CreateInstance(pieSeriesType.MakeGenericType(typeof(double)))!;
                    serie.Values = new List<double> { values[i] };
                    serie.Name = labels[i];
                    seriesList.GetType().GetMethod("Add")!.Invoke(seriesList, new[] { (object)serie });
                }

                chart.GetType().GetProperty("Series")!.SetValue(chart, seriesList);
                container.Children.Add((UIElement)chart);
                ChartsGrid.Children.Add(container);
            } catch (Exception ex) { MessageBox.Show("Erro Pie: " + ex.Message); }
        }

        private Grid CreateChartContainer(string title)
        {
            var grid = new Grid { Margin = new Thickness(10), MinHeight = 350, Background = new SolidColorBrush(Color.FromRgb(250, 251, 252)) };
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            var txt = new TextBlock { Text = title, HorizontalAlignment = HorizontalAlignment.Center, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 5, 0, 10), FontSize = 16, Foreground = new SolidColorBrush(Color.FromRgb(45, 52, 54)) };
            Grid.SetRow(txt, 0);
            grid.Children.Add(txt);
            return grid;
        }
    }
}
