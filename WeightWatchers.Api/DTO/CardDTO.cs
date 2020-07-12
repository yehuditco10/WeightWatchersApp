using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeightWatchers.Api.DTO
{
    public class CardDTO
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public float BMI { get; set; }
        public float height { get; set; }
        public float weight { get; set; }
    }
}
