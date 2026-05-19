using MySql.Data.MySqlClient;
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
    public partial class PaginaAddTurma : Window
    {

        public PaginaAddTurma(Window x)
        {
            x.Close();
            InitializeComponent();

            string con = "server=localhost;user=root;password=root;database=easyescale";

            using (MySqlConnection conx = new MySqlConnection(con))
            {
                try
                {
                    conx.Open();
                    string queryCombo = "Select IdProfessor,Nome from professor";

                    MySqlCommand cmd = new MySqlCommand(queryCombo, conx);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CheckBox cb = new CheckBox
                        {
                            Content = reader.GetString("Nome"),
                            Tag = reader.GetInt32("idProfessor"),
                            Margin = new Thickness(0, 5, 0, 5),
                            FontSize = 16
                        };
                        Professores.Children.Add(cb);

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
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
            MainWindow a = new MainWindow();
            a.Show();
            this.Close();
        }

        private void BTNADD(object sender, RoutedEventArgs e)
        {
            List<int> idsSelecionados = Professores.Children
            .OfType<CheckBox>()
            .Where(c => c.IsChecked == true)
            .Select(c => (int)c.Tag)
            .ToList();

            int valorA = int.Parse((CBA.SelectedItem as ComboBoxItem).Content.ToString());
            string valorAL =(CBAL.SelectedItem as ComboBoxItem).Content.ToString();

            Char letra = TXL.Text[0];

         string sucesso=  metodos.AddTurmasP(valorA,letra, valorAL, idsSelecionados);

            MessageBox.Show(sucesso);
        }

    }
}
