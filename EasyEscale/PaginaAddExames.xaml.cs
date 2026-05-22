using System;
using System.Collections.Generic;
using System.Configuration;
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
    public partial class PaginaAddExames : Window
    {
        public PaginaAddExames(Window x)
        {
            x.Close();
            InitializeComponent();
        }

        bool exame = false;

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
            else if(x.Name == "Ini")
            {
                a.Show();
            }

        }
        private void mudou(object sender, SelectionChangedEventArgs e)
        {
            DataTable dtD = new DataTable();
            if (cbMuda.SelectedItem is ComboBoxItem item)
            {
                string valor = item.Content.ToString();

                if (valor == "Exame")
                {
                    exame = true;
                    dtD = metodos.Disciplinas();
                    CBD.ItemsSource = dtD.DefaultView;
                    CBD.DisplayMemberPath = "Designacao";
                    CBD.SelectedValuePath = "IdDisciplina";

                    Exa1.Visibility = Visibility.Visible;
                    Reuna.Visibility = Visibility.Collapsed;
                }
                else
                {
                    exame = false;

                    CBTurma.ItemsSource = Turma.BuscarJ();
                    CBTurma.DisplayMemberPath = "Juncao";
                    CBTurma.SelectedValuePath = "IdTurma";

                    CBSala.ItemsSource = metodos.GetSalas();

                    Exa1.Visibility = Visibility.Collapsed;
                    Reuna.Visibility = Visibility.Visible;
                }
            }
        }

        private void FecharJanela_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_ClickADD(object sender, RoutedEventArgs e)
        {
            if (DP.SelectedDate == null || CBI.SelectedIndex < 0 || CBT.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, selecione a data e as horas.");
                return;
            }

            string valorHI = (CBI.SelectedItem as ComboBoxItem).Content.ToString();
            string valorF = (CBT.SelectedItem as ComboBoxItem).Content.ToString();

            if (exame)
            {
                if (CBD.SelectedValue == null || string.IsNullOrEmpty(TxtCod.Text))
                {
                    MessageBox.Show("Por favor, preencha os dados do exame.");
                    return;
                }

                int id = (int)CBD.SelectedValue;
                int Cod = int.Parse(TxtCod.Text);
                int es = (check.IsChecked == true) ? 1 : 0;

                string sucesso = metodos.AddExame(DP.SelectedDate.Value, valorHI, valorF, id, Cod, es);
                MessageBox.Show(sucesso);
            }
            else
            {
                if (CBTurma.SelectedValue == null || string.IsNullOrEmpty(CBSala.Text))
                {
                    MessageBox.Show("Por favor, selecione a turma e a sala.");
                    return;
                }

                int idTurma = (int)CBTurma.SelectedValue;
                string sala = CBSala.Text;

                string sucesso = metodos.AddREU(DP.SelectedDate.Value, valorHI, valorF, idTurma, sala);
                MessageBox.Show(sucesso);
                
                if (sucesso.Contains("Sucesso"))
                {
                    CBSala.ItemsSource = metodos.GetSalas();
                }
            }
        }
    }
}
