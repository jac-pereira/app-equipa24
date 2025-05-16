using Equipa24_Eventos_Delegados;
using Equipa24_Eventos_Delegados.Model;
using Equipa24_Eventos_Delegados.View;
using Equipa24_Eventos_Delegados.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;


namespace FolhetosPDF
{
    internal class ExportarPDF
    {
        // local de armazenamento das imagens
        private static string pastaPDF = Equipa24.PastaPDF;
        private static string caminho = string.Empty;

        public Produto Artigo { get; set; }
        public string GrupoTrabalho { get; set; }
        public string Empresa { get; set; }

        // construtores
        public ExportarPDF()
        {
            Artigo = null;
            GrupoTrabalho = string.Empty;
            Empresa = string.Empty;
        }
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

        public string Exportar()
        {
            // Cria um novo documento PDF
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Produto - Equipa24";

            // Adiciona uma página
            PdfPage page = document.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            page.Orientation = PdfSharp.PageOrientation.Landscape;
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 12);

            // Escreve os dados do formulário / produto a ser visualizado
            int y = 40;
            gfx.DrawString("Produto: " + Artigo.CodProduto, font, XBrushes.Black, new XPoint(40, y += 20));
            gfx.DrawString("Descrição: " + Artigo.Descricao, font, XBrushes.Black, new XPoint(40, y += 20));
            gfx.DrawString("Texto complementar: " + Artigo.TextoComplementar, font, XBrushes.Black, new XPoint(40, y += 20));
            gfx.DrawString("Observações: " + Artigo.Obs, font, XBrushes.Black, new XPoint(40, y += 20));

            caminho = pastaPDF + "produto_" + Artigo.Id + ".pdf";
            // Guarda o ficheiro
            document.Save(caminho);

            // Abre automaticamente o PDF (opcional)
            Process.Start("explorer", caminho);

            // Mensagem de sucesso
            return "PDF criado com sucesso!";

        }

        public string ExportarFoto()
        {
            // Cria um novo documento PDF
            using (var doc = new PdfSharp.Pdf.PdfDocument())
            {
                doc.Info.Title = "Produto - Equipa24";

                // Adiciona uma página
                var page = doc.AddPage();
                page.Size = PdfSharp.PageSize.A5;
                page.Orientation = PdfSharp.PageOrientation.Landscape;

                var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
                var corFont = PdfSharp.Drawing.XBrushes.Black;
                var tipoFont = new PdfSharp.Drawing.XFont("Arial", 14);
                var tipoFont1 = new PdfSharp.Drawing.XFont("Arial", 10);
                var tipoFont2 = new PdfSharp.Drawing.XFont("Arial", 18);
                var tipoFont3 = new PdfSharp.Drawing.XFont("Arial", 8);

                var textFormatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);


                var folheto = @"Folheto nº " + Artigo.Id;
                caminho = pastaPDF + "produto_" + Artigo.Id + ".pdf";
                bool flag=true;
                try
                {
                    textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;
                    textFormatter.DrawString(GrupoTrabalho, tipoFont2, XBrushes.Blue, new XRect(20, 25, page.Width.Point, page.Height.Point));
                    textFormatter.DrawString(folheto, tipoFont, XBrushes.Red, new XRect(20, 50, page.Width.Point, page.Height.Point));

                    // Escreve os dados do formulário / produto a ser visualizado
                    int y = 90;
                    textFormatter.DrawString(Artigo.CodProduto, tipoFont1,  XBrushes.Blue, new XRect(20, y += 20, page.Width.Point, page.Height.Point));
                    textFormatter.DrawString(Artigo.Descricao, tipoFont1, XBrushes.Blue, new XRect(20, y += 20, page.Width.Point, page.Height.Point));
                    textFormatter.DrawString(Artigo.TextoComplementar, tipoFont1, XBrushes.Blue, new XRect(20, y += 20, page.Width.Point, page.Height.Point));
                    textFormatter.DrawString(Artigo.Obs, tipoFont1, XBrushes.Blue, new XRect(20, y += 20, page.Width.Point, page.Height.Point));
                    textFormatter.DrawString(Empresa, tipoFont3, XBrushes.DarkOrange, new XRect(40, 400, page.Width.Point, page.Height.Point));

                }
                catch
                {
                    flag = false;
                }


                try
                {
                    XImage imagem = XImage.FromFile(Artigo.Foto);
                    graphics.DrawImage(imagem, 20, 20, 100, 100);
                }
                catch
                {

                }


                if (flag)
                {
                    try
                    {
                        // Guarda o ficheiro
                        doc.Save(caminho);
                        flag = true;
                    }
                    catch
                    {
                        MessageBox.Show("Erro no ficheiro de escrita " + caminho + "\n\n\t Não foi gerado ficheiro 'pdf'");
                        flag = false;
                    }
                }

                if (flag) 
                {
                    // Abre automaticamente o PDF (opcional)
                    try
                    {
                        Process.Start("explorer", caminho);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro no ficheiro de leitura " + caminho + "\n\n" + ex.ToString());
                    }
                }

                if (flag)
                {
                    // Mensagem de sucesso
                    return "PDF foi gerado com sucesso!";
                }
                else
                {
                    return "Erro --> PDF não foi gerado!";
                }
            }
        }
    }
}
