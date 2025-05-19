// Seguido o exemplo do código "FormasAleatorias Eventos-Delegados"
// da  UC 21179 - Laboratório_de_Desenvolvimento_de_Software
namespace Equipa24_Eventos_Delegados.Model
{

    // Estrutura dos dados do Produto
    public class Produto
    {

        // atributos
        private int id;
        private string codProduto;
        private string descricao;
        private string textoComplementar;
        private string obs;
        private string foto;



        // métodos setters & getters
        public int Id { get { return id; } set { id = value; } }
        public string CodProduto { get { return codProduto; } set { codProduto = value; } }
        public string Descricao { get { return descricao; } set { descricao = value; } }
        public string TextoComplementar { get { return textoComplementar; } set { textoComplementar = value; } }
        public string Obs { get { return obs; } set { obs = value; } }
        public string Foto { get { return foto; } set { foto = value; } }


        // construtores
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