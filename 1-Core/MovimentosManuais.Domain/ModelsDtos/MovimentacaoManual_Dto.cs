using System;
using System.ComponentModel.DataAnnotations;

namespace MovimentosManuais.Domain
{
    public class MovimentacaoManual_Dto
    {
        public int NumeroLancamento { get; set; }

        [Required]
        public int Mes { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public string CodigoProduto { get; set; }

        [Required]
        public string CodigoCosif { get; set; }

        [Required]
        public string Descricao { get; set; }

        public DateTime DataMovimento { get; set; }

        public string CodigoUsuario { get; set; }

        [Required]
        public decimal Valor { get; set; }

        public ProdutoCosif_Dto ProdutoCosif { get; set; }
    }
}