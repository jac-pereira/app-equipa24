// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
// da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software

using FolhetosPDF.Utilitarios_Interfaces;
using FolhetosPDF.View;
using System;
using System.Collections.Generic;
using System.Data;


namespace FolhetosPDF.Model
{
    class Modelo
    {
        private Visao visao;
        private List<Produto> produtos;
        private List<Produto> listadeprodutos; // Lista de produtos que será fornecida à Visão
        private DataTable dtProdutos = new DataTable();

        public delegate void NotificarListaDeProdutosAlterada();
        public event NotificarListaDeProdutosAlterada ListaDeProdutosAlterada;

        public Modelo(Visao v)
        {
            visao = v;
            produtos = new List<Produto>();
        }

        public Resultado ExportarParaPDFComFoto(Produto produto, string par1, string par2)
        {
            // Interface IPdf - Construtor com 3 parâmetros
            IPdf exportarPDF = new ExportarPDF(produto, par1, par2);
            return exportarPDF.ExportarFoto();
        }

        public Resultado ExportarParaPDFComImagem(Produto produto, string par1, string par2)
        {
            // Interface IPdfMetodo - Método com 3 parâmetros
            IPdfMetodo exportarPDF = new ExportarPDF();
            var resultado = exportarPDF.ExportarComImagem(produto, par1, par2);
            return resultado;
        }

        public void Importar(string ficheiro)
        {
            try
            {
                // Importar Ficheiro
                // Alterar a lista de produtos
                dtProdutos = ProdutosDT.Colunas();
                dtProdutos = ProdutosDT.ObterProdutos(ficheiro);

                produtos.Clear();
                foreach (DataRow dr in dtProdutos.Rows)
                {
                    Produto p = new Produto();
                    p.Id = Convert.ToInt32(dr[0]);
                    p.CodProduto = dr[1].ToString();
                    p.Descricao = dr[2].ToString();
                    p.TextoComplementar = dr[3].ToString();
                    p.Obs = dr[4].ToString();
                    p.Foto = dr[5].ToString();

                    produtos.Add(p);
                }
                // Notifica a que as listas foram alteradas.
                ListaDeProdutosAlterada();
            }
            catch (Exception ex)
            {
                // Tratar exceção
                // visao.MostrarMensagemErro(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        // Gravar FicheiroOut
        public Resultado Gravar()
        {
            try
            {
                var resultado = ProdutosDT.GravarProdutos(dtProdutos);
                return resultado;
            }
            catch (Exception ex)
            {
                // Tratar exceção
                // visao.MostrarMensagemErro(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public List<Produto> SolicitarListaProdutos()
        {
            listadeprodutos = new List<Produto>();
            listadeprodutos.Clear();
            foreach (Produto p in produtos)
            {
                listadeprodutos.Add(p.Clone());
            }

            return listadeprodutos;
        }
    }
}
