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
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Measure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMeasureService _measureService;
        private readonly IConfiguration _configuration;

        public MeasureController(IMapper mapper,
            IMeasureService measureService,
            IConfiguration configuration)
        {
            _mapper = mapper;
            _measureService = measureService;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> CreateAsync(DTO.Measure measureDTO)
        {
            //  var connection = _configuration["MeasureDBConnection"];
            var connection = _configuration.GetConnectionString("MeasureDBConnection");
            var measure = _mapper.Map<MeasureModel>(measureDTO);
            return await _measureService.CreateAsync(measure);
        }
    }
}
