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
    /// Lógica interna para PaginaEscalasGuardadas.xaml
    /// </summary>
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
        Dictionary<string, string> Nomes = new Dictionary<string, string>();
        Exame este = new Exame();
        List<Exame> exames = new List<Exame>();
        private void cbP_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            if (cbE.SelectedIndex >= 0 && (lbE.Content.ToString() == "Escolha o Exame" || lbE.Content.ToString() == "Escolha a Epoca especial"))
            {
                int idexa = cbE.SelectedIndex;
                este = exames[idexa];

                if (este != null)
                {
                    Dados.Text = "  Data:  " + este.Data.ToShortDateString() + " Dia da Semana: " + metodos.DiaSenana(este.Data.DayOfWeek) + "   " + "  Hora de Inicio: " + este.HoraIni + "  Hora Final: " + este.HoraFini + "\n" + "  Diciplina: " + este.Designacao + "  Codigo: " + este.CodExa;

                    Nomes = metodos.BuscaGuardados(este.Idxa);

                    var listaProfessores = Nomes.ToList();
                    DG1.ItemsSource = listaProfessores.Take(3);
                    DG2.ItemsSource = listaProfessores.Skip(3).Take(2);
                    Info1.Visibility = Visibility.Visible;
                    lb1.Visibility = Visibility.Visible;
                    lb2.Visibility = Visibility.Visible;
                    DG1.Visibility = Visibility.Visible;
                    DG2.Visibility = Visibility.Visible;
                    st1.Visibility = Visibility.Collapsed;
                }
            }
            else if (cbE.SelectedIndex >= 0)
            {
                lb2.Visibility = Visibility.Visible;
                DG2.Visibility = Visibility.Visible;
                lb2.Content = "Professores Convocados";
            }
        }
       
        private void cbP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbP.SelectedItem is ComboBoxItem item)
            {
                string valor = item.Content.ToString();

                if (valor == "Exames")
                {

                     exames = Exame.BuscarJ();


                    cbE.ItemsSource = exames;

                    cbE.DisplayMemberPath = "Juncao";
                    cbE.SelectedValuePath = "IdExa";


                    st1.Visibility = Visibility.Visible;
                    lbE.Content = "Escolha o Exame";
                    Info1.Visibility = Visibility.Collapsed;
                   
                    lb1.Visibility = Visibility.Collapsed;
                    lb2.Visibility = Visibility.Collapsed;
                    DG1.Visibility = Visibility.Collapsed;
                    DG2.Visibility = Visibility.Collapsed;
                  
                }
                else if (valor == "Epocas Especias") 
                {
                     exames = Exame.BuscarSE();


                    cbE.ItemsSource = exames;

                    cbE.DisplayMemberPath = "Juncao";
                    cbE.SelectedValuePath = "IdExa";

                    st1.Visibility = Visibility.Visible;
                    lbE.Content = "Escolha a Epoca especial";
                    Info1.Visibility = Visibility.Collapsed;
                    
                    lb1.Visibility = Visibility.Collapsed;
                    lb2.Visibility = Visibility.Collapsed;
                    DG1.Visibility = Visibility.Collapsed;
                    DG2.Visibility = Visibility.Collapsed;
                    

                }
                else
                {
                     exames = Exame.BuscarJ();


                    cbE.ItemsSource = exames;

                    cbE.DisplayMemberPath = "Juncao";
                    cbE.SelectedValuePath = "IdExa";

                    st1.Visibility = Visibility.Visible;
                    lbE.Content = "Escolha o Reunião";
                    Info1.Visibility = Visibility.Collapsed;
                   
                    lb1.Visibility = Visibility.Collapsed;
                    lb2.Visibility = Visibility.Collapsed;
                    DG1.Visibility = Visibility.Collapsed;
                    DG2.Visibility = Visibility.Collapsed;
                    
                }
            }
        }
    }
}
