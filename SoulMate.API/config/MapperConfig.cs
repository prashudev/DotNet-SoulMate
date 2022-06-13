using AutoMapper;
using SoulMate.API.data;

namespace SoulMate.API.config
{
    public class MapperConfig: Profile
    {
        public MapperConfig() {
            CreateMap<Soulmate, IncomingSoulmateDTO>().ReverseMap();
            CreateMap<Soulmate, OutgoingSoulmateDTO>().ReverseMap();
        }
    }
}
