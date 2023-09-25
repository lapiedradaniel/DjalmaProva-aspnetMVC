using DjalmaProva.Models;
using Microsoft.EntityFrameworkCore;

namespace DjalmaProva.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }


        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }


    }
}
