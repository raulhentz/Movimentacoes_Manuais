using System.ComponentModel.DataAnnotations.Schema;

namespace MovimentosManuais.Domain
{
    public class Produto
    {
        [Column("Cod_Produto", TypeName = "char(4)")]
        public string CodigoProduto { get; set; }

        [Column("Des_Produto", TypeName = "varchar(30)")]
        public string Descricao { get; set; }

        [Column("Sta_Status", TypeName = "char(1)")]
        public string Status { get; set; }

    }
}