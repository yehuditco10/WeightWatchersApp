using System;
using System.Collections.Generic;
using System.Text;

namespace WeightWatchers.Services
{
   public class SubscriberService:ISubscriberSevice
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriberService(ISubscriberRepository subscriberRepository)
        {
           _subscriberRepository = subscriberRepository;
        }
    }
}
