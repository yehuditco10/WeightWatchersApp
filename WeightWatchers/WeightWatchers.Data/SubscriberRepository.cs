using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.Data.Entities;
using WeightWatchers.Services;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Data
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly WeightWatchersContext _weightWatchersContext;
        private readonly IMapper _mapper;

        public SubscriberRepository(WeightWatchersContext weightWatchersContext,
            IMapper mapper)
        {
            _weightWatchersContext = weightWatchersContext;
            _mapper = mapper;
        }
        public async Task<int> addAsync(Subscriber subsciber, float height)
        {
            try
            {
                var exists = await _weightWatchersContext.Subscribers.FirstOrDefaultAsync(s => s.email == subsciber.email);
                if (exists == null)
                {
                    //SubscriberEntity newSunscriber = _mapper.Map<SubscriberEntity>(subsciber);
                    //await _weightWatchersContext.AddAsync(newSunscriber);
                    subsciber.id = Guid.NewGuid();
                    await _weightWatchersContext.Subscribers.AddAsync(subsciber);
                    await _weightWatchersContext.Cards.AddAsync(new Card()
                    {
                        BMI = 0,
                        subscriberId = subsciber.id,
                        height = height,

                    });
                    return await _weightWatchersContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception("no registered");


            }
            return -1;
        }

        public async Task<string> loginAsync(string email, string password)
        {
            Subscriber subscriber = await _weightWatchersContext.Subscribers.FirstOrDefaultAsync(
                s => s.email == email && s.password == password);
            if (subscriber == null)
            {
                throw new Exception("401");
            }
            var card = await _weightWatchersContext.Cards.FirstOrDefaultAsync(
                c => c.subscriberId == subscriber.id);
            return card.id.ToString();
        }
    }
}
