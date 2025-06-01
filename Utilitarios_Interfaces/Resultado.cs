namespace FolhetosPDF.Utilitarios_Interfaces
{
    public class Resultado
    {
        public string Nome { get; set; }
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public Resultado(string nome, string mensagem, bool sucesso)
        {
            Nome = nome;
            Mensagem = mensagem;
            Sucesso = sucesso;
        }
        public override string ToString()
        {
            return $"{Nome}: {Mensagem} (Sucesso: {Sucesso})";
        }
        // Mensagem += Environment.NewLine + "Erro: " + ex.Message;
    }
}
