using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Equipa24_Eventos_Delegados.Model
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

        // Colunas (DataTable dtProdutos) 
        // utilizar passagem por referência
        public static void Colunas(ref DataTable dt)
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


        }

        // Ler Ficheiro 
        public static void ObterProdutos(ref DataTable dt, string ficheiro)
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


                    // Adicionar à tabela
                    // para utilizar o incremento automático ...Add(null, ...) 
                    // o valor da variável i tem de corresponder ao valor de incremento automático
                    dt.Rows.Add(null, col[1], col[2], col[3], col[4], foto);
                }
                sr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public static string GravarProdutos(DataTable dt)
        {
            string pastaCSV = Equipa24.PastaCSV;
            string ficheiroOut = pastaCSV + "FicheiroOut.csv";

            DialogResult resposta = MessageBox.Show("Vai Gravar Ficheiro CSV em disco! \n\n Confirma?", "Gravar em Ficheiro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resposta != DialogResult.Yes)
            {
                return string.Empty;
            }
            try
            {
                using (var sw = new StreamWriter(ficheiroOut, false))
                {
                    string linha = "";
                    // Grava a primeira linha - cabeçalho
                    sw.WriteLine("ID"+ cSplit + "Produto" + cSplit + "Descricao" + cSplit + "TextoComplementar" + cSplit + "Obs");

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
                }
                return "\nFoi gravado o ficheiro: " + ficheiroOut ; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("\nError a gravar ficheiro: " + ficheiroOut + "\n", "Gravação do Fciheiro \"csv\"", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return string.Empty;
            }
        }
    }
}
