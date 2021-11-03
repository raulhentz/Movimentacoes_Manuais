using Microsoft.EntityFrameworkCore;
using MovimentosManuais.Domain;

namespace MovimentosManuais.Infra.Repository.DataBaseConfig
{
    public class MovimentacoesManuaisContext : DbContext
    {
        public DbSet<MovimentacaoManual> Movimento_Manual { get; set; }
        public DbSet<ProdutoCosif> Produto_Cosif { get; set; }
        public DbSet<Produto> Produto { get; set; }

        public MovimentacoesManuaisContext(DbContextOptions<MovimentacoesManuaisContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<MovimentacaoManual>()
                .HasKey(mm => new { mm.NumeroLancamento, mm.Mes, mm.Ano, mm.CodigoProduto, mm.CodigoCosif });
            modelBuilder.Entity<MovimentacaoManual>()
                .Property(mm => mm.NumeroLancamento).IsRequired();

            modelBuilder.Entity<ProdutoCosif>()
                .HasKey(pc => new { pc.CodigoProduto, pc.CodigoCosif });

            modelBuilder.Entity<Produto>()
                .HasKey(prod => prod.CodigoProduto);
        }
    }
}