using Equipa24_FolhetosPDF.Model;

namespace FolhetosPDF
{
    internal interface IPdfMetodo
    {
        string ExportarComImagem(Produto artigo, string str1, string str2);
    }
}
