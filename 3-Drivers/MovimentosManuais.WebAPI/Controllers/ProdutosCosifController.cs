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
    public class ProdutosCosifController : ControllerBase
    {
        private readonly ILogger<MovimentacoesManuaisController> _logger;
        private readonly IProdutosCosif _produtos;
        public ProdutosCosifController(ILogger<MovimentacoesManuaisController> logger, IProdutosCosif produtos)
        {
            _logger = logger;
            _produtos = produtos;
        }
      
        [HttpGet("{codigoProduto}")]
        public IActionResult Get(string codigoProduto)
        {
            try
            {
                IEnumerable<ProdutoCosif_Dto> movimentacoes = _produtos.ListarTodosCosifPorProduto(codigoProduto);
                return Ok(movimentacoes);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, MessagesResources.ErroConsultaProdutos, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, string.Format("{0} - {1}", MessagesResources.ErroConsultaProdutos, ex.Message));
            }
        }
    }
}