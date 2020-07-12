using Measure.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Measure.Data.Entities
{
    public class Measure
    {
        public int id { get; set; }
        public int cardId { get; set; }
        public float weight { get; set; }
        public DateTime date { get; set; }
        public eStatus status { get; set; }
    }
}
