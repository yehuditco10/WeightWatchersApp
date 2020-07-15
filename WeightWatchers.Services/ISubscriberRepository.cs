using System;
using System.Threading.Tasks;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Services
{
    public interface ISubscriberRepository
    {
        Task<CardModel> GetByIdAsync(int cardId);
        Task<int> AddAsync(SubscriberModel subsciber, float height);
        Task<int> LoginAsync(string email, string password);
        Task<bool> IsEmailExistsAsync(string email);
        Task<int> UpdateCard(CardModel cardUpdated);
        Task<CardModel> isCardExists(int cardId);
       // Task<string> getEmailByIdAsync(int userId);
    }
}
