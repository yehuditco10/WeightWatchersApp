using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriberService(ISubscriberRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }

        public async Task<bool> addAsynce(SubscriberModel subsciber, float height)
        {
            try
            {
                var isSeccseed = await _subscriberRepository.addAsync(subsciber, height);
                if (isSeccseed == 2)
                    return true;
                else if (isSeccseed == -1)
                {
                    throw new Exception("this email exists, try another");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return false;
        }

        public async Task<int> loginAsync(string email, string password)
        {
            return await _subscriberRepository.loginAsync(email, password);
        }

        public Task<CardModel> GetByIdAsync(int cardId)
        {
           var subscriber = _subscriberRepository.GetByIdAsync(cardId);
            return subscriber;
        }

    }
}
