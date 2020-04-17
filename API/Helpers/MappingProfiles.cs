using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(destinationMember => destinationMember.ProductBrand,
                           memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.ProductBrand.Name))
                .ForMember(destinationMember => destinationMember.ProductType,
                           memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.ProductType.Name))
                .ForMember(destinationMember => destinationMember.PictureUrl,
                           memberOptions => memberOptions.MapFrom<PictureUrlResolver>());
        }
    }
}