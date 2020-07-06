using System;
using System.Collections.Generic;
using System.Text;

namespace WeightWatchers.Services.Models
{
   public class Card
    {
        public int id { get; set; }
        public Guid subscriberId { get; set; }
        public DateTime openDate { get; set; }
        public float BMI { get; set; }
        public float height { get; set; }
        public float weight { get; set; }
        public DateTime updateDate { get; set; }
        public virtual Subscriber subscriber { get; set; }

        public Card(int id, Guid subscriberId, DateTime openDate, float bMI, float height, float weight, DateTime updateDate)
        {
            this.id = id;
            this.subscriberId = subscriberId;
            this.openDate = openDate;
            BMI = bMI;
            this.height = height;
            this.weight = weight;
            this.updateDate = updateDate;
        }
        public Card()
        {

        }

    }
}
