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
        IHandleMessages<TrackAdded>,
        IHandleMessages<BMIUpdated>
    {
        static ILog _log = LogManager.GetLogger<SubscriberPolicySaga>();
        public async Task Handle(UpdateCard message, IMessageHandlerContext context)
        {
            _log.Error($"Received UpdateCard in subscriber saga, weight = {message.weight} ...");

            UpdateBMI updateBMI = new UpdateBMI()
            {
                measureId = message.measureId,
                cardId = message.cardId,
                weight = message.weight
            };

            await context.SendLocal(updateBMI).ConfigureAwait(false);

            AddTrack addTrack = new AddTrack()
            {
                MeasureId = message.measureId,
                CardId = message.cardId,
                Weight = message.weight
            };
            await context.Send(addTrack);

        }
        public async Task Handle(TrackAdded message, IMessageHandlerContext context)
        {
            _log.Error($"Received track added in subscriber saga, added = {message.Added} ...");

            Data.IsTrackingAdded = true;
            await sendCompleteResponse(context);
        }
        public async Task Handle(BMIUpdated message, IMessageHandlerContext context)
        {
            Data.IsBMIUpdated = true;
            Data.BMISucceeded = message.isSucceeded;
            await sendCompleteResponse(context);
        }
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<SubscriberPolicyData> mapper)
        {
            mapper.ConfigureMapping<UpdateCard>(message => message.measureId)
                        .ToSaga(sagaData => sagaData.MeasureId);
            mapper.ConfigureMapping<BMIUpdated>(message => message.measureId)
                        .ToSaga(sagaData => sagaData.MeasureId);
            mapper.ConfigureMapping<TrackAdded>(message => message.MeasureId)
                .ToSaga(saga => saga.MeasureId);
        }

        private async Task sendCompleteResponse(IMessageHandlerContext context)
        {
            if (Data.IsTrackingAdded && Data.IsBMIUpdated)
            {
                _log.Warn($"Complete saga for id {context.MessageId}------------------------------");
                cardUpdated card = new cardUpdated()
                {
                    measureId = Data.MeasureId,
                    isBMISucceeded = Data.BMISucceeded,
                    isTrackingSucceeded = Data.TrackingSucceeded
                };
                await context.Publish(card);
            }
        }

    }
}
