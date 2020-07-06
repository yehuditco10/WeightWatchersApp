using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Services
{
   public class SubscriberService:ISubscriberSevice
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriberService(ISubscriberRepository subscriberRepository)
        {
           _subscriberRepository = subscriberRepository;
        }

        public async Task<bool> addAsynce(Subscriber subsciber, float height)
        {
           var isSeccseed= await _subscriberRepository.addAsync(subsciber,height);
            if (isSeccseed == 2)
                return true;
            else return false;
        }

        public async Task<string> loginAsync(string email, string password)
        {
            return await _subscriberRepository.loginAsync(email, password);
        }
    }
}
