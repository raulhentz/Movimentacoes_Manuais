using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovimentosManuais.Domain;
using MovimentosManuais.Infra.Repository.DataBaseConfig;

namespace MovimentosManuais.Infra.Repository.Repositories
{
    public class ProdutosRepository : RepositoryBase<Produto>, IProdutosRepository
    {
        public ProdutosRepository(MovimentacoesManuaisContext context): base(context){}

        public IEnumerable<Produto> ListarRegistros()
        {
            return GetAll();
        }
        
    }
}