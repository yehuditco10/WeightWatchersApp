using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.Services;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Data
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly WeightWatchersContext _watchersContext;

        public SubscriberRepository(WeightWatchersContext watchersContext)
        {
            _watchersContext = watchersContext;
        }
        public async Task<Card> GetByIdAsync(int cardId)
        {
            try
            {
                var card = await _watchersContext.Cards.FirstOrDefaultAsync(c => c.id == cardId);
                if (card == null)
                {
                    throw new Exception("The id isn't exists");
                }
                var moreDetails = await _watchersContext.Subscribers.FirstOrDefaultAsync(s => s.id.Equals(card.subscriberId));
                card.Subscriber.firstName = moreDetails.firstName;
                card.Subscriber.lastName = moreDetails.lastName;
                return card;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }


        }
    }
}
