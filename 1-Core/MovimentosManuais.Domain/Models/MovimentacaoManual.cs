using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovimentosManuais.Domain
{
    public class MovimentacaoManual
    {
        [Column("Num_Lancamento")]
        public int NumeroLancamento { get; set; }

        [Column("Dat_Mes")]
        [Required]
        public int Mes { get; set; }

        [Column("Dat_Ano")]
        [Required]
        public int Ano { get; set; }

        
        [Column("Cod_Produto", TypeName = "char(4)")]
        [Required]
        public string CodigoProduto { get; set; }

        [Column("Cod_Cosif", TypeName = "char(11)")]
        [Required]
        public string CodigoCosif { get; set; }

        [Column("Des_Descricao", TypeName = "varchar(50)")]
        [Required]
        public string Descricao { get; set; }

        [Column("Dat_Movimento")]
        [Required]
        public DateTime DataMovimento { get; set; }

        [Column("Cod_Usuario", TypeName = "varchar(15)")]
        [Required]
        public string CodigoUsuario { get; set; }

        [Column("Val_Valor", TypeName = "decimal(18,2)")]
        [Required]
        public decimal Valor { get; set; }

        public ProdutoCosif ProdutoCosif { get; set; }
    }
}
