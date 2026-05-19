using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EasyEscale
{
    public partial class PaginaProfs : Window
    {
        List<Professor> professores = new List<Professor>();
        public PaginaProfs(Window x)
        {
            x.Close();
            InitializeComponent();

            professores = EasyEscale.Professor.Buscar();
            cbP.ItemsSource = professores;
            cbP.DisplayMemberPath = "Nome";
            cbP.SelectedValuePath = "IdProf";

        }

        private void IR(object sender, RoutedEventArgs e)
        {

            MainWindow a = new MainWindow();
            PaginaProfs b = new PaginaProfs(this);
            PaginaHorarios c = new PaginaHorarios(this);
            PaginaExames d = new PaginaExames(this);
            PaginaEpocaE f = new PaginaEpocaE(this);
            PaginaReuniao g = new PaginaReuniao(this);
            PaginaEscalasGuardadas h = new PaginaEscalasGuardadas(this);
            PaginaAddProf i = new PaginaAddProf(this);
            PaginaAddTurma m = new PaginaAddTurma(this);
            PaginaAddHorarios hora = new(this);
            PaginaAddExames exa = new PaginaAddExames(this);
            PaginaAddReunioes reu = new PaginaAddReunioes(this);
            PaginaGRAF graf = new PaginaGRAF(this);
            PaginaPDF pdf = new PaginaPDF(this);

            MenuItem x = (MenuItem)sender;

            if (x.Name == "Professor")
            {

                b.Show();
            }
            else if (x.Name == "Horario")
            {

                c.Show();
            }
            else if (x.Name == "Exames")
            {

                d.Show();
            }
            else if (x.Name == "Epoca")
            {

                f.Show();
            }
            else if (x.Name == "Reuniao")
            {
                g.Show();
            }
            else if (x.Name == "EscalasGuarda")
            {
                h.Show();
            }
            else if (x.Name == "AddProf")
            {
                i.Show();
            }
            else if (x.Name == "AddTurma")
            {
                m.Show();
            }
            else if (x.Name == "AddHorario")
            {
                hora.Show();
            }
            else if (x.Name == "Addexames")
            {
                exa.Show();
            }
            else if (x.Name == "Addreunioes")
            {
                reu.Show();
            }
            else if (x.Name == "Pdf")
            {
                pdf.Show();
            }
            else if (x.Name == "Graf")
            {
                graf.Show();
            }
            else if (x.Name == "Ini")
            {
                a.Show();
            }

        }

        private void FecharJanela_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbP.SelectedIndex >= 0)
            {
                DetailsContainer.Visibility = Visibility.Visible;
                EmptyState.Visibility = Visibility.Collapsed;
                dgExamesProfessor.Visibility = Visibility.Collapsed;

                Professor profSelecionado = (Professor)cbP.SelectedItem;

                var estatisticas = metodos.ObterEstatisticasProfessor(profSelecionado.Idprof);

                txtAulas.Text = estatisticas.totalAulas.ToString();
                txtVigias.Text = estatisticas.totalVigilancias.ToString();
                txtDias.Text = estatisticas.diasTrabalho;

                int horasTotais = (estatisticas.totalAulas * 2) + (estatisticas.totalVigilancias * 3);
                txtHoras.Text = horasTotais + "h";
            }
        }

        private void btnVerExames_Click(object sender, RoutedEventArgs e)
        {
            if (cbP.SelectedIndex >= 0)
            {
                Professor profSelecionado = (Professor)cbP.SelectedItem;

                System.Data.DataTable examesDoProf = metodos.ObterExamesDoProfessor(profSelecionado.Idprof);

                if (examesDoProf.Rows.Count > 0)
                {
                    dgExamesProfessor.ItemsSource = examesDoProf.DefaultView;
                    dgExamesProfessor.Visibility = Visibility.Visible;
                }
                else
                {
                    dgExamesProfessor.Visibility = Visibility.Collapsed;
                    MessageBox.Show(profSelecionado.Nome + " não está convocado para nenhum exame.");
                }
            }
        }
    }
}
