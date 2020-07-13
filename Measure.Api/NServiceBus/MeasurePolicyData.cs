using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Measure.Api.NServiceBus
{
    public class MeasurePolicyData:ContainSagaData
    {
        public int measureId { get; set; }
        public bool isBMIUpdated { get; set; }
        public bool isTrackingUpdated { get; set; }
    }
}
