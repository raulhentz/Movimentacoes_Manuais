using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovimentosManuais.Domain
{
    public class ChavesMovimentacaoManual
    {
        public int NumeroLancamento { get; set; }

        public int Mes { get; set; }

        public int Ano { get; set; }
        public string CodigoProduto { get; set; }
    }
}