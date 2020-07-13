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
    public class MeasurePolicy : Saga<MeasurePolicyData>,
        IAmStartedByMessages<cardUpdated>
    {
        private readonly IMeasureService _measureService;
        static ILog log = LogManager.GetLogger<MeasurePolicy>();

        public MeasurePolicy(IMeasureService measureService)
        {
           _measureService = measureService;
        }
        

        public async Task Handle(cardUpdated message, IMessageHandlerContext context)
        {
            log.Error("BMI updated, and Tracking added, yooooooo");
            await _measureService.UpdateStatus(message.measureId, message.isBMISucceeded && message.isTrackingSucceeded);
            //return  Task.CompletedTask;
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<MeasurePolicyData> mapper)
        {
            mapper.ConfigureMapping<cardUpdated>(message => message.measureId)
            .ToSaga(sagaData => sagaData.measureId);
        }
    }
}
