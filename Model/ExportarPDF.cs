using FolhetosPDF.Model;
using FolhetosPDF.Utilitarios_Interfaces;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;

namespace FolhetosPDF.Model
{
    internal class ExportarPDF : IPdf, IPdfMetodo
    {
        //private StringBuilder sbMsg = new StringBuilder();
        private string msg;

        // propriedades
        public Produto Artigo { get; set; }
        public string GrupoTrabalho { get; set; }
        public string Empresa { get; set; }

        // construtores
        public ExportarPDF()
        {

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

        // Gera ficheiro PDF sem FOTO e texto alinhado à esquerda. 
        // Implementa a interface IPdf -  Construtor com 1 parâmetro.
        public Resultado Exportar()
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

            return FinalizarExportacao(document, "Folheto do Produto - " + Artigo.Id);
            }

        }

        // Gera ficheiro PDF com FOTO e texto centralizado.
        // Implementa a interface IPdf - construtor com 3 parâmetro.
        public Resultado ExportarFoto()
        {
            var resultado = PdfComImagem(20, 20);
            return resultado;
        }

        // Gera ficheiro PDF com  texto centralizado e Imagem abaixo do texto.
        // A informação a ser exportada é do Produto e inclui as 2 "string", todos passados em parâmetros.
        // Implementa a interface IPdfMetodo. - Método com 3 parâmetros.
        public Resultado ExportarComImagem(Produto artigo, string grupoTrabalho, string empresa)
        {
            Artigo = artigo;
            GrupoTrabalho = grupoTrabalho;
            Empresa = empresa;
            var resultado = PdfComImagem(270, 250);
            return resultado;
        }

        private Resultado PdfComImagem(int px, int py)
        {
            Resultado resultado = new Resultado("Exportar PDF", string.Empty, false, string.Empty);

            resultado.Mensagem = string.Empty;

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
            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Center;

            try
            {
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
                    graphics.DrawImage(imagem, px, py, 100, 100);
                    resultado.Mensagem += "Gerado documento \"PDF\"!";
                }
                catch (Exception ex)
                {
                    resultado.Mensagem += "Gerado documento \"PDF\" sem imagem!";
                    resultado.Mensagem += Environment.NewLine + "Erro: " + ex.Message + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                doc.Close();
                resultado.Mensagem = "Erro ao gerar \"PDF\"!" + Environment.NewLine + ex.Message;
                // return ("Erro ao gerar \"PDF\"" + Environment.NewLine + ex.Message);
            }
            return FinalizarExportacao(doc, "Folheto do Produto - " + Artigo.Id);
        }

        private Resultado FinalizarExportacao(PdfDocument doc, string nomeFicheiro)
        {
            var gravarPdf = new GravarPdf(doc, nomeFicheiro, "A gravar o ficheiro PDF: ");
            gravarPdf.Gravar();
            msg += gravarPdf.Mensagem;
            var resultado = new Resultado("Exportar PDF", msg, gravarPdf.Sucesso, gravarPdf.Caminho);

            doc.Close();
            return resultado;
        }
    }
}


