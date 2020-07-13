using Messages;
using Messages.Commands;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeightWatchers.Services;

namespace WeightWatchers.Api.NServiceBus
{
    public class UpdateBMIHandler : IHandleMessages<UpdateBMI>
    {
        private readonly ISubscriberService _subscriberService;
        static ILog log = LogManager.GetLogger<UpdateBMIHandler>();
        public UpdateBMIHandler(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        public async Task Handle(UpdateBMI message, IMessageHandlerContext context)
        {
            log.Error($"Received UpdateBMI in subscriber, weight = {message.weight} ...");
            var successedUpdate = await _subscriberService.UpdateCard(message.cardId, message.weight);
           
            BMIUpdated bMIUpdated = new BMIUpdated()
            {
                isSucceeded = successedUpdate != -1 ? true : false,
                measureId = message.measureId
            };
            await context.Publish(bMIUpdated)
                       .ConfigureAwait(false);
        }
    }
}
