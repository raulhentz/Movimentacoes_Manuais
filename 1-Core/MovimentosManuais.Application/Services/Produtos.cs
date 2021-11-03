using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using MovimentosManuais.Domain;

namespace MovimentosManuais.Application.Services
{
    public class Produtos: IProdutos
    {
        private readonly IMapper _mapper;
        private readonly IProdutosRepository _repository;
        public Produtos(IMapper mapper, IProdutosRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public List<Produto_Dto> ListarTodosProdutos()
        {
            try
            {
                IEnumerable<Produto> movimentacoes = _repository.ListarRegistros();
                return _mapper.Map<List<Produto_Dto>>(movimentacoes);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}