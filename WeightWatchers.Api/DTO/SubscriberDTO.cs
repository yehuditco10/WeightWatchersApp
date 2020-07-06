using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeightWatchers.Api.DTO
{
    public class SubscriberDTO
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public float height { get; set; }
    }
}
