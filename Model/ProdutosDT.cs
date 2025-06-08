using FolhetosPDF;
using FolhetosPDF.Utilitarios_Interfaces;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace FolhetosPDF.Model
{
    // Ler ficheiro "csv" para uma "dataTable" 
    public class ProdutosDT
    {
        // local de armazenamento das imagens
        private static string pastaImagens = Equipa24.PastaImagens;

        // Separador das colunas no ficheiro "csv"
        private const char cSplit = ';';

        // Para forçar o número de foto igual ao autoincremento
        private const int incrementSeed = 1;

        // Alterado para ser estático
        private static DataTable dt = new DataTable();

        // Colunas (DataTable dtProdutos) 
        // utilizar passagem por referência
        public static DataTable Colunas()
        {
            dt.Clear();
            dt.Columns.Clear();

            dt.Columns.Add("Id", typeof(int));
            dt.Columns[0].AutoIncrement = true;
            dt.Columns[0].AutoIncrementSeed = incrementSeed;

            dt.Columns.Add("produto", typeof(string));
            dt.Columns.Add("descricao", typeof(string));
            dt.Columns.Add("textoComplementar", typeof(string));
            dt.Columns.Add("obs", typeof(string));
            dt.Columns.Add("foto", typeof(string));

            return dt;
        }

        // Ler Ficheiro 
        public static DataTable ObterProdutos(string ficheiro)
        {
            try
            {
                using var sr = new StreamReader(ficheiro);
                // Lê a primeira linha do ficheiro - cabeçalho
                var linha = sr.ReadLine();

                int i = incrementSeed - 1;
                string foto = string.Empty;
                dt.Rows.Clear();
                // Ler as restantes linhas e adiciona-as à tabela
                while ((linha = sr.ReadLine()) != null)
                {
                    // colunas
                    var col = linha.Split(cSplit);
                    i++;
                    foto = pastaImagens + "F" + i + ".png";

                    try
                    {
                        // Adicionar à tabela
                        // para utilizar o incremento automático ...Add(null, ...) 
                        // o valor da variável i tem de corresponder ao valor de incremento automático
                        dt.Rows.Add(null, col[1], col[2], col[3], col[4], foto);
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex.Message + "\n\n" + " Erro ao ler a linha " + i + "\n Número de colunas inferior ao necessário!\n ----------\n " + linha, "Adicionar Linha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new Exception(ex.Message + " Erro ao ler a linha " + i + Environment.NewLine + "Número de colunas inferior ao necessário!" + Environment.NewLine + " " + linha);
                        i--;
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
                throw new Exception(ex.Message);
            }
            return dt;
        }

        public static Resultado GravarProdutos(DataTable dt)
        {
            string pastaCSV = Equipa24.PastaCSV;
            string ficheiroOut = pastaCSV + "FicheiroOut.csv";
            Resultado resultado = new Resultado("Gravar", "Ficheiro gravado com sucesso!", true);

            try
            {
                // ficheiroOut = "\\timp\\FicheiroOut.csv"; // simular exceção
                using var sw = new StreamWriter(ficheiroOut, false);
                string linha = "";
                // Grava a primeira linha - cabeçalho
                sw.WriteLine("ID" + cSplit + "Produto" + cSplit + "Descricao" + cSplit + "TextoComplementar" + cSplit + "Obs");

                // Gravar as restantes linhas
                foreach (DataRow row in dt.Rows)
                {
                    linha = Convert.ToString(row[0]);
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        linha += cSplit + Convert.ToString(row[i]);
                    }
                    sw.WriteLine(linha);
                }
                sw.Close();
                resultado.Mensagem = "Foi gravado o ficheiro: " + ficheiroOut;
                resultado.Sucesso = true;
            }
            catch (Exception ex)
            {
                resultado.Mensagem = "Ficheiro não foi gravado!";
                resultado.Mensagem += Environment.NewLine;
                resultado.Mensagem += ex.Message;
                resultado.Sucesso = false;

                throw new Exception(resultado.Mensagem);

            }
            return resultado;
        }
    }
}
