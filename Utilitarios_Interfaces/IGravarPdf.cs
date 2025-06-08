namespace FolhetosPDF.Utilitarios_Interfaces
{
    internal interface IGravarPdf
    {
        Resultado Gravar();
        string Mensagem { get; }
        bool Sucesso { get; }
        string Caminho { get; }
    }
}
