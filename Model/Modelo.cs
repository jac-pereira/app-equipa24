// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
// da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software

using Equipa24_Eventos_Delegados.Controller;
using Equipa24_Eventos_Delegados.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Equipa24_Eventos_Delegados.Model
{
    class Modelo
    {
        private Visao visao;
        private List<Produto> produtos;
        private DataTable dtProdutos = new DataTable();


        public delegate void NotificarListaDeProdutosAlterada();
        public event NotificarListaDeProdutosAlterada ListaDeProdutosAlterada;

        public Modelo(Visao v)
        {
            visao = v;
            produtos = new List<Produto>();
        }

        public void Importar(ref string ficheiro)
        {

            // Importar Ficheiro
            // Alterar a lista de produtos
            ProdutosDT.Colunas(ref dtProdutos);
            ProdutosDT.ObterProdutos(ref dtProdutos, ref ficheiro);

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

        public void SolicitarListaProdutos(ref List<Produto> listadeprodutos)
        {
            // Copia a lista "produtos" para "listadeprodutos"
            // usando o estilo de cópia adequado aos dados
            // (provavelmente deep copy e não shallow copy).
            // não deveria simplesmente fazer:
            // listadeprodutos=produtos;
            // porque isso permitira que quem manipulasse os produtos
            // da lista fornecida alterasse as do próprio Model
            // visto serem referências.

            listadeprodutos = new List<Produto>();
            foreach (Produto p in produtos)
                listadeprodutos.Add(p.Clone());
        }
    }
}
