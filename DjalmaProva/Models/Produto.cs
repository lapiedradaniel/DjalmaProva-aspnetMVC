using System.ComponentModel.DataAnnotations;

namespace DjalmaProva.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        [MaxLength(128)]
        public string ProdutoDescricao { get; set; }

        [MaxLength(128)]
        public string ProdutoNome { get; set; }

        public double ProdutoPreco { get; set; }

        public int QtdeEmEstoque { get; set; }

        public string MarcadoProduto { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}
