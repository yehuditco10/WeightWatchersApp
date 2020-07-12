using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Services
{
   public interface ITrackingService
    {
        Task<bool> AddTracking(Models.Tracking message);
    }
}
