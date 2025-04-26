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

        // Índice do produto atualmente selecionado na lista
        private int indiceAtual = -1;

        // Propriedades auxiliares
        public int IndiceAtual { get => indiceAtual; set => indiceAtual = value; }
        public int TotalProdutos => listaProdutos != null ? listaProdutos.Count : 0;

        // Eventos que serão ligados no Controller
        public event System.EventHandler UtilizadorClicouImportar;
        public event System.EventHandler UtilizadorClicouEmSair;

        public delegate void SolicitacaoListaProdutos(ref List<Produto> listadeprodutos);
        public event SolicitacaoListaProdutos PrecisoDeProdutos;

        internal Visao(Modelo m)
        {
            modelo = m;
        }

        // Ativa a interface gráfica e liga o formulário à instância desta classe Visao
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
            if (listaProdutos != null && listaProdutos != null)
            {
                CarregarComboSeleciona(ref comboBox);
                PesquisarUltimoProduto(ref produto);

                janela.AtivarBotoesNavegacao();

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
            if (PrecisoDeProdutos != null)
                PrecisoDeProdutos(ref listaProdutos);
        }




        // Obtém o último produto importado
        public void PesquisarUltimoProduto(ref Produto produto)
        {
            if (listaProdutos != null && listaProdutos.Count > 0)
            {
                indiceAtual = listaProdutos.Count - 1;
                produto = listaProdutos[indiceAtual];
            }
        }

        // Recomeça a navegação pela lista do início
        public void ResetarNavegacao()
        {
            indiceAtual = -1;
        }

        // Atualiza o formulário com o produto atualmente selecionado
        public void MostrarProdutoAtual()
        {
            if (listaProdutos != null && indiceAtual >= 0 && indiceAtual < listaProdutos.Count)
            {
                Produto produto = listaProdutos[indiceAtual];
                janela.MostrarProduto(ref produto);
            }
        }

        // Avança para o próximo produto da lista, se existir
        public void AvancarProduto()
        {
            if (indiceAtual < listaProdutos.Count - 1)
            {
                indiceAtual++;
                MostrarProdutoAtual();
            }
        }

        // Recuar para o produto anterior na lista, se existir
        public void RetrocederProduto()
        {
            if (indiceAtual > 0)
            {
                indiceAtual--;
                MostrarProdutoAtual();
            }
        }

        // Pesquisa por um produto com determinado ID (chamado na ComboBox)
        public bool Procurar(int idAux, ref Produto produto)
        {
            bool encontrou = false;
            foreach (Produto p in listaProdutos)
            {
                if ((int)p.Id == idAux)
                {
                    produto = p;
                    encontrou = true;
                    indiceAtual = idAux - 1;
                    break;
                }
            }
            return encontrou;
        }



        public Produto ObterProdutoPorId(int id)
        {
            if (listaProdutos != null)
            {
                foreach (Produto p in listaProdutos)
                {
                    if (p.Id == id)
                        return p;
                }
            }

            return null;
        }

    }
}