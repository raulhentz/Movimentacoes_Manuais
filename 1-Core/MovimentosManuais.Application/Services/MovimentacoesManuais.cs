using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using MovimentosManuais.Domain;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace MovimentosManuais.Application
{
    public class MovimentacoesManuais : IMovimentacoesManuais
    {
        private readonly IMapper _mapper;
        private readonly IMovimentacoesManuaisRepository _repository;
        public MovimentacoesManuais(IMapper mapper, IMovimentacoesManuaisRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public List<MovimentacaoManual_Dto> ListarTodasMovimentacoes()
        {
            try
            {
                IEnumerable<MovimentacaoManual> movimentacoes = _repository.ListarRegistros();
                return _mapper.Map<List<MovimentacaoManual_Dto>>(movimentacoes);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

         public MovimentacaoManual_Dto ConsultarMovimentacao(ChavesMovimentacaoManual movimentacaoId)
        {
            var movimentacao = _repository.ObterMovimentacao(movimentacaoId);
            return _mapper.Map<MovimentacaoManual_Dto>(movimentacao);
        }

        public async Task<bool> InserirMovimentacaoAsync(MovimentacaoManual_Dto dados)
        {
            try
            {
                var movimentacao = _mapper.Map<MovimentacaoManual>(dados);
                if(movimentacao == null)
                    throw new ArgumentNullException(nameof(dados));

                movimentacao.NumeroLancamento = GerarNumeroLancamento(movimentacao);
                movimentacao.CodigoUsuario = "TESTE";
                movimentacao.DataMovimento = DateTime.Now;

                Validator.ValidateObject(movimentacao, new ValidationContext(movimentacao), true);

                await _repository.InserirAsync(movimentacao);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int GerarNumeroLancamento(MovimentacaoManual dados)
        {
            int ultimoNumeroLancado = _repository.ConsultarUltimoLancamento(dados);
            
            if(ultimoNumeroLancado == 0)
                return 1;
            else
                return ultimoNumeroLancado + 1;
        }

        public async Task<bool> AtualizarMovimentacaoAsync(ChavesMovimentacaoManual movimentacaoManualId, MovimentacaoManual_Dto model)
        {
            try
            {
                if(movimentacaoManualId == null)
                    throw new ArgumentNullException(nameof(movimentacaoManualId));

                var dadosMovimentacao = _mapper.Map<MovimentacaoManual>(model);

                if(dadosMovimentacao == null)
                    throw new ArgumentNullException(nameof(dadosMovimentacao));
                
                dadosMovimentacao.CodigoUsuario = "TESTE";
                dadosMovimentacao.DataMovimento = DateTime.Now;

                Validator.ValidateObject(dadosMovimentacao, new ValidationContext(dadosMovimentacao), true);                
                
                var movimentacao = _repository.ObterMovimentacao(movimentacaoManualId);

                if(movimentacao == null) return false;

                await _repository.AtualizarAsync(dadosMovimentacao);
                
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeletarMovimentacaoAsync(ChavesMovimentacaoManual movimentacaoManualId)
        {
            try
            {
                if(movimentacaoManualId == null)
                    throw new ArgumentNullException(nameof(movimentacaoManualId));

                var movimentacao = _repository.ObterMovimentacao(movimentacaoManualId);

                if(movimentacao == null) return false;

                await _repository.DeletarAsync(movimentacao);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}