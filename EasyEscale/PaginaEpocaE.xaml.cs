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
    /// <summary>
    /// Lógica interna para PaginaEpocaE.xaml
    /// </summary>
    public partial class PaginaEpocaE : Window
    {
        public PaginaEpocaE(Window x)
        {
            x.Close();
            InitializeComponent();


            List<Exame> exames = Exame.BuscarSE();

            cbP.ItemsSource = exames;

            cbP.DisplayMemberPath = "Juncao";
            cbP.SelectedValuePath = "IdExa";
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
        Dictionary<int, string> Nomes = new Dictionary<int, string>();
        List<Exame> exames = new List<Exame>();
        private void gerar(object sender, RoutedEventArgs e)
        {
            exames = Exame.Buscar();

            int idexa = cbP.SelectedIndex;

            Nomes = metodos.GeradorEsCalasExames(exames[idexa]);





            DG1.ItemsSource = Nomes.Take(3);
            DG2.ItemsSource = Nomes.Skip(3).Take(2);
            DG2.Visibility = Visibility.Visible;
            DG1.Visibility = Visibility.Visible;
            quadrado.Visibility = Visibility.Visible;
            lb1.Visibility = Visibility.Visible;
            lb2.Visibility = Visibility.Visible;
            btn2.Visibility = Visibility.Visible;
        }

        private void cbP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            exames = Exame.Buscar();

            int idexa = cbP.SelectedIndex;

            Exame este = exames[idexa];

            TextDados.Text = "  Data:  " + este.Data.ToShortDateString() + "Dia da Semana: " + metodos.DiaSenana(este.Data.DayOfWeek) + "   " + "  Hora de Inicio: " + este.HoraIni + "  Hora Final: " + este.HoraFini + "\n" + "  Diciplina: " + este.Designacao + "  Codigo: " + este.CodExa;



            Info1.Visibility = Visibility.Visible;

            btn1.Visibility = Visibility.Visible;
        }

        private void Guardar(object sender, RoutedEventArgs e)
        {
            exames = Exame.Buscar();

            int idexa = cbP.SelectedIndex;

            MessageBox.Show(metodos.GuardaEscala(Nomes, exames[idexa].Idxa));


        }
    }
}
