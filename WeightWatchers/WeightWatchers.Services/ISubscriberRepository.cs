using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Services
{
    public interface ISubscriberRepository
    {
        Task<int> addAsync(Subscriber subsciber, float height);
        Task<string> loginAsync(string email, string password);
    }
}
