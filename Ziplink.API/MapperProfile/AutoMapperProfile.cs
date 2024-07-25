using System.Net.Sockets;
using AutoMapper;
using Zipllink.Core.DTOEntities;
using Zipllink.Core.Entities;

namespace Ziplink.API.MapperProfile;

public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        // This is how we map URLClient and URLDTO as well as 
        CreateMap<EntityUrlDTO, EntityUrl>() // Not mapped, need custom logic
        .ForMember(dest => dest.createdby, opt => opt.MapFrom(src => src.clientIp)) // Not mapped, need custom logic
        .ForMember(dest => dest.createdDate, opt => opt.Ignore()) // Not mapped, need custom logic
        .ForMember(dest => dest.modifieddby, opt => opt.MapFrom(src => src.clientIp)) // Not mapped, need custom logic
        .ForMember(dest => dest.modifiedDate, opt => opt.Ignore())
        .ForMember(dest => dest.shortenUrl, opt => opt.MapFrom(src => src.shortenurl)); ; // Not mapped, need custom logic
        CreateMap<EntityUrl, EntityUrlDTO>()
            .ForMember(dest => dest.url, opt => opt.MapFrom(src => src.url));
    }
}
