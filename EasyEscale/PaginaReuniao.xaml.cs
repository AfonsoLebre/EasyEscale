using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Ocsp;
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
    /// Lógica interna para PaginaReuniao.xaml
    /// </summary>
    public partial class PaginaReuniao : Window
    {
        Dictionary<int, string> Nomes = new Dictionary<int, string>();
        List<Reuniao> Reu = EasyEscale.Reuniao.Buscar();
        public PaginaReuniao(Window x)
        {
            x.Close();
            InitializeComponent();
          



            cbP.ItemsSource = Reu;

            cbP.DisplayMemberPath = "juncao";
            cbP.SelectedValuePath = "IdRe";
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
        private void gerar(object sender, RoutedEventArgs e)
        {

            int idReuniao = cbP.SelectedIndex;
            Reuniao este = Reu[idReuniao];
            Nomes = metodos.GeradorEscalasReunioes(este);

            List<KeyValuePair<int, string>> listaProfessores = Nomes.ToList();

            MessageBox.Show("Professores encontrados para esta turma: " + Nomes.Count);
            DG1.ItemsSource = listaProfessores;

            DG1.Visibility = Visibility.Visible;
            
            lb1.Visibility = Visibility.Visible;
           
        }

        private void cbP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Reu = EasyEscale.Reuniao.Buscar();
            int idReuniao = cbP.SelectedIndex;
            Reuniao este = Reu[idReuniao];

            txt.Text = "  Data:  " + este.Data.ToShortDateString() + " Dia da Semana: " + metodos.DiaSenana(este.Data.DayOfWeek) + "   " + "  Hora de Inicio: " + este.HoraIni + "  Hora Final: " + este.HoraFini + "\n" + "  turma: " + este.Ano + este.Letra;


          

            btn1.Visibility = Visibility.Visible;
            Info1 .Visibility = Visibility.Visible;
            Info2.Visibility = Visibility.Visible;



        }
        
    }
    
}
