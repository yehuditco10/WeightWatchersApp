using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriberHandler
{
   public class SubscriberPolicyData:ContainSagaData
    {
        public int MeasureId { get; set; }
        public bool IsBMIUpdated { get; set; }
        public bool IsTrackingAdded { get; set; }
        public bool BMISucceeded { get; set; }
        public bool TrackingSucceeded { get; set; }
    }
}
