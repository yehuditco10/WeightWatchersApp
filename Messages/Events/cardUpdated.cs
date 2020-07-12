using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messages
{
    public class cardUpdated:IEvent
    {
        public bool isSucceeded { get; set; }
        public int measureId { get; set; }
    }
}
