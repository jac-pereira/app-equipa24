// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
// da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software

using FolhetosPDF.Model;
using FolhetosPDF.Utilitarios_Interfaces;
using FolhetosPDF;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FolhetosPDF.View
{
    internal class Visao
    {
        private Modelo modelo;
        private Form1 janela;

        private List<Produto> listaProdutos;

        // Índice do produto atualmente selecionado na lista
        private int indiceAtual = -1;

        // Eventos emitidos pela View
        // Eventos que serão ligados no Controller
        public event System.EventHandler UtilizadorClicouImportar;
        public event System.EventHandler UtilizadorClicouEmSair;

        // public delegate void SolicitacaoListaProdutos(ref List<Produto> listadeprodutos);
        public delegate List<Produto> SolicitacaoListaProdutos();
        public event SolicitacaoListaProdutos PrecisoDeProdutos;

        public delegate Resultado GravarProdutos();
        public event GravarProdutos UtilizadorClicouEmGravar;

        public event Action<Produto> ClicouEmPDF;

        public delegate Resultado ExportarComFoto(Produto produto, string par1, string par2);
        public event ExportarComFoto ClicouEmPDFComFoto;

        public delegate Resultado ExportarComImagem(Produto produto, string par1, string par2);
        public event ExportarComImagem ClicouEmPDFComImagem;

        public void CliqueEmPDFComFoto(Produto produto)
        {
            Resultado resultado = new Resultado("Exportar PDF com Foto", "Ficheiro exportado com sucesso!", true);
            resultado.Mensagem = "Nenhum exportador de PDF com foto foi definido.";
            // Interface IPdf - Construtor com 3 parâmetros
            resultado = ClicouEmPDFComFoto?.Invoke(produto, "Equipa - 24", "UC 21179 - Laboratório de Desenvolvimento de Software");
            AbrirPdf(resultado);
        }
        public void CliqueEmPDFComImagem(Produto produto)
        {
            Resultado resultado = new Resultado("Exportar PDF com Foto", "Ficheiro exportado com sucesso!", true);
            resultado.Mensagem = "Nenhum exportador de PDF com foto foi definido.";
            // Interface IPdfMetodo - Método com 3 parâmetros
            resultado = ClicouEmPDFComImagem?.Invoke(produto, "Equipa - 24", "UC 21179 - Laboratório de Desenvolvimento de Software");
            AbrirPdf(resultado);
        }
        public void CliqueEmPDF(Produto produto)
        {
            // Emite o evento com o Produto como argumento
            ClicouEmPDF?.Invoke(produto);

        }
        public void AbrirPdf(Resultado resultado)
        {
            if (resultado.Sucesso)
            {
                AbrirFicheiro abrirFicheiro = new AbrirFicheiro();
                janela.MostraMensagem(abrirFicheiro.Abrir(resultado.Caminho));
            }
            else
            {
                janela.MostraMensagem(resultado.Mensagem);
            }
        }


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

        public void CliqueEmGravar()
        {
            DialogResult resposta = MessageBox.Show("Vai Gravar Ficheiro CSV em disco! \n\n Confirma?", "Gravar em Ficheiro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resposta != DialogResult.Yes)
            {
                janela.MostraMensagem("Ficheiro não foi gravado!");
                return;
            }
            try
            {
                //var result = new Resultado("Gravar", "Ficheiro gravado com sucesso!", true);
                var result = UtilizadorClicouEmGravar();
                janela.MostraMensagem(result.Mensagem);
            }
            catch (Exception ex)
            {
                janela.MostraMensagem(ex.Message);
            }
        }


        public void MostrarMensagem(string mensagem)
        {
            janela.MostraMensagem(mensagem);
        }

        public void CliqueEmSair(EventArgs e)
        {
            UtilizadorClicouEmSair(this, e);
        }

        public void Encerrar()
        {
            Application.Exit();
        }

        public void CliqueEmImportar(object origem, EventArgs e, ref Produto produto, ref ComboBox comboBox)
        {
            if (listaProdutos != null)
            {
                comboBox.Items.Clear();
                listaProdutos.Clear();
                janela.LimpaCampos();
            }
            UtilizadorClicouImportar(origem, e);
            if (listaProdutos != null)
            {
                CarregarComboSeleciona(ref comboBox);
                PesquisarUltimoProduto(ref produto);

                janela.AtivarBotoesNavegacao();
            }
        }

        public void CarregarComboSeleciona(ref ComboBox comboBox)
        {
            string aux;
            comboBox.Items.Clear();
            foreach (Produto p in listaProdutos)
            {
                aux = p.CodProduto.ToString();
                comboBox.Items.Add(aux);
            }
        }

        //public void NomeDoFicheiroParaImportar(ref string ficheiro)
        public string NomeDoFicheiroParaImportar()
        {
            string ficheiro = null;
            try
            {
                /*
                                int n = 0;
                                int x = 1 / n; // Simula uma exceção para testar o tratamento de erros
                */
                OpenFileDialog openFile = new OpenFileDialog { Filter = "CSV Files|*.csv" };
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    ficheiro = openFile.FileName;
                }
            }
            catch (Exception ex)
            {
                MostrarMensagem("Erro ao selecionar ficheiro para importar: " + ex.Message);
                ficheiro = null;
            }
            return ficheiro;
        }

        public void AtualizarListaDeProdutos()
        {
            // Atualizar a lista de produtos recebidas do Model     
            if (PrecisoDeProdutos != null)
                listaProdutos = PrecisoDeProdutos();
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

        // Avança para o próximo produto da lista, se existir
        public Produto AvancarProduto()
        {
            if (indiceAtual < listaProdutos.Count - 1)
            {
                indiceAtual++;
            }
            return listaProdutos[indiceAtual];
        }

        // Recuar para o produto anterior na lista, se existir
        public Produto RetrocederProduto()
        {
            if (indiceAtual > 0)
            {
                indiceAtual--;
            }
            return listaProdutos[indiceAtual];
        }

        // Pesquisa por um produto com determinado ID (chamado na ComboBox)
        public Produto Procurar(int idAux)
        {
            // bool encontrou = false;
            foreach (Produto p in listaProdutos)
            {
                if ((int)p.Id == idAux)
                {
                    indiceAtual = idAux - 1;
                    break;
                }
            }
            return listaProdutos[indiceAtual];
        }
    }
}