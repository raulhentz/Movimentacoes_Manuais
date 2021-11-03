namespace MovimentosManuais.Domain
{
    public class ProdutoCosif_Dto
    {
        public string CodigoProduto { get; set; }
        
        public string CodigoCosif { get; set; }
        
        public string CodigoClassificacao { get; set; }
        
        public string Status { get; set; }
        public Produto_Dto Produto { get; set; }
    }
}