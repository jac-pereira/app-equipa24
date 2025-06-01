using FolhetosPDF.Model;

namespace FolhetosPDF.Utilitarios_Interfaces
{
    internal interface IPdfMetodo
    {
        string ExportarComImagem(Produto artigo, string str1, string str2);
    }
}
