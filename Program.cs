// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
// da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software

using Equipa24_Eventos_Delegados.Controller;
using System;
using System.Windows.Forms;

namespace Equipa24_Eventos_Delegados
{

    static class Equipa24
    {
        // pasta utilizada para os ficheiros 
        private const string pastaCSV = @"\LDS2425\FicheirosData\";
        private const string pastaPDF = @"\LDS2425\FicheirosData\PDF\";
        private const string pastaImagens = @"\LDS2425\FicheirosData\Imagens\";
        private const string equipa = "Equipa - 24";
        private const string uc = "UC 21179 - Laboratório de Desenvolvimento de Software";

        public static string Equipa => equipa;
        public static string Uc => uc;
        public static string PastaCSV => pastaCSV;

        public static string PastaImagens => pastaImagens;

        public static string PastaPDF => pastaPDF;

        //private const string ficheiro = pasta + "FicheiroProdutos.csv";

        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Controlador controlador = new Controlador();
            controlador.IniciarPrograma();
        }
    }
}
