using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<CardDTO> GetByIdAsync(string subscribeId)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<bool> post(SubscriberDTO subscriberDTO)
        {
            var subsciber = _mapper.Map<Subscriber>(subscriberDTO);
            return  await _subscriberSevice.addAsynce(subsciber,subscriberDTO.height);
        }
        [HttpPost("login")]
        public async Task<string> post(LoginDTO loginDTO)
        {
            return await _subscriberSevice.loginAsync(loginDTO.email,loginDTO.password);
        }



    }
}