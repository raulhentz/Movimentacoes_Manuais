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
    public class ProdutosController : ControllerBase
    {
        private readonly ILogger<MovimentacoesManuaisController> _logger;
        private readonly IProdutos _produtos;
        public ProdutosController(ILogger<MovimentacoesManuaisController> logger, IProdutos produtos)
        {
            _logger = logger;
            _produtos = produtos;
        }
      
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Produto_Dto> movimentacoes = _produtos.ListarTodosProdutos();
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