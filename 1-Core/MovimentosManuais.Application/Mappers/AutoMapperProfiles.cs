using AutoMapper;
using MovimentosManuais.Domain;

namespace MovimentosManuais.Application.Mappers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MovimentacaoManual, MovimentacaoManual_Dto>().ReverseMap();
            CreateMap<Produto, Produto_Dto>().ReverseMap();
            CreateMap<ProdutoCosif, ProdutoCosif_Dto>().ReverseMap();
        }
    }
}