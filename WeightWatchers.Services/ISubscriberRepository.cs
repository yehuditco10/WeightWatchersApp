using System;
using System.Threading.Tasks;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Services
{
    public interface ISubscriberRepository
    {
        Task<CardModel> GetByIdAsync(int cardId);
        Task<int> addAsync(SubscriberModel subsciber, float height);
        Task<string> loginAsync(string email, string password);
    }
}
