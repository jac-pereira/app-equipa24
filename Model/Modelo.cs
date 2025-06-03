// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
// da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software

using FolhetosPDF.View;
using FolhetosPDF;
using FolhetosPDF.Model;
using FolhetosPDF.Utilitarios_Interfaces;
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

        public string ExportarParaPDFComFoto(Produto produto, string par1, string par2)
        {
            IPdf exportarPDF = new ExportarPDF(produto, par1, par2);
            return exportarPDF.ExportarFoto();
        }

        public string ExportarParaPDFComImagem(Produto produto, string par1, string par2)
        {
            IPdfMetodo exportarPDF = new ExportarPDF();
            return exportarPDF.ExportarComImagem(produto, par1, par2);
        }

        public void Importar(string ficheiro)
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

        // Gravar FicheiroOut
        public Resultado Gravar()
        {
            var resultado = ProdutosDT.GravarProdutos(dtProdutos);
            return resultado;
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
