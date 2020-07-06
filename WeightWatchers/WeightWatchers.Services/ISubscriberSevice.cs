using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Services
{
    public interface ISubscriberSevice
    {
        Task<bool> addAsynce(Subscriber subsciber, float height);
        Task<string> loginAsync(string email, string password);
    }
}
