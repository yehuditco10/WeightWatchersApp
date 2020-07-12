using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Services
{
    public class TrackingService : ITrackingService
    {
        private readonly ITrackingRepository _TrackingRepository;

        public TrackingService(ITrackingRepository trackingRepository)
        {
            _TrackingRepository = trackingRepository;
        }
        public async Task<bool> AddTracking(Models.Tracking message)
        {
          return await _TrackingRepository.AddTracking(message)>0 ? true:false;
        }
    }
}
