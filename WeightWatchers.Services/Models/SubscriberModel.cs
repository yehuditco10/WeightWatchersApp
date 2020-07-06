using System;
using System.Collections.Generic;
using System.Text;

namespace WeightWatchers.Services.Models
{
    public class SubscriberModel
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public virtual CardModel card { get; set; }

    }
}
