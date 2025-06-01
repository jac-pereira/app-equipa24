namespace FolhetosPDF.Utilitarios_Interfaces
{
    internal interface IGravarPdf
    {
        void Gravar();
        string Mensagem { get; }
        bool Sucesso { get; }
        string Caminho { get; }
    }
}
