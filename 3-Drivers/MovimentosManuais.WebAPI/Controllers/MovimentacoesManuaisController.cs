using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovimentosManuais.Domain;
using MovimentosManuais.Domain.Resources;

namespace MovimentosManuais.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacoesManuaisController : ControllerBase
    {
        private readonly ILogger<MovimentacoesManuaisController> _logger;
        private readonly IMovimentacoesManuais _movimentosManuais;
        public MovimentacoesManuaisController(ILogger<MovimentacoesManuaisController> logger, IMovimentacoesManuais movimentosManuais)
        {
            _logger = logger;
            _movimentosManuais = movimentosManuais;
        }
      
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<MovimentacaoManual_Dto> movimentacoes = _movimentosManuais.ListarTodasMovimentacoes();
                return Ok(movimentacoes);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, MessagesResources.ErroConsultaMovimentosManuais, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("{0} - {1}", MessagesResources.ErroConsultaMovimentosManuais, ex.Message));
            }
        }

        [HttpGet("GetById/{mes}/{ano}/{numeroLancamento}/{codigoProduto}")]
        public IActionResult GetById(int mes, int ano, int numeroLancamento, string codigoProduto)
        {
            try
            {
                var dadosMovimentacao = new ChavesMovimentacaoManual
                {
                    Mes = mes,
                    Ano = ano,
                    NumeroLancamento = numeroLancamento,
                    CodigoProduto = codigoProduto
                };

                var movimentacao = _movimentosManuais.ConsultarMovimentacao(dadosMovimentacao);
                return Ok(movimentacao);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, MessagesResources.ErroConsultaMovimentacao, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("{0} - {1}", MessagesResources.ErroConsultaMovimentacao, ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovimentacaoManual_Dto model)
        {
            try
            {
                if(!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, MessagesResources.EntidadeInvalida);

                if(await _movimentosManuais.InserirMovimentacaoAsync(model))
                    return StatusCode(StatusCodes.Status200OK, model);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, MessagesResources.ErroProcessamentoBancoDados);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, MessagesResources.ErroProcessamentoBancoDados, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, string.Format("{0} - {1}", MessagesResources.ErroProcessamentoBancoDados, ex.Message));
            }
        }

        [HttpPut("{movimentacaoId}")]
        public async Task<IActionResult> Put(int movimentacaoId, [FromBody] MovimentacaoManual_Dto model)
        {
            try
            {
                ChavesMovimentacaoManual movimentacaoManualId = new ChavesMovimentacaoManual();

                if(!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, MessagesResources.EntidadeInvalida);

                if(await _movimentosManuais.AtualizarMovimentacaoAsync(movimentacaoManualId, model))
                    return StatusCode(StatusCodes.Status200OK, model);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, MessagesResources.ErroProcessamentoBancoDados);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou " + ex.Message);
            }
        }

        [HttpDelete("{mes}/{ano}/{numeroLancamento}/{codigoProduto}")]
        public async Task<IActionResult> Delete(int mes, int ano, int numeroLancamento, string codigoProduto)
        {
            try
            {
                var movimentacaoManualId = new ChavesMovimentacaoManual
                {
                    Mes = mes,
                    Ano = ano,
                    NumeroLancamento = numeroLancamento,
                    CodigoProduto = codigoProduto
                };

                if(!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, MessagesResources.EntidadeInvalida);

                if(await _movimentosManuais.DeletarMovimentacaoAsync(movimentacaoManualId))
                    return StatusCode(StatusCodes.Status200OK, movimentacaoManualId);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, MessagesResources.ErroProcessamentoBancoDados);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou " + ex.Message);
            }
        }

     }
}
