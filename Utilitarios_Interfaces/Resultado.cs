namespace FolhetosPDF.Utilitarios_Interfaces
{
    public class Resultado
    {
        public string Nome { get; set; }
        public string Mensagem { get; set; }
        public string Caminho { get; set; }
        public bool Sucesso { get; set; }
        public Resultado(string nome, string mensagem, bool sucesso)
        {
            Nome = nome;
            Mensagem = mensagem;
            Sucesso = sucesso;
            Caminho = string.Empty; 
        }
        public Resultado(string nome, string mensagem, bool sucesso, string caminho)
        {
            Nome = nome;
            Mensagem = mensagem;
            Sucesso = sucesso;
            Caminho = caminho; 
        }
        public override string ToString()
        {
            return $"{Nome}: {Mensagem} (Sucesso: {Sucesso})";
        }
        // Mensagem += Environment.NewLine + "Erro: " + ex.Message;
    }
}
