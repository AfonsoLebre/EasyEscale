using System;
using System.Windows;
using System.Windows.Controls;

namespace EasyEscale
{
    public partial class PaginaAddSalas : Window
    {
        public PaginaAddSalas(Window x)
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
            PaginaAddSalas sala = new PaginaAddSalas(this);

            MenuItem x = (MenuItem)sender;

            if (x.Name == "Ini")
            {
                a.Show();
            }
            else if (x.Name == "Professor")
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
            else if (x.Name == "AddSala")
            {
                sala.Show();
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
            string nome = txNome.Text.Trim();
            string tamanhoStr = txTamanho.Text.Trim();

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Por favor, insira o nome da sala.");
                return;
            }

            if (!int.TryParse(tamanhoStr, out int tamanho) || tamanho <= 0)
            {
                MessageBox.Show("Por favor, insira uma capacidade válida.");
                return;
            }

            MessageBox.Show(metodos.AddSala(nome, tamanho));
        }
    }
}
