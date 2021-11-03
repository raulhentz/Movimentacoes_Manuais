using System;
using System.Collections.Generic;
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
    public class MovimentacoesManuaisTestsUpdate
    {
        //Configs
        private MovimentacoesManuais _movimentacoesManuais;
        Mock<IMovimentacoesManuaisRepository> _repository;
        private IMapper _mapper;
        private Setups _setup;

        //Listas e objetos
        List<MovimentacaoManual> _todasMovimentacoes;
        private ChavesMovimentacaoManual _chavesMovimentacaoManual;
        private MovimentacaoManual _movimentacaoManual;
        private  MovimentacaoManual_Dto _movimentacaoManual_Dto;

        public MovimentacoesManuaisTestsUpdate()
        {
            _setup = new Setups();
            //popular objetos fakes
            _todasMovimentacoes = _setup.RetornarListaFake();
            _chavesMovimentacaoManual = _setup.RetornarMovimentacaoManualId();
            _movimentacaoManual = _setup.RetornarObjetoParaConsultaUnica();
            _movimentacaoManual_Dto = _setup.RetornarObjetoParaProcessamento();
            
            //Retornar Configs
            _mapper = _setup.ConfigurarAutoMapperTeste();
            _repository = _setup.ConfigurarRepositorioTeste(_todasMovimentacoes, _chavesMovimentacaoManual, _movimentacaoManual);
            _movimentacoesManuais = _setup.ConfigurarInstanciaTeste(_repository, _mapper);
        }

        #region TESTES DE ATUALIZAÇÃO

        [Fact]
        public void AtualizarMovimentacaoAsync_VerificacaoObjetoNulo()
        {
            var ex = Assert.ThrowsAnyAsync<Exception>(() => _movimentacoesManuais.AtualizarMovimentacaoAsync(new ChavesMovimentacaoManual(), new MovimentacaoManual_Dto()));
            Assert.True((ex.Result.Message != ""));
        }

        [Fact]
        public void AtualizarMovimentacaoAsync_ValidarStateModel()
        {
            _movimentacaoManual_Dto = new MovimentacaoManual_Dto
            {
                Descricao = "Teste Atualização",
                Valor = 20
            };

            var ex = Assert.ThrowsAnyAsync<Exception>(() => _movimentacoesManuais.AtualizarMovimentacaoAsync(new ChavesMovimentacaoManual(), _movimentacaoManual_Dto));
            Assert.True((ex.Result.Message != ""));
        }

        [Fact]
        public void AtualizarMovimentacaoAsync_AtualizandoDadoValido()
        {
            var resultadoAtualizacao = _movimentacoesManuais.AtualizarMovimentacaoAsync(_chavesMovimentacaoManual, _movimentacaoManual_Dto);
            Assert.True((resultadoAtualizacao.Result));
        }

        [Fact]
        public void AtualizarMovimentacaoAsync_AtualizandoDadoQueNaoExiste()
        {   
            MovimentacaoManual teste = null;
            _repository.Setup(x => x.ObterMovimentacao(_chavesMovimentacaoManual)).Returns(teste);
            _movimentacoesManuais = _setup.ConfigurarInstanciaTeste(_repository, _mapper);
            var resultadoAtualizacao = _movimentacoesManuais.AtualizarMovimentacaoAsync(_chavesMovimentacaoManual, _movimentacaoManual_Dto);
            Assert.False((resultadoAtualizacao.Result));
        }
        #endregion
    }
}
