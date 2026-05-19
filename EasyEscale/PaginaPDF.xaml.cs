using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Paragraph = iTextSharp.text.Paragraph;

namespace EasyEscale
{
    public partial class PaginaPDF : Window
    {
        public PaginaPDF(Window x)
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

            if (x.Name == "Professor") { b.Show(); }
            else if (x.Name == "Horario") { c.Show(); }
            else if (x.Name == "Exames") { d.Show(); }
            else if (x.Name == "Epoca") { f.Show(); }
            else if (x.Name == "Reuniao") { g.Show(); }
            else if (x.Name == "EscalasGuarda") { h.Show(); }
            else if (x.Name == "AddProf") { i.Show(); }
            else if (x.Name == "AddTurma") { m.Show(); }
            else if (x.Name == "AddHorario") { hora.Show(); }
            else if (x.Name == "Addexames") { exa.Show(); }
            else if (x.Name == "Addreunioes") { reu.Show(); }
            else if (x.Name == "Pdf") { pdf.Show(); }
            else if (x.Name == "Graf") { graf.Show(); }
            else if (x.Name == "Ini") { a.Show(); }
        }

        private void FecharJanela_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        Dictionary<string, string> Nomes = new Dictionary<string, string>();
        Exame esteExame = new Exame();
        Reuniao estaReuniao = new Reuniao();
        List<Exame> examesAtuais = new List<Exame>();
        List<Reuniao> reunioesAtuais = new List<Reuniao>();

