using Equipa24_FolhetosPDF;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhetosPDF.Utilitarios_Interfaces
{
    internal class GravarPdf : IGravarPdf
    {
        private readonly PdfDocument documento;
        private readonly string nome;
        private readonly string pastaDestino = Equipa24.PastaPDF;
        private readonly string mensagem;
        private StringBuilder sbMsg = new StringBuilder();

        // Propriedades
        public string Mensagem { get; private set; }
        public bool Sucesso { get; private set; }
        public string Caminho { get; private set; }

        public GravarPdf(PdfDocument documento, string nome, string mensagemInicial = "")
        {
            this.documento = documento ?? throw new ArgumentNullException(nameof(documento));
            this.nome = string.IsNullOrWhiteSpace(nome) ? "Documento" : nome;
            this.mensagem = mensagemInicial;
            Caminho = string.Empty;
            Mensagem = string.Empty;
            Sucesso = false;
        }

        // Grava o ficheiro PDF e inicia processo para abrir o PDF
        public void Gravar()
        {
            Mensagem += mensagem;
            Caminho = Path.Combine(pastaDestino, nome + ".pdf");

            try
            {
                // Guarda o ficheiro
                documento.Save(Caminho);
                Mensagem += Caminho + Environment.NewLine + "Ficheiro \"PDF\" gravado com sucesso! ";
                Sucesso = true;
            }
            catch (Exception ex)
            {
                Mensagem += "Erro no ficheiro de escrita. " + Environment.NewLine + "Não foi gravado ficheiro \"PDF\".";
                Mensagem += Environment.NewLine + "Erro: " + ex.Message;
                Sucesso = false;
            }
        }
    }
}
