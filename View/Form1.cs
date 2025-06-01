// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
// da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software

using FolhetosPDF.Model;
using FolhetosPDF.View;
using System;
using System.IO;
using System.Windows.Forms;

namespace FolhetosPDF
{
    internal partial class Form1 : Form
    {
        Visao visao;

        private Produto produto;

        internal Form1()
        {
            InitializeComponent();
        }

        public Visao Visao { get => visao; set => visao = value; }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            visao.CliqueEmGravar();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            produto = null;
            visao.CliqueEmImportar(sender, e, ref produto, ref cboSeleciona);

            if (produto != null)
            {
                MostrarProduto();
                MostraMensagem("Ficheiro Importado!");
            }
        }

        /// Solicita à classe Visao que retroceda para o produto anterior
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            produto = visao.RetrocederProduto();
            MostrarProduto();
        }

        /// Solicita à classe Visao que avance para o próximo produto
        private void btnProximo_Click(object sender, EventArgs e)
        {
            produto = visao.AvancarProduto();
            MostrarProduto();
        }

        private void MostrarProduto()
        {
            txtID.Text = Convert.ToString(produto.Id);
            txtProduto.Text = produto.CodProduto.ToString();
            txtDescricao.Text = produto.Descricao.ToString();
            txtTextoComplementar.Text = produto.TextoComplementar.ToString();
            txtObs.Text = produto.Obs.ToString();

            // tratamento de exceção
            // pictureBoxFoto.ImageLocation = pasta + "F" + txtID.Text + ".png";
            bool erro = true;
            try
            {
                pictureBoxFoto.ImageLocation = produto.Foto;
                pictureBoxFoto.Load();
                erro = false;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Erro no ficheiro da Foto\n Não foi enconttrado o ficheiro da imagem\n Comunique o problema\n Pode continuar sem visualizar a imagem");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erro no ficheiro da Foto\n Não é um ficheiro de imagem válido\n Comunique o problema\n Pode continuar sem visualizar a imagem");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro no ficheiro da Foto\n Comunique o problema\n Pode continuar sem visualizar a imagem");
            }
            finally
            {
                if (erro)
                    pictureBoxFoto.ImageLocation = string.Empty;
                pictureBoxFoto.Refresh();
            }
        }

        private void cboSeleciona_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idAux = cboSeleciona.SelectedIndex + 1;
            // bool flag = false;
            produto = null;
            produto = Visao.Procurar(idAux);
            if (produto != null)
            {
                MostrarProduto();
            }
            cboSeleciona.Text = "Selecionar";
            cboSeleciona.Refresh();

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            visao.CliqueEmSair(e);
        }

        private void cboSeleciona_Leave(object sender, EventArgs e)
        {
            cboSeleciona.Text = "Selecionar";
            cboSeleciona.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            return;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            return;
        }

        private void txtMensagens_Leave(object sender, EventArgs e)
        {
            txtMensagens.Text = string.Empty;
        }

        public void MostraMensagem(string txt)
        {
            txtMensagens.Text += txt;
            txtMensagens.Focus();
            txtMensagens.AppendText("  ");
        }
        public void LimpaCampos()
        {
            txtID.Text = string.Empty;
            txtProduto.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtTextoComplementar.Text = string.Empty;
            txtObs.Text = string.Empty;
        }

        public void AtivarBotoesNavegacao()
        {
            btnAnterior.Enabled = true;
            btnProximo.Enabled = true;
            btnGravar.Enabled = true;
            btnPdf.Enabled = true;
            btnPdfFoto.Enabled = true;
            btnPdfImagem.Enabled = true;
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (produto != null)
                visao.CliqueEmPDF(produto);
            else
                MostraMensagem("Produto não definido.");
        }

        private void btnPdfFoto_Click(object sender, EventArgs e)
        {
            if (produto != null)
                visao.CliqueEmPDFComFoto(produto);
            else
                MostraMensagem("Produto não definido.");
        }

        private void btnPdfImagem_Click(object sender, EventArgs e)
        {
            if (produto != null)
                visao.CliqueEmPDFComImagem(produto);
            else
                MostraMensagem("Produto não definido.");
        }
    }
}
