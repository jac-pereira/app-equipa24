using Equipa24_Eventos_Delegados;
using Equipa24_Eventos_Delegados.Model;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.Text;

namespace FolhetosPDF.Model
{
    internal class ExportarPDF : IPdf
    {
        private StringBuilder sbMsg = new StringBuilder();
        private static string msg;
        // local de armazenamento dos PDF
        private static string pastaPDF = Equipa24.PastaPDF;
        private static string caminho = string.Empty;

        // propriedades
        public Produto Artigo { get; set; }
        public string GrupoTrabalho { get; set; }
        public string Empresa { get; set; }

        // construtores
        public ExportarPDF(Produto artigo)
        {
            Artigo = artigo;
        }
        public ExportarPDF(Produto artigo, string grupoTrabalho, string empresa)
        {
            Artigo = artigo;
            GrupoTrabalho = grupoTrabalho;
            Empresa = empresa;
        }


        // Gera ficheiro PDF sem FOTO e texto alinhado à esquerda. 
        // É utilizado o construtor com 1 parâmetro.
        public string Exportar()
        {
            // Cria um novo documento PDF
            using (PdfDocument document = new PdfDocument())
            {
                document.Info.Title = "Produto - Equipa24";

                // Adiciona uma página
                PdfPage page = document.AddPage();
                page.Size = PdfSharp.PageSize.A4;
                page.Orientation = PdfSharp.PageOrientation.Landscape;
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Verdana", 12);

                // Escreve os dados do formulário / produto que está a ser visualizado
                int y = 40;
                gfx.DrawString("Produto: " + Artigo.CodProduto, font, XBrushes.Black, new XPoint(40, y += 20));
                gfx.DrawString("Descrição: " + Artigo.Descricao, font, XBrushes.Black, new XPoint(40, y += 20));
                gfx.DrawString("Texto complementar: " + Artigo.TextoComplementar, font, XBrushes.Black, new XPoint(40, y += 20));
                gfx.DrawString("Observações: " + Artigo.Obs, font, XBrushes.Black, new XPoint(40, y += 20));

                msg = GravarPdf(document, "");
                document.Close();
                return msg;
            }
        }


        // Gera ficheiro PDF com FOTO e texto centralizado.
        // Inclui as 2 "string" do construtor com 3 parâmetros.
        public string ExportarFoto()
        {
            //StringBuilder sb = new StringBuilder();
            sbMsg.Clear();

            // Cria um novo documento PDF
            using var doc = new PdfDocument();
            doc.Info.Title = "Produto - Equipa24";

            // Adiciona uma página
            var page = doc.AddPage();
            page.Size = PdfSharp.PageSize.A5;
            page.Orientation = PdfSharp.PageOrientation.Landscape;

            var graphics = XGraphics.FromPdfPage(page);
            var corFont = XBrushes.Black;
            var tipoFont = new XFont("Arial", 14);
            var tipoFont1 = new XFont("Arial", 10);
            var tipoFont2 = new XFont("Arial", 18);
            var tipoFont3 = new XFont("Arial", 8);

            var textFormatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);

            try
            {
                textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;

                // Escreve cabeçalho
                textFormatter.DrawString(GrupoTrabalho, tipoFont2, XBrushes.Blue, new XRect(20, 25, page.Width.Point, page.Height.Point));
                textFormatter.DrawString(Artigo.ToString(), tipoFont, XBrushes.Red, new XRect(20, 50, page.Width.Point, page.Height.Point));

                // Escreve rodapé
                textFormatter.DrawString(Empresa, tipoFont3, XBrushes.DarkOrange, new XRect(40, 400, page.Width.Point, page.Height.Point));

                // Escreve os dados do formulário / produto que está a ser visualizado
                int y = 100;
                int yIncremento = 25;
                textFormatter.DrawString(Artigo.CodProduto, tipoFont1, XBrushes.Blue, new XRect(20, y += yIncremento, page.Width.Point, page.Height.Point));
                textFormatter.DrawString(Artigo.Descricao, tipoFont1, XBrushes.Blue, new XRect(20, y += yIncremento, page.Width.Point, page.Height.Point));
                textFormatter.DrawString(Artigo.TextoComplementar, tipoFont1, XBrushes.Blue, new XRect(yIncremento, y += 20, page.Width.Point, page.Height.Point));
                textFormatter.DrawString(Artigo.Obs, tipoFont1, XBrushes.Blue, new XRect(20, y += yIncremento, page.Width.Point, page.Height.Point));

                try
                {
                    XImage imagem = XImage.FromFile(Artigo.Foto);
                    graphics.DrawImage(imagem, 20, 20, 100, 100);
                    sbMsg.AppendLine("Gerado documento \"PDF\"!");
                }
                catch
                {
                    sbMsg.AppendLine("Gerado documento \"PDF\" sem imagem!");
                }

            }
            catch
            {
                doc.Close();
                return ("Erro ao gerar \"PDF\"");
            }

            msg = GravarPdf(doc, sbMsg.ToString());
            doc.Close();
            return msg;
        }

        // Grava o ficheiro PDF e inicia processo para abrir o PDF
        private string GravarPdf(PdfDocument doc, string msg)
        {
            caminho = pastaPDF + "produto_" + Artigo.Id + ".pdf";
            sbMsg.Clear();
            sbMsg.Append(msg);

            try
            {
                // Guarda o ficheiro
                doc.Save(caminho);
                sbMsg.Append("Ficheiro \"PDF\" gravado com sucesso!");
            }
            catch
            {
                // MessageBox.Show("Erro no ficheiro de escrita " + caminho + "\n\n\t Não foi gerado ficheiro 'pdf'");
                sbMsg.Append("Erro no ficheiro de escrita ");
                sbMsg.AppendLine(caminho);
                sbMsg.Append("Não foi gravado ficheiro \"PDF\"");
                return sbMsg.ToString();
            }


            // Abre automaticamente o PDF (opcional)
            try
            {
                Process.Start("explorer", caminho);
                sbMsg.Append(" A visualizar o ficheiro \"PDF\"");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro no ficheiro de leitura " + caminho + "\n\n" + ex.ToString());
                sbMsg.AppendLine();
                sbMsg.AppendLine(ex.ToString());
                sbMsg.AppendLine();
                sbMsg.AppendLine("A visualizar o ficheiro \"PDF\"");
                sbMsg.AppendLine("Erro no ficheiro de leitura ");
                sbMsg.Append(caminho);
            }

            return sbMsg.ToString();
        }
    }
}


