using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class PaginaAddHorarios : Window
    {
        public PaginaAddHorarios(Window x)
        {
            x.Close();
            InitializeComponent();

            List<EasyEscale.Professor> profs = EasyEscale.Professor.Buscar();

            CBP.ItemsSource = profs;

            CBP.DisplayMemberPath = "Nome";
            CBP.SelectedValuePath = "Idprof";

            List<EasyEscale.Turma> turmas = EasyEscale.Turma.BuscarJ();

            CBT.ItemsSource = turmas;

            CBT.DisplayMemberPath = "Juncao";
            CBT.SelectedValuePath = "IdTurma";

            DataTable dis = metodos.Disciplinas();
            CBD.ItemsSource = dis.DefaultView;
            CBD.DisplayMemberPath = "Designacao";
            CBD.SelectedValuePath = "IdDisciplina";

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
            int Idp = (int)CBP.SelectedValue;

            string HI = (CBHI.SelectedItem as ComboBoxItem).Content.ToString();

            string Hf = (CBHF.SelectedItem as ComboBoxItem).Content.ToString();

            string semana = (CBC.SelectedItem as ComboBoxItem).Content.ToString();

            int IdD = (int)CBP.SelectedValue;

            int IdT = (int)CBT.SelectedValue;

            MessageBox.Show(metodos.AddHora(Idp, HI, Hf, semana,IdD, IdT));

        }
    }
}
