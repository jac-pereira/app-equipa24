using Equipa24_FolhetosPDF;
using Equipa24_FolhetosPDF.Model;
using FolhetosPDF.Utilitarios_Interfaces;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml.Linq;

namespace FolhetosPDF.Model
{
    internal class ExportarPDF : IPdf, IPdfMetodo
    {
        private StringBuilder sbMsg = new StringBuilder();
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

                string nome = "Folheto do Produto - " + Artigo.Id;
                GravarPdf gravarPdf = new GravarPdf(document, nome, "");
                gravarPdf.Gravar();
                msg = gravarPdf.Mensagem;
                document.Close();

                if (gravarPdf.Sucesso)
                {
                    AbrirFicheiro abrirFicheiro = new AbrirFicheiro(gravarPdf.Caminho);
                    abrirFicheiro.Abrir();
                    msg += abrirFicheiro.MensagemSucessoOuErro;
                }
            }
            
            return msg;
        }





        // Gera ficheiro PDF com FOTO e texto centralizado.
        // Inclui as 2 "string" do construtor com 3 parâmetros.
        public string ExportarFoto()
        {
            msg = PdfComImagem(20, 20);
            return msg;
        }


        // Gera ficheiro PDF com  texto centralizado e Imagem abaixo do texto.
        // A informação a ser exportada é do Produto e inclui as 2 "string", todos passados em parâmetros.
        public string ExportarComImagem(Produto artigo, string grupoTrabalho, string empresa)
        {
            this.Artigo = artigo;
            this.GrupoTrabalho = grupoTrabalho;
            this.Empresa = empresa;
            msg = PdfComImagem(270, 250);
            return msg;
        }

        private string PdfComImagem(int px, int py)
        {

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
                    graphics.DrawImage(imagem, px, py, 100, 100);
                    sbMsg.AppendLine("Gerado documento \"PDF\"!");
                }
                catch (Exception ex)
                {
                    sbMsg.AppendLine("Gerado documento \"PDF\" sem imagem!");
                    sbMsg.AppendLine("Erro: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                doc.Close();
                return ("Erro ao gerar \"PDF\"" + "\n" + ex.Message);
            }

            string nome = "Folheto do Produto - " + Artigo.Id;
            GravarPdf gravarPdf = new GravarPdf(doc, nome, sbMsg.ToString());
            gravarPdf.Gravar();
            msg = gravarPdf.Mensagem;
            doc.Close();

            if (gravarPdf.Sucesso)
            {
                AbrirFicheiro abrirFicheiro = new AbrirFicheiro(gravarPdf.Caminho);
                abrirFicheiro.Abrir();
                msg += abrirFicheiro.MensagemSucessoOuErro;
            }
            return msg;
        }
    }
} // fim do namespace Equipa24_FolhetosPDF.Model


