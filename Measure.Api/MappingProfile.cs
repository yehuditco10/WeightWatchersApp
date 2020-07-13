using AutoMapper;
using Measure.Services.Models;

namespace WeightWatchers.Api
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Measure.Api.DTO.Measure, MeasureModel>();
            CreateMap<MeasureModel, Measure.Data.Entities.Measure>();
        }
    }
}
