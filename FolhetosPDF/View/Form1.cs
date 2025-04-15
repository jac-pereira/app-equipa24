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
        private void MostrarProduto(ref Produto produto)
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


        private void MostraMensagem(string txt)
        {
            txtMensagens.Text += txt;
            txtMensagens.Focus();
            txtMensagens.AppendText("  ");

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtMensagens_Leave(object sender, EventArgs e)
        {
            txtMensagens.Text = string.Empty;
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

        private void btnImportar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
