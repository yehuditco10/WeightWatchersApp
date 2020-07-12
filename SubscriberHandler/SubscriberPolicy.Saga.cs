using Messages;
using Messages.Commands;
using Messages.Events;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.Services;

namespace SubscriberHandler
{
    public class SubscriberPolicySaga : Saga<SubscriberPolicyData>,
        IAmStartedByMessages<UpdateCard>,
        IAmStartedByMessages<TrackAdded>
    {
        private readonly ISubscriberService _subscriberService;
        static ILog _log = LogManager.GetLogger<SubscriberPolicySaga>();
        public SubscriberPolicySaga(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }
        public async Task Handle(UpdateCard message, IMessageHandlerContext context)
        {
            _log.Error($"Received UpdateCard in subscriber saga, weight = {message.weight} ...");

            var successedUpdate = await _subscriberService.UpdateCard(message.cardId, message.weight);
            Data.isCardUpdated = true;
            if (successedUpdate != -1)
            {
                AddTrack addTrack = new AddTrack()
                {
                    MeasureId = message.measureId,
                    CardId = message.cardId,
                    NewWeight = message.weight,
                };
                await context.Send(addTrack);
            }
        }
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<SubscriberPolicyData> mapper)
        {
            mapper.ConfigureMapping<UpdateCard>(message => message.measureId)
                        .ToSaga(sagaData => sagaData.measureId); 
            mapper.ConfigureMapping<TrackAdded>(message => message.MeasureId)
                .ToSaga(saga => saga.measureId); 
        }

        public async Task Handle(TrackAdded message, IMessageHandlerContext context)
        {
            _log.Error($"Received track added in subscriber saga, added = {message.Added} ...");

            Data.isTrackingWasAdded = true;
             await sendResponse(context);
        }

        private Task sendResponse(IMessageHandlerContext context)
        {
            if (Data.isCardUpdated && Data.isTrackingWasAdded)
            {
                cardUpdated card = new cardUpdated()
                {
                    measureId = Data.measureId,
                    isSucceeded = true
                };
                var x = context.Publish(card);
            }
            return Task.CompletedTask;
        }
    }
}
