using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhetosPDF.Utilitarios_Interfaces
{
    internal class AbrirFicheiro
    {        
        // Caminho do ficheiro a abrir
        private string caminho;

        // StringBuilder para armazenar a mensagem de sucesso ou erro
        private StringBuilder sbMsg = new StringBuilder();


        // Propriedade para obter a mensagem de sucesso ou erro
        public string MensagemSucessoOuErro
        {
            get { return sbMsg.ToString(); }
        }


        // Construtor que recebe o caminho do ficheiro a abrir
        public AbrirFicheiro(string caminho)
        {
            this.caminho = caminho;
        }


        // Abre o ficheiro PDF no visualizador padrão do sistema
        public void Abrir()
        {
            try
            {
                System.Diagnostics.Process.Start(caminho);
                sbMsg.Append(" A visualizar o ficheiro \"PDF\"");
            }
            catch (Exception ex)
            {
                sbMsg.AppendLine();
                sbMsg.AppendLine(ex.Message);
                sbMsg.AppendLine();
                sbMsg.AppendLine("A visualizar o ficheiro \"PDF\"");
                sbMsg.AppendLine("Erro no ficheiro de leitura ");
                sbMsg.Append(caminho);
            }           
        }
    }
}
