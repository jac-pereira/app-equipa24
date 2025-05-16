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
using System.IO;
using FolhetosPDF.Model;


namespace Equipa24_Eventos_Delegados
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
            string str;
            str = visao.CliqueEmGravar();

            if (!str.Equals(string.Empty))
            {
                // MostraMensagem("Ficheiro gravado com sucesso!");
                MostraMensagem(str);
            }
            else
            {
                MostraMensagem("Ficheiro não foi gravado!");
            }

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
        public void MostrarProduto()
        {
            txtID.Text = Convert.ToString(produto.Id);
            txtProduto.Text = produto.CodProduto.ToString();
            txtDescricao.Text = produto.Descricao.ToString();
            txtTextoComplementar.Text = produto.TextoComplementar.ToString();
            txtObs.Text = produto.Obs.ToString();


            // tratamento de exceção
            // pictureBoxFoto.ImageLocation = pasta + "F" + txtID.Text + ".png";
            try
            {

                pictureBoxFoto.ImageLocation = produto.Foto;
                pictureBoxFoto.Load();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Erro no ficheiro da Foto\n Não foi enconttrado o ficheiro da imagem\n Comunique o problema\n Pode continuar sem visualizar a imagem");
                pictureBoxFoto.ImageLocation = string.Empty;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Erro no ficheiro da Foto\n Não é um ficheiro de imagem válido\n Comunique o problema\n Pode continuar sem visualizar a imagem");
                pictureBoxFoto.ImageLocation = string.Empty;
            }

            catch (Exception)
            {
                MessageBox.Show("Erro no ficheiro da Foto\n Comunique o problema\n Pode continuar sem visualizar a imagem");
                pictureBoxFoto.ImageLocation = string.Empty;
            }


        }
        public void LimpaCampos()
        {
            txtID.Text = string.Empty;
            txtProduto.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtTextoComplementar.Text = string.Empty;
            txtObs.Text = string.Empty;
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

        public void AtivarBotoesNavegacao()
        {
            btnAnterior.Enabled = true;
            btnProximo.Enabled = true;
            btnGravar.Enabled = true;
            btnPdf.Enabled = true;
            btnPdfFoto.Enabled = true;
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
        private void btnSair_Click(object sender, EventArgs e)
        {
            visao.CliqueEmSair(e);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void cboSeleciona_Leave(object sender, EventArgs e)
        {
            cboSeleciona.Text = "Selecionar";
            cboSeleciona.Refresh();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // MessageBox.Show("Form1_FormClosing");
            return;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // MessageBox.Show("Form1_FormClosed");
            return;
        }
        public void Encerrar()
        {
            Application.Exit();
        }


        private void btnPdf_Click(object sender, EventArgs e)
        {
            visao.CliqueEmPDF(produto);
        }
        public void MostrarMensagemPdf(string mensagem)
        {
            MostraMensagem(mensagem);
        }
        private void btnPdfFoto_Click(object sender, EventArgs e)
        {
            visao.CliqueEmPdfFoto(produto);
        }
    }
}
