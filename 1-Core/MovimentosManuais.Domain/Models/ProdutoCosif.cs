using System.ComponentModel.DataAnnotations.Schema;

namespace MovimentosManuais.Domain
{
    public class ProdutoCosif
    {
        [Column("Cod_Produto", TypeName = "char(4)")]
        public string CodigoProduto { get; set; }
        
        [Column("Cod_Cosif", TypeName = "char(11)")]
        public string CodigoCosif { get; set; }
        
        [Column("Cod_Classifcacao", TypeName = "char(6)")]
        public string CodigoClassificacao { get; set; }
        
        [Column("Sta_Status", TypeName = "char(1)")]
        public string Status { get; set; }
        public Produto Produto { get; set; }
    }
}