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
        [HttpGet("{cardId}")]
        public async Task<ActionResult> GetByIdAsync(int cardId)
        {
            CardModel card = await _subscriberService.GetByIdAsync(cardId);
            if (card == null)
            {
                throw new Exception("not found");
            }
            return Ok(_mapper.Map<CardDTO>(card));
        }
        [HttpPost]
        public async Task<ActionResult<bool>> RegisterAsync(SubscriberDTO subscriberDTO)
        {
                var subsciber = _mapper.Map<SubscriberModel>(subscriberDTO);
                return await _subscriberService.AddAsync(subsciber, subscriberDTO.height);
        }
        [HttpPost("login")]
        public async Task<ActionResult<int>> LoginAsync(LoginDTO loginDTO)
        {
            var cardId= await _subscriberService.LoginAsync(loginDTO.email, loginDTO.password);
            if (cardId == -1)
                return Unauthorized();
            return cardId;
        }
        [HttpPost("email/{email}")]
        public async Task<ActionResult>SendEmailAsync(string email)
        {
           await _subscriberService.SendEmail(email);
            return Ok();
        }
    }
}
