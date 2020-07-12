using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tracking.Services;

namespace Tracking.Data
    {
        public class TrackingRepository : ITrackingRepository
        {
            private readonly TrackingContext _TrackingContext;
            private readonly IMapper _Mapper;

            public TrackingRepository(TrackingContext trackingContext,
                IMapper mapper)
            {
                _TrackingContext = trackingContext;
                _Mapper = mapper;
            }
            public async Task<int> AddTracking(Services.Models.Tracking message)
            {
               await _TrackingContext.Trackings.AddAsync(_Mapper.Map<Entities.Tracking>(message));
              return await _TrackingContext.SaveChangesAsync();
            }
        }
    }
