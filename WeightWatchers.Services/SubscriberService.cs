using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Services
{
   public class SubscriberService:ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriberService(ISubscriberRepository subscriberRepository)
        {
           _subscriberRepository = subscriberRepository;
        }

        public Task<Card> GetByIdAsync(int cardId)
        {
           var subscriber = _subscriberRepository.GetByIdAsync(cardId);
            return subscriber;
        }
    }
}
