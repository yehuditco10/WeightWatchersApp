using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Measure.Api.DTO;
using Measure.Services.Models;
using AutoMapper;
using Measure.Services;

namespace Measure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMeasureService _measureService;

        public MeasureController(IMapper mapper,
            IMeasureService measureService)
        {
            _mapper = mapper;
            _measureService = measureService;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> CreateAsync(DTO.Measure measureDTO)
        {
            var measure = _mapper.Map<MeasureModel>(measureDTO);
            return await _measureService.CreateAsync(measure);
        }
        //I think it's same.
        //[HttpPut]
        //public async Task<ActionResult<bool>> UodateAsync(DTO.Measure measureDTO)
        //{
        //    throw new NotImplementedException();
        //}
    }
}