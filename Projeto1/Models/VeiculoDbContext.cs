using System.Data.Entity;

namespace Projeto1.Models
{
    public class VeiculoDbContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }

    }
}