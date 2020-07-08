using Measure.Services;
using Messages;
using NServiceBus;
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

        public MeasurePolicy(IMeasureService measureService)
        {
           _measureService = measureService;
        }
        

        public async Task Handle(cardUpdated message, IMessageHandlerContext context)
        {
            await _measureService.UpdateStatus(message.measureId, message.isSucceeded);
            //return  Task.CompletedTask;
           
            
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<MeasurePolicyData> mapper)
        {
            mapper.ConfigureMapping<cardUpdated>(message => message.measureId)
            .ToSaga(sagaData => sagaData.measureId);
           
        }
    }
}
