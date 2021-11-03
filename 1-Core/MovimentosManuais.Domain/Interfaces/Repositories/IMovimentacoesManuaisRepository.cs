using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.Domain
{
    public interface IMovimentacoesManuaisRepository
    {
         IEnumerable<MovimentacaoManual> ListarRegistros();
         MovimentacaoManual ObterMovimentacao(ChavesMovimentacaoManual dados);
         int ConsultarUltimoLancamento(MovimentacaoManual dados);
         Task InserirAsync(MovimentacaoManual dados);
         Task AtualizarAsync(MovimentacaoManual dados);
         Task DeletarAsync(MovimentacaoManual dados);
    }
}