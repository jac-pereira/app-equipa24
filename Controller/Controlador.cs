// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
// da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software

using Equipa24_FolhetosPDF.Model;
using Equipa24_FolhetosPDF.View;
using FolhetosPDF;
using FolhetosPDF.Model;
using System;

namespace Equipa24_FolhetosPDF.Controller
{
    class Controlador
    {
        //bool sair;
        Modelo modelo;
        Visao visao;

        public delegate void AtivacaoInterface(object origem);
        //public event AtivacaoInterface AtivarInterface;


        public Controlador()
        {
            modelo = new Modelo(visao);
            visao = new Visao(modelo);

            visao.UtilizadorClicouEmGravar += modelo.Gravar;
            visao.PrecisoDeProdutos += modelo.SolicitarListaProdutos;
            modelo.ListaDeProdutosAlterada += visao.AtualizarListaDeProdutos;

            visao.UtilizadorClicouEmSair += UtilizadorClicouEmSair;
            visao.UtilizadorClicouImportar += UtilizadorClicouImportar;

            // Subscreve o evento da View
            visao.ClicouEmPDF += ExportarParaPDF;
            visao.ClicouEmPDFComFoto += modelo.ExportarParaPDFComFoto;
            visao.ClicouEmPDFComImagem += modelo.ExportarParaPDFComImagem;
        }

        private void ExportarParaPDF(Produto produto)
        {
            ExportarPDF exportarPDF = new ExportarPDF(produto);
            visao.MostrarMensagem(exportarPDF.Exportar());
        }

        public void IniciarPrograma()
        {
            visao.AtivarInterface();
        }

        private void UtilizadorClicouEmSair(object sender, EventArgs e)
        {
            visao.Encerrar();
        }

        public void UtilizadorClicouImportar(object fonte, System.EventArgs args)
        {
            string ficheiro = null;
            ficheiro = visao.NomeDoFicheiroParaImportar();
            if (ficheiro != null)
            {
                modelo.Importar(ficheiro);
            }
        }


    }
}
