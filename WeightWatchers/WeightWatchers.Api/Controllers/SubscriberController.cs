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
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IMapper _mapper;

        public SubscriberController(ISubscriberRepository subscriberRepository,
            IMapper mapper)
        {
           _subscriberRepository = subscriberRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<CardDTO> GetByIdAsync(string subscribeId)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<bool> register(SubscriberDTO subscriberDTO)
        {
            var model = _mapper.Map<Subscriber>(subscriberDTO);

            throw new NotImplementedException();

        }
        [HttpPost]
        public async Task<string> login(SubscriberDTO subscriber)
        {
            throw new NotImplementedException();

        }
      


    }
}