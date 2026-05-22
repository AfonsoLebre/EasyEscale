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
    public partial class PaginaAddReunioes : Window
    {
        public PaginaAddReunioes(Window x)
        {
            x.Close();
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
            CBTurma.ItemsSource = Turma.BuscarJ();
            CBTurma.DisplayMemberPath = "Juncao";
            CBTurma.SelectedValuePath = "IdTurma";

            CBSala.ItemsSource = metodos.GetSalas();
        }

        private void FecharJanela_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_ClickADD(object sender, RoutedEventArgs e)
        {
            if (DP.SelectedDate == null || CBI.SelectedIndex < 0 || CBT.SelectedIndex < 0 || CBTurma.SelectedIndex < 0 || string.IsNullOrEmpty(CBSala.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            DateTime data = DP.SelectedDate.Value;
            string horaIni = (CBI.SelectedItem as ComboBoxItem).Content.ToString();
            string horaFini = (CBT.SelectedItem as ComboBoxItem).Content.ToString();
            int idTurma = (int)CBTurma.SelectedValue;
            string sala = CBSala.Text;

            string resultado = metodos.AddREU(data, horaIni, horaFini, idTurma, sala);
            MessageBox.Show(resultado);

            if (resultado.Contains("Sucesso"))
            {
                CBSala.ItemsSource = metodos.GetSalas(); // Atualizar lista de salas
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
    }
}
