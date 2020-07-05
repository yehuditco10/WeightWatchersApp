using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeightWatchers.Api.DTO;
using WeightWatchers.Services;

namespace WeightWatchers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriberController(ISubscriberRepository subscriberRepository)
        {
           _subscriberRepository = subscriberRepository;
        }
        [HttpGet]
        public async Task<CardDTO> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<bool> register(SubscriberDTO subscriber)
        {
            throw new NotImplementedException();

        }
        [HttpPost]
        public async Task<string> login(SubscriberDTO subscriber)
        {
            throw new NotImplementedException();

        }


    }
}