// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
// da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software

using Equipa24_Eventos_Delegados.Controller;
using Equipa24_Eventos_Delegados.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Equipa24_Eventos_Delegados.View
{
    internal class Visao
    {
        private Modelo modelo;
        private Form1 janela;

        private List<Produto> listaProdutos;

        public event System.EventHandler UtilizadorClicouImportar;
        public event System.EventHandler UtilizadorClicouEmSair;

        public delegate void SolicitacaoListaProdutos(ref List<Produto> listadeprodutos);
        public event SolicitacaoListaProdutos PrecisoDeProdutos;

        internal Visao(Modelo m)
        {
            modelo = m;
        }

        public void AtivarInterface()
        {
            janela = new Form1();
            janela.Visao = this;

            // A API WinForms desenha as janelas e botões automaticamente
            janela.ShowDialog();
        }

        public void CliqueEmSair(EventArgs e)
        {
            UtilizadorClicouEmSair(this, e);
        }

        public void Encerrar()
        {
            janela.Encerrar();
        }

        public void CliqueEmImportar(object origem, EventArgs e, ref Produto produto, ref ComboBox comboBox)
        {
            // utilizar aqui tratamento de erros
            //Ver comentários em Form1.cs: btnImportar_Click
            if (listaProdutos != null)
            {
                comboBox.Items.Clear();
                listaProdutos.Clear();
                janela.LimpaCampos();
            }
            UtilizadorClicouImportar(origem, e);
            if (listaProdutos != null && listaProdutos!=null)
            {
                CarregarComboSeleciona(ref comboBox);
                PesquisarUltimoProduto(ref produto);
            }
        }

        public void CarregarComboSeleciona(ref ComboBox comboBox)
        {
            // int auxInt = 0;
            string aux;
            comboBox.Items.Clear();
            foreach (Produto p in listaProdutos)
            {
                aux = p.CodProduto.ToString();
                comboBox.Items.Add(aux);
            }
        }


        public void FicheiroParaImportar(ref string ficheiro)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog { Filter = "CSV Files|*.csv" };
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    ficheiro = openFile.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ficheiro = null;
            }
        }






        public void AtualizarListaDeProdutos()
        {
            // Atualizar a lista de produtos recebidas do Model
            PrecisoDeProdutos(ref listaProdutos);
        }


        // void DesenharFormas() ---> void MostrarProdutos()
        void MostrarProdutos()
        {
            /* Criação de uma forma aleatória
            List<Forma> lista = new List<Forma>();
            PrecisoDeFormas(ref lista);
            */

            List<Produto> lista = new List<Produto>();
            PrecisoDeProdutos(ref lista);
            //Mostrar os Produtos aqui
        }

        public void PesquisarUltimoProduto(ref Produto produto)
        {
            foreach (Produto p in listaProdutos)
            {
                produto = p;
            }
        }



        public bool Procurar(int idAux, ref Produto produto)
        {

            int valor = 0;
            bool encontrou = false;
            foreach (Produto p in listaProdutos)
            {
                valor = (int)p.Id;
                if (valor == idAux)
                {
                    produto = p;
                    encontrou = true;
                    break;
                }
            }
            return encontrou;
        }
    }
}

