using System;
using System.Collections.Generic;
using System.Text;

namespace WeightWatchers.Data.Entities
{
    public class SubscriberEntity
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
