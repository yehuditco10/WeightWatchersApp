using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeightWatchers.Api.DTO
{
    public class CardDTO
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public float BMI { get; set; }
        [Required]
        public float height { get; set; }
        [Required]
        [MinLength(5)]
        public float weight { get; set; }
    }
}
