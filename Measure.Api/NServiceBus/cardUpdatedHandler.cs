using Measure.Services;
using Messages;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Measure.Api.NServiceBus
{
    public class CardUpdatedHandler : IHandleMessages<cardUpdated>
    {
        private readonly IMeasureService _measureService;
        public CardUpdatedHandler(IMeasureService measureService)
        {
           _measureService = measureService;
        }
        

        public async Task Handle(cardUpdated message, IMessageHandlerContext context)
        {
            await _measureService.UpdateStatus(message.measureId, message.isBMISucceeded && message.isTrackingSucceeded);
        }
    }
}
