using System;
using System.Collections.Generic;
using System.Text;

namespace WeightWatchers.Services.Models
{
   public class Card
    {
        public int id { get; set; }
        public int subscriberId { get; set; }
        public DateTime openDate { get; set; }
        public int BMI { get; set; }
        public int height { get; set; }
        public int weight { get; set; }

        public DateTime updateDate { get; set; }


        

    }
}
