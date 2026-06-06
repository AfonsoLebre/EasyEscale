using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
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
    public partial class PaginaAddProf : Window
    {
        public PaginaAddProf(Window x)
        {
            x.Close();
            InitializeComponent();

            DataTable dis = metodos.Disciplinas();

            foreach (DataRow dr in dis.Rows)
            {
                CheckBox cb = new CheckBox
                {
                    Content = dr["Designacao"].ToString(),
                    Tag = Convert.ToInt32(dr["IdDisciplina"]),
                    Margin = new Thickness(0, 5, 0, 5),
                    FontSize = 16

                };
                Disciplinas.Children.Add(cb);

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
            else if (x.Name == "AddSala")
            {
                new PaginaAddSalas(this).Show();
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

        private void Add(object sender, RoutedEventArgs e)
        {
            string Nome = txNome.Text;
            string Email = txMail.Text;
            string pro = txtProc.Text;

            if (!Regex.IsMatch(Email, @"^[^@\s]+@esdmm\.pt$"))
            {
                MessageBox.Show("O email deve ter o formato xxxxx@esdmm.pt");
                return;
            }

            List<int> idsSelecionados = Disciplinas.Children
            .OfType<CheckBox>()
            .Where(c => c.IsChecked == true)
            .Select(c => (int)c.Tag)
            .ToList();

            MessageBox.Show(metodos.AddP(Nome, Email, pro, idsSelecionados));

        }
    }
}

