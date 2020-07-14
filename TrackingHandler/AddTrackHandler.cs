using AutoMapper;
using Messages.Commands;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;
using System.Threading.Tasks;
using Tracking.Services;

namespace TrackingHandler
{
    public class AddTrackHandler : IHandleMessages<AddTrack>
    {
        private readonly ITrackingService _TrackingService;
        private readonly IMapper _Mapper;
        static ILog log = LogManager.GetLogger<AddTrackHandler>();
        public AddTrackHandler(ITrackingService trackingService,
            IMapper mapper)
        {
            _TrackingService = trackingService;
            _Mapper = mapper;
        }
        public async Task Handle(AddTrack message, IMessageHandlerContext context)
        {
            log.Error("arrive to tracing the new weight is " + message.Weight);
            var s = await _TrackingService.AddTracking(_Mapper.Map<Tracking.Services.Models.Tracking>(message));
            TrackAdded added = new TrackAdded()
            {
                MeasureId = message.MeasureId,
                Added = s
            };
            await context.Publish(added).ConfigureAwait(false);
            log.Error("send to subscriber....");
        }
    }
}
