using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using MovimentosManuais.Application;
using MovimentosManuais.Application.Mappers;
using MovimentosManuais.Domain;
using MovimentosManuais.Tests.SetupsMocks;
using Xunit;

namespace MovimentosManuais.Tests.Application.Services
{
    public class MovimentacoesManuaisTests_Delete
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

        public MovimentacoesManuaisTests_Delete()
        {
            _setup = new Setups();
            //popular objetos fakes
            _todasMovimentacoes = _setup.RetornarListaFake();
            _chavesMovimentacaoManual = _setup.RetornarMovimentacaoManualId();
            _movimentacaoManual = _setup.RetornarObjetoParaConsultaUnica();
            
            //Retornar Configs
            _mapper = _setup.ConfigurarAutoMapperTeste();
            _repository = _setup.ConfigurarRepositorioTeste(_todasMovimentacoes, _chavesMovimentacaoManual, _movimentacaoManual);
            _movimentacoesManuais = _setup.ConfigurarInstanciaTeste(_repository, _mapper);
        }

        #region TESTES DE DELETE

        
        [Fact]
        public void MovimentacoesManuais_DeletarRegistroSucesso()
        {   
           var resultadoDelete = _movimentacoesManuais.DeletarMovimentacaoAsync(_chavesMovimentacaoManual);
            Assert.True(resultadoDelete.Result);
        }

        #endregion
    }
}