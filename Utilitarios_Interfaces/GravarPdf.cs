using Equipa24_FolhetosPDF;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhetosPDF.Utilitarios_Interfaces
{
    internal class GravarPdf
    {
        private StringBuilder sbMsg = new StringBuilder();

        // Propriedades
        public PdfDocument Documento { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }

        public GravarPdf(PdfDocument documento, string nome, string mensagem)
        {
            Documento = documento;
            Nome = nome;
            Mensagem = mensagem;
            Sucesso = false;
            Caminho = string.Empty;
        }

        // Grava o ficheiro PDF e inicia processo para abrir o PDF
        public void Gravar()
        {
            sbMsg.Clear();
            sbMsg.Append(Mensagem);
            Caminho = Equipa24.PastaPDF + Nome + ".pdf";

            try
            {
                // Guarda o ficheiro
                Documento.Save(Caminho);
                sbMsg.Append("Ficheiro \"PDF\" gravado com sucesso!");
                Sucesso = true;
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Erro no ficheiro de escrita " + caminho + "\n\n\t Não foi gerado ficheiro 'pdf'");
                sbMsg.Append("Erro no ficheiro de escrita ");
                sbMsg.AppendLine(Caminho);
                sbMsg.Append("Não foi gravado ficheiro \"PDF\"");
                sbMsg.AppendLine();
                sbMsg.AppendLine("Erro: " + ex.Message);
                // return sbMsg.ToString();
                Sucesso = false;
            }
            Mensagem = sbMsg.ToString();

        }
    }
}
