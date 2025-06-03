// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
// da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software
using FolhetosPDF.Utilitarios_Interfaces;
using FolhetosPDF.Model;
using FolhetosPDF.View;
using System;

namespace FolhetosPDF.Controller
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
            visao.ClicouEmPDF += AoClicarEmPDF;
            visao.ClicouEmPDFComFoto += AoClicarEmPDFComFoto;
            visao.ClicouEmPDFComImagem += AoClicarEmPDFComImagem;
            //visao.ClicouEmPDFComImagem += modelo.ExportarParaPDFComImagem;
        }

        private void AoClicarEmPDF(Produto produto)
        {
            // Interface IPdf - Construtor com 1 parâmetro
            var exportarPDF = new ExportarPDF(produto);
            var resultado = exportarPDF.Exportar();

            visao.AbrirPdf(resultado);
        }

        private Resultado AoClicarEmPDFComFoto(Produto produto, string grupo, string empresa)
        {
            // Interface IPdf - Construtor com 3 parâmetros
            return modelo.ExportarParaPDFComFoto(produto, grupo, empresa); 
        }

        private Resultado AoClicarEmPDFComImagem(Produto produto, string grupo, string empresa)
        {
            // Interface IPdfMetodo - Método com 3 parâmetros
            return modelo.ExportarParaPDFComImagem(produto, grupo, empresa);
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
