using System;
using System.Threading.Tasks;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Services
{
    public interface ISubscriberRepository
    {
        Task<Card> GetByIdAsync(int cardId);
    }
}
