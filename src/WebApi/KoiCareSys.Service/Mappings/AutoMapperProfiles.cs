using AutoMapper;
using KoiCareSys.Data.DTO;
using KoiCareSys.Data.Models;


namespace KoiCareSys.Service.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UnitDTO, Unit>().ReverseMap();
            CreateMap<MeasurementDTO, Measurement>().ReverseMap();
            CreateMap<MeasureDataDTO, MeasureData>().ReverseMap();
            CreateMap<PondDTO, Pond>().ReverseMap();
        }
    }
}
