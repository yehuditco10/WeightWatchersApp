using Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeightWatchers.Services;

namespace WeightWatchers.Api.NServiceBus
{
    public class UpdateCardHandler : IHandleMessages<UpdateCard>
    {
        private readonly ISubscriberService _subscriberService;

        public UpdateCardHandler(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }
        public async Task Handle(UpdateCard message, IMessageHandlerContext context)
        {
            await _subscriberService.UpdateCard(message.cardId, message.weight);
            throw new NotImplementedException();
        }
    }
}
