// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
namespace Equipa24_FolhetosPDF.Model
{
    // Estrutura dos dados do Produto
    public class Produto
    {
        // Campos - atributos
        private int id;
        private string codProduto;
        private string descricao;
        private string textoComplementar;
        private string obs;
        private string foto;

        // Propriedades - métodos setters & getters
        public int Id { get { return id; } set { id = value; } }
        public string CodProduto { get { return codProduto; } set { codProduto = value; } }
        public string Descricao { get { return descricao; } set { descricao = value; } }
        public string TextoComplementar { get { return textoComplementar; } set { textoComplementar = value; } }
        public string Obs { get { return obs; } set { obs = value; } }
        public string Foto { get { return foto; } set { foto = value; } }

        // Construtores
        public Produto()
        {

        }

        public Produto Clone()
        {
            Produto p = new Produto();
            p.id = id;
            p.codProduto = codProduto;
            p.descricao = descricao;
            p.textoComplementar = textoComplementar;
            p.obs = obs;
            p.foto = foto;

            return p;
        }

        // métodos
        public override string ToString()
        {
            return "Folheto do Produto - " + id;
        }
    }
}