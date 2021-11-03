using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Moq;
using MovimentosManuais.Application;
using MovimentosManuais.Application.Mappers;
using MovimentosManuais.Domain;
using MovimentosManuais.Tests.SetupsMocks;
using Xunit;

namespace MovimentosManuais.Tests
{
    public class MovimentacoesManuaisTests
    {
        private IMapper _mapper;
        private MovimentacaoManual_Dto _movimentacaoManual_Dto;
        private MovimentacoesManuais _movimentacoesManuais;
        private Setups _setup;

        public MovimentacoesManuaisTests()
        {
            _setup = new Setups();
            _mapper = _setup.ConfigurarAutoMapperTeste();
            _movimentacoesManuais = new MovimentacoesManuais(_mapper, new Mock<IMovimentacoesManuaisRepository>().Object);
        }

        #region TESTES DE INSERÇÃO

        [Fact]
        public void InserirMovimentacaoAsync_VerificacaoObjetoNulo()
        {
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _movimentacoesManuais.InserirMovimentacaoAsync(new MovimentacaoManual_Dto()));
            Assert.NotNull(ex);
        }

        [Fact]
        public void InserirMovimentacaoAsync_RetornarNumeroLancamento()
        {
            var NumeroLancamento = _movimentacoesManuais.GerarNumeroLancamento(new MovimentacaoManual {Mes = 12, Ano = 2019 });
            Assert.True(NumeroLancamento > 0);
        }

        [Fact]
        public void InserirMovimentacaoAsync_InserindoDadoValido()
        {
            _movimentacaoManual_Dto = new MovimentacaoManual_Dto
            {
                Mes = 12,
                Ano = 2020,
                CodigoCosif = "cosi",
                CodigoProduto = "codPr",
                Descricao = "Teste inserção",
                Valor = 20
            };
            
            var resultadoAtualizacao = _movimentacoesManuais.InserirMovimentacaoAsync(_movimentacaoManual_Dto);
            Assert.True((resultadoAtualizacao.Result));
        }

        [Fact]
        public void InserirMovimentacaoAsync_InserindoDadoInvalido()
        {
            _movimentacaoManual_Dto = new MovimentacaoManual_Dto
            {
                Descricao = "Teste inserção",
                Valor = 20
            };
            var ex = Assert.ThrowsAnyAsync<ValidationException>(() => _movimentacoesManuais.InserirMovimentacaoAsync(_movimentacaoManual_Dto));
            Assert.True((ex.Result.Message != ""));
        }

        #endregion
    }
}
