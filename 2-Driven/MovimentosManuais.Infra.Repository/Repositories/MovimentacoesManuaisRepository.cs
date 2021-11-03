using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovimentosManuais.Domain;
using MovimentosManuais.Infra.Repository.DataBaseConfig;

namespace MovimentosManuais.Infra.Repository.Repositories
{
    public class MovimentacoesManuaisRepository : RepositoryBase<MovimentacaoManual>, IMovimentacoesManuaisRepository
    {
        public MovimentacoesManuaisRepository(MovimentacoesManuaisContext context): base(context){}

        public IEnumerable<MovimentacaoManual> ListarRegistros()
        {
            IQueryable<MovimentacaoManual> query = _context.Movimento_Manual
                .Include(c => c.ProdutoCosif)
                .Include(c => c.ProdutoCosif.Produto);

            query = query.AsNoTracking()
                        .OrderByDescending(c => c.DataMovimento);

            return query.ToList();
        }
        
        public MovimentacaoManual ObterMovimentacao(ChavesMovimentacaoManual dados)
        {
            IQueryable<MovimentacaoManual> movimentacao = GetByWhere(x => x.NumeroLancamento == dados.NumeroLancamento && x.Mes == dados.Mes 
                                    && x.Ano == dados.Ano && x.CodigoProduto == dados.CodigoProduto);
             
             movimentacao = movimentacao.AsNoTracking()
                                .OrderByDescending(c => c.DataMovimento);

            return movimentacao.FirstOrDefault();

        }
        public int ConsultarUltimoLancamento(MovimentacaoManual dados)
        {
            IQueryable<MovimentacaoManual> query = _context.Movimento_Manual.Where(mm => mm.Ano == dados.Ano && mm.Mes == dados.Mes);
            query = query.AsNoTracking()
                        .OrderByDescending(c => c.DataMovimento);
            
            if(query.ToList().Count > 0)
                return query.FirstOrDefaultAsync().Result.NumeroLancamento;
            else
                return 0;
            
        }
        public async Task DeletarAsync(MovimentacaoManual dados)
        {
            DeleteItem(dados);
            await SaveChangesAsync();
        }

        public async Task InserirAsync(MovimentacaoManual dados)
        {
            InsertItem(dados);
            await SaveChangesAsync();
        }

        public async Task AtualizarAsync(MovimentacaoManual dados)
        {
            UpdateItem(dados);
            await SaveChangesAsync();
        }

        
    }
}