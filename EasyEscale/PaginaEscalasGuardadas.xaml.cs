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

        private void cbP_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            if(lbE.Content == "Escolha o Exame" || lbE.Content == "Escolha a Epoca especial")
            { 
            Info1.Visibility = Visibility.Visible;
            Info2.Visibility = Visibility.Visible;
            lb1.Visibility = Visibility.Visible;
            lb2.Visibility = Visibility.Visible;
            DG1.Visibility = Visibility.Visible;
            DG2.Visibility = Visibility.Visible;

                st1.Visibility = Visibility.Collapsed;

            }
            else
            {
                Info3.Visibility = Visibility.Visible;
                Info4.Visibility = Visibility.Visible;
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
                    st1.Visibility = Visibility.Visible;
                    lbE.Content = "Escolha o Exame";
                    Info1.Visibility = Visibility.Collapsed;
                    Info2.Visibility = Visibility.Collapsed;
                    lb1.Visibility = Visibility.Collapsed;
                    lb2.Visibility = Visibility.Collapsed;
                    DG1.Visibility = Visibility.Collapsed;
                    DG2.Visibility = Visibility.Collapsed;
                    Info3.Visibility = Visibility.Collapsed;
                    Info4.Visibility = Visibility.Collapsed;
                }
                else if (valor == "Epocas Especias") 
                {
                    st1.Visibility = Visibility.Visible;
                    lbE.Content = "Escolha a Epoca especial";
                    Info1.Visibility = Visibility.Collapsed;
                    Info2.Visibility = Visibility.Collapsed;
                    lb1.Visibility = Visibility.Collapsed;
                    lb2.Visibility = Visibility.Collapsed;
                    DG1.Visibility = Visibility.Collapsed;
                    DG2.Visibility = Visibility.Collapsed;
                    Info3.Visibility = Visibility.Collapsed;
                    Info4.Visibility = Visibility.Collapsed;

                }
                else
                {
                    st1.Visibility = Visibility.Visible;
                    lbE.Content = "Escolha o Reunião";
                    Info1.Visibility = Visibility.Collapsed;
                    Info2.Visibility = Visibility.Collapsed;
                    lb1.Visibility = Visibility.Collapsed;
                    lb2.Visibility = Visibility.Collapsed;
                    DG1.Visibility = Visibility.Collapsed;
                    DG2.Visibility = Visibility.Collapsed;
                    Info3.Visibility = Visibility.Collapsed;
                    Info4.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
