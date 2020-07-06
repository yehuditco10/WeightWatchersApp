using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeightWatchers.Api.DTO;
using WeightWatchers.Services;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly ISubscriberSevice _subscriberSevice;
        private readonly IMapper _mapper;

        public SubscriberController(ISubscriberSevice subscriberSevice,
            IMapper mapper)
        {
            _subscriberSevice = subscriberSevice;
            _mapper = mapper;
        }
        [HttpGet("get")]
        public async Task<ActionResult<CardDTO>> GetByIdAsync(string subscribeId)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<ActionResult<bool>> post(SubscriberDTO subscriberDTO)
        {
            try
            {
            var subsciber = _mapper.Map<Subscriber>(subscriberDTO);
            return await _subscriberSevice.addAsynce(subsciber, subscriberDTO.height);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> post(LoginDTO loginDTO)
        {
            try
            {
                return await _subscriberSevice.loginAsync(loginDTO.email, loginDTO.password);
            }
            catch (Exception)
            {
               // throw new HttpResponseException(HttpStatusCode.Unauthorized);
              //  return BadRequest(StatusCodes.Status401Unauthorized);
             
                return Unauthorized();
            }

        }



    }
}