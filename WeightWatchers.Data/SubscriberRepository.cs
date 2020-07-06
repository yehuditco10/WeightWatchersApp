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
        private readonly WeightWatchersContext _context;
        private readonly IMapper _mapper;

        public SubscriberRepository(WeightWatchersContext watchersContext,
            IMapper mapper)
        {
            _context = watchersContext;
            _mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<int> addAsync(SubscriberModel subsciberModel, float height)
        {
            try
            {
                var exists = await _context.Subscribers.FirstOrDefaultAsync(s => s.email == subsciberModel.email);
                if (exists == null)
                {
                    //SubscriberEntity newSunscriber = _mapper.Map<SubscriberEntity>(subsciber);
                    //await _weightWatchersContext.AddAsync(newSunscriber);
                    subsciberModel.id = Guid.NewGuid();
                    Subscriber s = _mapper.Map<Subscriber>(subsciberModel);
                    await _context.Subscribers.AddAsync(s);
                    await _context.Cards.AddAsync(new Card()
                    {
                        BMI = 0,
                        subscriberId = subsciberModel.id,
                        height = height,
                        openDate = DateTime.Today

                    });
                    return await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception("register failed");
            }
            return -1;
        }
 
    public async Task<CardModel> GetByIdAsync(int cardId)
                {
                    try
                    {
                        Card card = await _context.Cards.FirstOrDefaultAsync(c => c.id == cardId);
                        if (card == null)
                        {
                            throw new Exception("The id isn't exists");
                        }
                        var moreDetails = await _context.Subscribers.FirstOrDefaultAsync(s => s.id.Equals(card.subscriberId));
                        card.subscriber.firstName = moreDetails.firstName;
                        card.subscriber.lastName = moreDetails.lastName;
                        return _mapper.Map<CardModel>(card);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return null;
                    }


                }
                public async Task<int> loginAsync(string email, string password)
                {
                    Subscriber subscriber = await _context.Subscribers.FirstOrDefaultAsync(
                        s => s.email == email && s.password == password);
                    if (subscriber == null)
                    {
                        throw new Exception("401");
                    }
                    var card = await _context.Cards.FirstOrDefaultAsync(
                        c => c.subscriberId == subscriber.id);
                    return card.id;
                }
            }
}
