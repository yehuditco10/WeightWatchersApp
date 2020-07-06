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
        private readonly ISubscriberService _subscriberService;
        private readonly IMapper _mapper;

        public SubscriberController(ISubscriberRepository subscriberRepository,
            ISubscriberService subscriberService,
            IMapper mapper)
        {
            _subscriberRepository = subscriberRepository;
            _subscriberService = subscriberService;
            _mapper = mapper;
        }
        [HttpGet("GetById/{cardId}")]
        public async Task<ActionResult> GetByIdAsync(int cardId)
        {

            
           Card card = await _subscriberService.GetByIdAsync(cardId);
            if (card == null)
            {
                throw new Exception("not found");
            }
            return Ok(_mapper.Map<CardDTO>(card));

        }

        [HttpPost]
        public async Task<bool> register(SubscriberDTO subscriberDTO)
        {
            var model = _mapper.Map<Subscriber>(subscriberDTO);
            throw new NotImplementedException();

        }
        [HttpPost]//my?
        public async Task<string> login(SubscriberDTO subscriber)
        {
            throw new NotImplementedException();

        }



    }
}