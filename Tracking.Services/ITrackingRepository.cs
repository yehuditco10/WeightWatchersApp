using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Services
{
   public interface ITrackingRepository
    {
        Task<int> AddTracking(Models.Tracking message);

    }
}
