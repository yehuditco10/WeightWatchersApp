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
        [HttpGet("GetById/{cardId}")]
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
        public async Task<ActionResult<bool>> post(SubscriberDTO subscriberDTO)
        {
            try
            {
            var subsciber = _mapper.Map<SubscriberModel>(subscriberDTO);
            return await _subscriberService.addAsynce(subsciber, subscriberDTO.height);
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
                return await _subscriberService.loginAsync(loginDTO.email, loginDTO.password);
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