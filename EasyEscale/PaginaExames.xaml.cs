using Org.BouncyCastle.Crypto;
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
    public partial class PaginaExames : Window
    {

        public PaginaExames(Window x)
        {
            x.Close();
            InitializeComponent();

            examesAtuais = Exame.BuscarJ();
            cbP.ItemsSource = examesAtuais;
            cbP.DisplayMemberPath = "Juncao";
            cbP.SelectedValuePath = "IdExa";
        }
        Dictionary<string, string> Nomes = new Dictionary<string, string>();
        List<string> SalasGeradas = new List<string>();
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

        List<Exame> examesAtuais = new List<Exame>();
        private void gerar(object sender, RoutedEventArgs e)
        {
            if (cbP.SelectedIndex < 0) return;

            Exame selecionado = examesAtuais[cbP.SelectedIndex];
            var resultado = metodos.GeradorEsCalasExames(selecionado);
            Nomes = resultado.Professores;
            SalasGeradas = resultado.Salas;

            DG1.ItemsSource = Nomes.Take(3);
            DG2.ItemsSource = Nomes.Skip(3).Take(2);
            DG2.Visibility = Visibility.Visible;
            DG1.Visibility = Visibility.Visible;
            quadrado.Visibility = Visibility.Visible;
            lb1.Visibility = Visibility.Visible;
            lb2.Visibility = Visibility.Visible;
            btn2.Visibility = Visibility.Visible;

            if (SalasGeradas.Count > 0)
            {
                TextSalas.Text = string.Join(", ", SalasGeradas);
                InfoSalas.Visibility = Visibility.Visible;
            }
            else
            {
                InfoSalas.Visibility = Visibility.Collapsed;
            }
        }

        private void FecharJanela_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbP.SelectedIndex < 0) return;

            Exame este = examesAtuais[cbP.SelectedIndex];

            TextDados.Text = "  Data:  " + este.Data.ToShortDateString() + " Dia da Semana: "+metodos.DiaSenana(este.Data.DayOfWeek)+ "   " + "  Hora de Inicio: " + este.HoraIni + "  Hora Final: " + este.HoraFini +"\n" + "  Diciplina: " + este.Designacao + "  Codigo: " + este.CodExa       ;

            Info1.Visibility = Visibility.Visible;
            btn1.Visibility = Visibility.Visible;
        }

        private void Guardar(object sender, RoutedEventArgs e)
        {
            if (cbP.SelectedIndex < 0) return;

            Exame selecionado = examesAtuais[cbP.SelectedIndex];
            string msgProfs = metodos.GuardaEscala(Nomes, selecionado.Idxa);

            if (SalasGeradas.Count > 0)
            {
                string msgSalas = metodos.GuardaEscalaSalas(SalasGeradas, selecionado.Idxa);
                MessageBox.Show(msgProfs + "\n" + msgSalas);
            }
            else
            {
                MessageBox.Show(msgProfs);
            }
        }
    }

}
