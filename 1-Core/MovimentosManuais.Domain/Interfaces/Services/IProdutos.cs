using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.Domain
{
    public interface IProdutos
    {
       List<Produto_Dto> ListarTodosProdutos();
    }
}