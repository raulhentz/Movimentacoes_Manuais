using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.Domain
{
    public interface IMovimentacoesManuais
    {
       List<MovimentacaoManual_Dto> ListarTodasMovimentacoes();
        MovimentacaoManual_Dto ConsultarMovimentacao(ChavesMovimentacaoManual movimentacaoId);
        Task<bool> InserirMovimentacaoAsync(MovimentacaoManual_Dto dados);
        Task<bool> AtualizarMovimentacaoAsync(ChavesMovimentacaoManual movimentacaoManualId, MovimentacaoManual_Dto dados);
        Task<bool> DeletarMovimentacaoAsync(ChavesMovimentacaoManual movimentacaoManualId);
    }
}