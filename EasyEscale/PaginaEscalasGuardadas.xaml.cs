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
    public partial class PaginaEscalasGuardadas : Window
    {
        public PaginaEscalasGuardadas(Window x)
        {
            x.Close();
            InitializeComponent();
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

        Dictionary<string, string> Nomes = new Dictionary<string, string>();
        Exame esteExame = new Exame();
        Reuniao estaReuniao = new Reuniao();
        List<Exame> exames = new List<Exame>();
        List<Reuniao> reunioes = new List<Reuniao>();

        private void cbP_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            if (cbE.SelectedIndex >= 0 && cbP.SelectedItem is ComboBoxItem itemPrincipal)
            {
                string tipoSelecionado = itemPrincipal.Content.ToString();
                int index = cbE.SelectedIndex;

                if (tipoSelecionado == "Exames" || tipoSelecionado == "Epocas Especias")
                {
                    if (exames.Count > index)
                    {
                        esteExame = exames[index];
                        if (esteExame != null)
                        {
                            Dados.Text = "  Data:  " + esteExame.Data.ToShortDateString() + " | Dia: " + metodos.DiaSenana(esteExame.Data.DayOfWeek) + " | Início: " + esteExame.HoraIni + " | Fim: " + esteExame.HoraFini + "\n" + "  Disciplina: " + esteExame.Designacao + " | Código: " + esteExame.CodExa;

                            Nomes = metodos.BuscaGuardados(esteExame.Idxa);

                            var listaProfessores = Nomes.ToList();
                            DG1.ItemsSource = listaProfessores.Take(3);
                            DG2.ItemsSource = listaProfessores.Skip(3).Take(2);

                            Info1.Visibility = Visibility.Visible;
                            lb1.Visibility = Visibility.Visible;
                            lb1.Content = "Vigilantes Efetivos";
                            lb2.Visibility = Visibility.Visible;
                            DG1.Visibility = Visibility.Visible;
                            DG2.Visibility = Visibility.Visible;
                            quadrado.Visibility = Visibility.Visible;
                            st1.Visibility = Visibility.Collapsed;
                        }
                    }
                }
                else if (tipoSelecionado == "Reuniões")
                {
                    if (reunioes.Count > index)
                    {
                        estaReuniao = reunioes[index];
                        if (estaReuniao != null)
                        {
                            Dados.Text = "  Data:  " + estaReuniao.Data.ToShortDateString() + " | Dia: " + metodos.DiaSenana(estaReuniao.Data.DayOfWeek) + " | Início: " + estaReuniao.HoraIni + " | Fim: " + estaReuniao.HoraFini + "\n" + "  Turma: " + estaReuniao.Ano + estaReuniao.Letra;

                            Nomes = metodos.BuscaGuardadosReuniao(estaReuniao.IdRe);

                            var listaProfessores = Nomes.ToList();

                            DG1.ItemsSource = listaProfessores;

                            Info1.Visibility = Visibility.Visible;
                            lb1.Visibility = Visibility.Visible;
                            lb1.Content = "Professores Convocados";
                            lb2.Visibility = Visibility.Collapsed;
                            DG1.Visibility = Visibility.Visible;
                            DG2.Visibility = Visibility.Collapsed;
                            quadrado.Visibility = Visibility.Collapsed;
                            st1.Visibility = Visibility.Collapsed;
                        }
                    }
                }
            }
        }

        private void cbP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbP.SelectedItem is ComboBoxItem item)
            {
                string valor = item.Content.ToString();

                Info1.Visibility = Visibility.Collapsed;
                lb1.Visibility = Visibility.Collapsed;
                lb2.Visibility = Visibility.Collapsed;
                DG1.Visibility = Visibility.Collapsed;
                DG2.Visibility = Visibility.Collapsed;
                quadrado.Visibility = Visibility.Collapsed;

                if (valor == "Exames")
                {
                    exames = Exame.BuscarJ();
                    cbE.ItemsSource = exames;
                    cbE.DisplayMemberPath = "Juncao";
                    cbE.SelectedValuePath = "IdExa";

                    st1.Visibility = Visibility.Visible;
                    lbE.Content = "Escolha o Exame";
                }
                else if (valor == "Epocas Especias")
                {
                    exames = Exame.BuscarSE();
                    cbE.ItemsSource = exames;
                    cbE.DisplayMemberPath = "Juncao";
                    cbE.SelectedValuePath = "IdExa";

                    st1.Visibility = Visibility.Visible;
                    lbE.Content = "Escolha a Época Especial";
                }
                else if (valor == "Reuniões")
                {
                    reunioes = EasyEscale.Reuniao.Buscar();
                    cbE.ItemsSource = reunioes;
                    cbE.DisplayMemberPath = "juncao";
                    cbE.SelectedValuePath = "IdRe";

                    st1.Visibility = Visibility.Visible;
                    lbE.Content = "Escolha a Reunião";
                }
            }
        }
    }
}
