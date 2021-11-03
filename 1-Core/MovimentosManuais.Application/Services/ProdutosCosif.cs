using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using MovimentosManuais.Domain;

namespace MovimentosManuais.Application.Services
{
    public class ProdutosCosif: IProdutosCosif
    {
        private readonly IMapper _mapper;
        private readonly IProdutosCosifRepository _repository;
        public ProdutosCosif(IMapper mapper, IProdutosCosifRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public List<ProdutoCosif_Dto> ListarTodosCosifPorProduto(string codigoProduto)
        {
            try
            {
                IEnumerable<ProdutoCosif> movimentacoes = _repository.ListarRegistros(codigoProduto);
                return _mapper.Map<List<ProdutoCosif_Dto>>(movimentacoes);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}