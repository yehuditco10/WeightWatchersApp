using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Events
{
    public class cardUpdated
    {
        public bool isTrackingSucceeded { get; set; }
        public bool isBMISucceeded { get; set; }
        public int measureId { get; set; }
    }
}
