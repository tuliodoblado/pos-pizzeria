using api_pospizzeria.Features.FCli1.Dtos;
using api_pospizzeria.Features.FOcli.Dtos;
using api_pospizzeria.Features.FOdr1.Dtos;
using api_pospizzeria.Features.FOinv.Dtos;
using api_pospizzeria.Features.FOodr.Dtos;
using api_pospizzeria.Features.FOpct.Dtos;
using api_pospizzeria.Features.FOpmt.Dtos;
using api_pospizzeria.Features.FOprt.Dtos;
using api_pospizzeria.Features.FOrol.Dtos;
using api_pospizzeria.Features.FOusr.Dtos;
using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using AutoMapper;

namespace api_pospizzeria.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Orol, OrolDto>().ReverseMap();
            CreateMap<Ousr, OusrDto>().ReverseMap();
            CreateMap<Opct, OpctDto>().ReverseMap();
            CreateMap<Opmt, OpmtDto>().ReverseMap();
            CreateMap<Oprt, OprtDto>().ReverseMap();
            CreateMap<Ocli, OcliDto>().ReverseMap();
            CreateMap<Cli1, Cli1Dto>().ReverseMap();
            CreateMap<Oodr, OodrDto>().ReverseMap();
            CreateMap<Odr1, Odr1Dto>().ReverseMap();
            CreateMap<Oinv, OinvDto>().ReverseMap();
        }
    }
}
