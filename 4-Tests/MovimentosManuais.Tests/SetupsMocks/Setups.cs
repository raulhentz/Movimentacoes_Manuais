using System;
using System.Collections.Generic;
using AutoMapper;
using Moq;
using MovimentosManuais.Application;
using MovimentosManuais.Application.Mappers;
using MovimentosManuais.Domain;

namespace MovimentosManuais.Tests.SetupsMocks
{
    public class Setups
    {
        
        public IMapper ConfigurarAutoMapperTeste()
        {
            var _autoMapperProfile = new AutoMapperProfiles();
            var _configuration = new MapperConfiguration(x => x.AddProfile(_autoMapperProfile));
            IMapper _mapper = new Mapper(_configuration);
            return _mapper;
        }
        public Mock<IMovimentacoesManuaisRepository> ConfigurarRepositorioTeste(List<MovimentacaoManual> todasMovimentacoes, 
            ChavesMovimentacaoManual chavesMovimentacaoManual, MovimentacaoManual movimentacoes)
        {
            //Criando um objeto mock do UserRepository e configurando para retornar a lista criada anteriormente
            var repository = new Mock<IMovimentacoesManuaisRepository>();
            repository.Setup(x => x.ListarRegistros()).Returns(todasMovimentacoes);
            repository.Setup(x => x.ObterMovimentacao(chavesMovimentacaoManual)).Returns(movimentacoes);
            return repository;
        }

        public MovimentacoesManuais ConfigurarInstanciaTeste(Mock<IMovimentacoesManuaisRepository> repository, IMapper _mapper)
        {
            return new MovimentacoesManuais(_mapper, repository.Object);
        }
        
        public List<MovimentacaoManual> RetornarListaFake()
        {
            var todasMovimentacoes = new List<MovimentacaoManual>();
            todasMovimentacoes.Add(
                new MovimentacaoManual
                {
                    NumeroLancamento = 1,
                    Mes = 12,
                    Ano = 2020,
                    CodigoCosif = "cosi",
                    CodigoProduto = "codPr",
                    Descricao = "Teste Lista",
                    CodigoUsuario = "TESTE",
                    DataMovimento = DateTime.Now.AddDays(1),
                    Valor = 20
                }
            );
            todasMovimentacoes.Add(
                new MovimentacaoManual
                {
                    NumeroLancamento = 1,
                    Mes = 1,
                    Ano = 2021,
                    CodigoCosif = "cosi",
                    CodigoProduto = "codPr",
                    Descricao = "Teste Lista",
                    CodigoUsuario = "TESTE",
                    DataMovimento = DateTime.Now.AddDays(1),
                    Valor = 200
                }
            );
            todasMovimentacoes.Add(
                new MovimentacaoManual
                {
                    NumeroLancamento = 2,
                    Mes = 1,
                    Ano = 2021,
                    CodigoCosif = "cosi",
                    CodigoProduto = "codPr",
                    Descricao = "Teste Lista",
                    CodigoUsuario = "TESTE",
                    DataMovimento = DateTime.Now.AddDays(1),
                    Valor = 300
                }
            );
            
            return todasMovimentacoes;
        }
        public ChavesMovimentacaoManual RetornarMovimentacaoManualId()
        {
            return  new ChavesMovimentacaoManual
            {
                NumeroLancamento = 1,
                Mes = 11,
                Ano = 2021,
                CodigoProduto = "003"
            };

        }
        public MovimentacaoManual RetornarObjetoParaConsultaUnica()
        {
            return new MovimentacaoManual
            {
                NumeroLancamento = 1,
                Mes = 11,
                Ano = 2021,
                CodigoCosif = "cosi",
                CodigoProduto = "003",
                Descricao = "Descricao Teste",
                Valor = 20
            };
        }
        public MovimentacaoManual_Dto RetornarObjetoParaProcessamento()
        {    
            return new MovimentacaoManual_Dto
            {
                NumeroLancamento = 1,
                Mes = 12,
                Ano = 2020,
                CodigoCosif = "cosi",
                CodigoProduto = "codPr",
                Descricao = "Teste Atualizacao/Inserção",
                Valor = 20
            };
        }
        
    }
}
