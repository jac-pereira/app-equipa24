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
        private const string pastaImagens = @"C:\LDS2425\FicheirosData\Imagens\";

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
        public static void ObterProdutos(ref DataTable dt, ref string ficheiro)
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

    }
}
