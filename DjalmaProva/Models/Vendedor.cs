using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DjalmaProva.Models
{
    public class Vendedor
    {
        public int VendedorId { get; set; }

        [MaxLength(128)]
        public string NomeCompleto { get; set; }

        [MaxLength(11)]
        public string Telefone { get; set; }

        [MaxLength(128)]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Cliente> clientes { get; set; }

        public ICollection<Produto> produtos { get; set; }
    }
}
