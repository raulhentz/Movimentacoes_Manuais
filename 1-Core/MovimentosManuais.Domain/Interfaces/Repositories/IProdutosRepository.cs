using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.Domain
{
    public interface IProdutosRepository
    {
         IEnumerable<Produto> ListarRegistros();
    }
}