        private void cbP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbP.SelectedItem is ComboBoxItem item)
            {
                string valor = item.Content.ToString();

                St1.Visibility = Visibility.Collapsed;
                btnP.Visibility = Visibility.Collapsed;
                Dados.Text = "";

                if (valor == "Exames")
                {
                    examesAtuais = Exame.BuscarJ();
                    cbE.ItemsSource = examesAtuais;
                    cbE.DisplayMemberPath = "Juncao";
                    cbE.SelectedValuePath = "Idxa";
                    st1.Visibility = Visibility.Visible;
                    lbE.Content = "Escolha o Exame:";
                }
                else if (valor == "Epocas Especias")
                {
                    examesAtuais = Exame.BuscarSE();
                    cbE.ItemsSource = examesAtuais;
                    cbE.DisplayMemberPath = "Juncao";
                    cbE.SelectedValuePath = "Idxa";
                    st1.Visibility = Visibility.Visible;
                    lbE.Content = "Escolha a Época Especial:";
                }
                else if (valor == "Reuniões")
                {
                    reunioesAtuais = EasyEscale.Reuniao.Buscar();
                    cbE.ItemsSource = reunioesAtuais;
                    cbE.DisplayMemberPath = "juncao";
                    cbE.SelectedValuePath = "IdRe";
                    st1.Visibility = Visibility.Visible;
                    lbE.Content = "Escolha a Reunião:";
                }
            }
        }

        private void cbE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbE.SelectedIndex >= 0 && cbP.SelectedItem is ComboBoxItem itemPrincipal)
            {
                string tipoSelecionado = itemPrincipal.Content.ToString();
                int index = cbE.SelectedIndex;

                if (tipoSelecionado == "Exames" || tipoSelecionado == "Epocas Especias")
                {
                    if (examesAtuais.Count > index)
                    {
                        esteExame = examesAtuais[index];
                        Dados.Text = "Data: " + esteExame.Data.ToShortDateString() + " | Início: " + esteExame.HoraIni + " | Fim: " + esteExame.HoraFini + "\nDisciplina: " + esteExame.Designacao + " | Código: " + esteExame.CodExa;
                        Nomes = metodos.BuscaGuardados(esteExame.Idxa);
                        lb1.Text = "Resumo: Escala com " + Nomes.Count + " professores vinculados (Efetivos e Suplentes).";
                    }
                }
                else if (tipoSelecionado == "Reuniões")
                {
                    if (reunioesAtuais.Count > index)
                    {
                        estaReuniao = reunioesAtuais[index];
                        Dados.Text = "Data: " + estaReuniao.Data.ToShortDateString() + " | Início: " + estaReuniao.HoraIni + " | Fim: " + estaReuniao.HoraFini + "\nTurma: " + estaReuniao.Ano + estaReuniao.Letra;
                        Nomes = metodos.BuscaGuardadosReuniao(estaReuniao.IdRe);
                        lb1.Text = "Resumo: Reunião com " + Nomes.Count + " professores convocados.";
                    }
                }

                St1.Visibility = Visibility.Visible;
                btnP.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbE.SelectedIndex < 0) return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files (*.pdf)|*.pdf";
            sfd.FileName = "Relatorio_EasyEscale_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".pdf";

            if (sfd.ShowDialog() == true)
            {
                try
                {
                    string tipo = ((ComboBoxItem)cbP.SelectedItem).Content.ToString();
                    Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    var fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                    var fonteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                    var fonteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                    var fonteNegrito = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                    doc.Add(new Paragraph("EASY ESCALE - RELATÓRIO DE ESCALAS", fonteTitulo));
                    doc.Add(new Paragraph("Gerado em: " + DateTime.Now.ToString("G"), fonteNormal));
                    doc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
                  if(tipo == "Exames")
                    {
                        doc.Add(new Paragraph("\nDETALHES DO Exame", fonteSubtitulo));
                    }
                  else if(tipo == "Epocas Especias")
                    {
                        doc.Add(new Paragraph("\nDETALHES da Época Especial", fonteSubtitulo));
                    }
                  else
                    {
                        doc.Add(new Paragraph("\nDETALHES da Reunião", fonteSubtitulo));

                    }
                    {
                        doc.Add(new Paragraph("\nDETALHES DO Exame", fonteSubtitulo));
                    }
                    doc.Add(new Paragraph(Dados.Text, fonteNormal));
                    doc.Add(new Paragraph("\n"));

                    
                    var listaProfs = Nomes.ToList();

                    if (tipo == "Exames" || tipo == "Epocas Especias")
                    {
                        doc.Add(new Paragraph("VIGILANTES EFETIVOS", fonteSubtitulo));
                        PdfPTable tableEfetivos = CriarTabelaProfessores(listaProfs.Take(3).ToList(), fonteNegrito, fonteNormal);
                        doc.Add(tableEfetivos);

                        doc.Add(new Paragraph("\n"));

                        doc.Add(new Paragraph("VIGILANTES SUPLENTES", fonteSubtitulo));
                        PdfPTable tableSuplentes = CriarTabelaProfessores(listaProfs.Skip(3).Take(2).ToList(), fonteNegrito, fonteNormal);
                        doc.Add(tableSuplentes);
                    }
                    else
                    {
                        doc.Add(new Paragraph("PROFESSORES CONVOCADOS", fonteSubtitulo));
                        PdfPTable tableReu = CriarTabelaProfessores(listaProfs, fonteNegrito, fonteNormal);
                        doc.Add(tableReu);
                    }

                    doc.Add(new Paragraph("\n\nAssinatura da Direção: __________________________________________"));

                    doc.Close();
                    MessageBox.Show("Relatório PDF gerado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gerar PDF: " + ex.Message);
                }
            }
        }

        private PdfPTable CriarTabelaProfessores(List<KeyValuePair<string, string>> lista, Font fonteNegrito, Font fonteNormal)
        {
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 3f, 1f });
            table.SpacingBefore = 10f;
            table.SpacingAfter = 10f;

            PdfPCell cell1 = new PdfPCell(new Phrase("Nome do Professor", fonteNegrito));
            PdfPCell cell2 = new PdfPCell(new Phrase("Nº Processo", fonteNegrito));
            BaseColor corFundo = new BaseColor(211, 211, 211);
            cell1.BackgroundColor = corFundo;
            cell2.BackgroundColor = corFundo;

            table.AddCell(cell1);
            table.AddCell(cell2);

            foreach (var prof in lista)
            {
                table.AddCell(new Phrase(prof.Value, fonteNormal));
                table.AddCell(new Phrase(prof.Key, fonteNormal));
            }

            return table;
        }
    }
}
