using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.Domain
{
    public interface IProdutosCosifRepository
    {
         IEnumerable<ProdutoCosif> ListarRegistros(string codigoProduto);
    }
}