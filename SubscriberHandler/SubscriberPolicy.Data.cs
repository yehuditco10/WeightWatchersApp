using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriberHandler
{
    class SubscriberPolicyData:ContainSagaData
    {
        public int measureId { get; set; }
        public bool isCardUpdated { get; set; }
        //public bool isCardUpdated { get; set; }
    }
}
