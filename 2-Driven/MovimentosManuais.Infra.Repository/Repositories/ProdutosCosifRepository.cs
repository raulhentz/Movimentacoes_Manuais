using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovimentosManuais.Domain;
using MovimentosManuais.Infra.Repository.DataBaseConfig;

namespace MovimentosManuais.Infra.Repository.Repositories
{
    public class ProdutosCosifRepository : RepositoryBase<ProdutoCosif>, IProdutosCosifRepository
    {
        public ProdutosCosifRepository(MovimentacoesManuaisContext context): base(context){}

        public IEnumerable<ProdutoCosif> ListarRegistros(string codigoProduto)
        {
             IQueryable<ProdutoCosif> movimentacao = GetByWhere(x => x.CodigoProduto == codigoProduto);
             
            return movimentacao.AsQueryable();
        }
        
    }
}