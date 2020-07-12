using System;
using System.Collections.Generic;
using System.Text;

namespace WeightWatchers.Data.Entities
{
    public class Subscriber
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public virtual Card card { get; set; }

    }
}
