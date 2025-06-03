using FolhetosPDF.Model;

namespace FolhetosPDF.Utilitarios_Interfaces
{
    internal interface IPdfMetodo
    {
        Resultado ExportarComImagem(Produto artigo, string str1, string str2);
    }
}
