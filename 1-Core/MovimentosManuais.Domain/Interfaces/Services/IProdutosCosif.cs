using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.Domain
{
    public interface IProdutosCosif
    {
       List<ProdutoCosif_Dto> ListarTodosCosifPorProduto(string codigoProduto);
    }
}