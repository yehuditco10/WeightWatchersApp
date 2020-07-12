using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Measure.Api.DTO;
using Measure.Data;
using Measure.Data.Entities;
using Measure.Services;
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
