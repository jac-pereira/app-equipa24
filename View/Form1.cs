// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
// da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software

using Equipa24_Eventos_Delegados.Controller;
using Equipa24_Eventos_Delegados.Model;
using Equipa24_Eventos_Delegados.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics; 


namespace Equipa24_Eventos_Delegados
{
    internal partial class Form1 : Form
    {
        Visao visao;
        private const string pasta = @"C:\LDS2425\FicheirosData\Imagens\";

        internal Form1()
        {
            InitializeComponent();
        }

        public Visao Visao { get => visao; set => visao = value; }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            // Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
            // da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software
            //
            // O Visual Studio cria automaticamente este método btnImportar_Click com a interface visual
            // Mantendo essa ligação, podemos continuar a usar a edição visual
            //
            // Então comunicamos aqui à nossa classe central do componente View o clique no botão.
            //
            // Podíamos igualmente ir a     View.Designer.cs 
            // associar diretamente     this.btnImportar.Click 
            // ao método da classe      Controller
            // mas isso desativaria a edição visual
            // e faria com que essa ligação entre classes 
            // estivesse a ser feita fora do Controller.
            //
            // Por isso, limitamo-nos a comunicar aqui o 
            // evento Click à classe central da View que o relançará
            // como o evento UtilizadorClicouImportar.
            //
            // Isto permite que seja o Controller a associar o destino dele.
            // Não precisávamos de manter os parâmetros, mantivemo-los apenas
            // por uma questão de enriquecer o exemplo, já que não os usámos 
            // noutros eventos deste código exemplificativo


            Produto produto = null;
            visao.CliqueEmImportar(sender, e, ref produto, ref cboSeleciona);

            if (produto != null)
            {
                MostrarProduto(ref produto);
                MostraMensagem("Ficheiro Importado!");
            }
        }
        public void MostrarProduto(ref Produto produto)
        {
            txtID.Text = Convert.ToString(produto.Id);
            txtProduto.Text = produto.CodProduto.ToString();
            txtDescricao.Text = produto.Descricao.ToString();
            txtTextoComplementar.Text = produto.TextoComplementar.ToString();
            txtObs.Text = produto.Obs.ToString();


            // tratamento de exceção
            // pictureBoxFoto.ImageLocation = pasta + "F" + txtID.Text + ".png";
            pictureBoxFoto.ImageLocation = produto.Foto;
            pictureBoxFoto.Load();



        }
        public void LimpaCampos()
        {
            txtID.Text = string.Empty;
            txtProduto.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtTextoComplementar.Text = string.Empty;
            txtObs.Text = string.Empty;
            cboSeleciona.Text = "Selecionar";
        }


        private void cboSeleciona_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idAux = cboSeleciona.SelectedIndex + 1;
            bool flag = false;
            Produto produto = null;
            flag = Visao.Procurar(idAux, ref produto);
            if (flag)
            {
                MostrarProduto(ref produto);
            }
            cboSeleciona.Text = "Selecionar";
            cboSeleciona.Refresh();
        }

        public void AtivarBotoesNavegacao()
        {
            btnAnterior.Enabled = true;
            btnProximo.Enabled = true;
            btnGravar.Enabled = true;
            btnPdf.Enabled = true;
        }


        /// Solicita à classe Visao que retroceda para o produto anterior

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            visao.RetrocederProduto();
        }

        /// Solicita à classe Visao que avance para o próximo produto

        private void btnProximo_Click(object sender, EventArgs e)
        {
            visao.AvancarProduto();
        }

        private void btnAnterior_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnProximo_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            // Cria um novo documento PDF
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Produto - Equipa24";

            // Adiciona uma página
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 12);

            // Desenha os dados do formulário
            int y = 40;
            gfx.DrawString("Produto: " + txtProduto.Text, font, XBrushes.Black, new XPoint(40, y));
            y += 20;
            gfx.DrawString("Descrição: " + txtDescricao.Text, font, XBrushes.Black, new XPoint(40, y));
            y += 20;
            gfx.DrawString("Texto complementar: " + txtTextoComplementar.Text, font, XBrushes.Black, new XPoint(40, y));
            y += 20;
            gfx.DrawString("Observações: " + txtObs.Text, font, XBrushes.Black, new XPoint(40, y));

            // Guarda o ficheiro
            string caminho = @"C:\LDS2425\FicheirosData\produto.pdf";
            document.Save(caminho);

            // Abre o PDF (opcional)
            Process.Start("explorer", caminho);

            // Mensagem de sucesso
            MostraMensagem("PDF criado com sucesso!");
        }

        private void btnPdf_Click_1(object sender, EventArgs e)
        {
            // Cria um novo documento PDF
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Produto - Equipa24";

            // Adiciona uma página
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 12);

            // Escreve os dados do formulário
            int y = 40;
            gfx.DrawString("Produto: " + txtProduto.Text, font, XBrushes.Black, new XPoint(40, y += 20));
            gfx.DrawString("Descrição: " + txtDescricao.Text, font, XBrushes.Black, new XPoint(40, y += 20));
            gfx.DrawString("Texto complementar: " + txtTextoComplementar.Text, font, XBrushes.Black, new XPoint(40, y += 20));
            gfx.DrawString("Observações: " + txtObs.Text, font, XBrushes.Black, new XPoint(40, y += 20));

            // Guarda o ficheiro
            string caminho = @"C:\LDS2425\FicheirosData\produto.pdf";
            document.Save(caminho);

            // Abre automaticamente o PDF (opcional)
            Process.Start("explorer", caminho);

            // Mensagem de sucesso
            MostraMensagem("PDF criado com sucesso!");

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            int idAtual;

            if (int.TryParse(txtID.Text, out idAtual))
            {
                Produto produto = visao.ObterProdutoPorId(idAtual);

                if (produto != null)
                {
                    // Atualiza os valores do produto com os dados do formulário
                    produto.CodProduto = txtProduto.Text;
                    produto.Descricao = txtDescricao.Text;
                    produto.TextoComplementar = txtTextoComplementar.Text;
                    produto.Obs = txtObs.Text;
                    produto.Foto = pictureBoxFoto.ImageLocation;

                    MostraMensagem("Alterações guardadas com sucesso!");
                }
                else
                {
                    MostraMensagem("Produto não encontrado.");
                }
            }
            else
            {
                MostraMensagem("ID inválido.");
            }
        }


        private void MostraMensagem(string txt)
        {
            txtMensagens.Text += txt;
            txtMensagens.Focus();
            txtMensagens.AppendText("  ");

        }


        private void txtMensagens_Leave(object sender, EventArgs e)
        {
            txtMensagens.Text = string.Empty;
        }


        public void Encerrar()
        {
            Application.Exit();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            visao.CliqueEmSair(e);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }


}
