using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.Services.Models;

namespace WeightWatchers.Services
{
   public interface ISubscriberService
    {
         Task<Card> GetByIdAsync(int cardId);     
    }
}
