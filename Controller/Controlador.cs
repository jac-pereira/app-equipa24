// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
// da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software

using Equipa24_Eventos_Delegados.Model;
using Equipa24_Eventos_Delegados.View;
using FolhetosPDF.Model;
using System;

namespace Equipa24_Eventos_Delegados.Controller
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
            {
                visao = new Visao(modelo);
                modelo = new Modelo(visao);

                modelo.ListaDeProdutosAlterada += visao.AtualizarListaDeProdutos;

                visao.UtilizadorClicouEmSair += UtilizadorClicouEmSair;
                visao.UtilizadorClicouImportar += UtilizadorClicouImportar;
                visao.PrecisoDeProdutos += modelo.SolicitarListaProdutos;
                visao.UtilizadorClicouEmGravar += modelo.Gravar;
            }
            // Subscreve o evento da View
            visao.ClicouEmPDF += ExportarParaPDF;
            visao.ClicouEmPdfFoto += ExportarParaPdfFoto;
        }

        private void ExportarParaPDF(Produto produto)
        {
            ExportarPDF exportarPDF = new ExportarPDF(produto);
            visao.MostrarMensagem(exportarPDF.Exportar());
        }

        private void ExportarParaPdfFoto(Produto produto, string equipa, string empresa)
        {
            ExportarPDF exportarPDF = new ExportarPDF(produto, equipa, empresa);
            visao.MostrarMensagem(exportarPDF.ExportarFoto());
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
            visao.NomeDoFicheiroParaImportar(ref ficheiro);
            if (ficheiro != null)
            {
                modelo.Importar(ficheiro);

            }
        }

    }
}
