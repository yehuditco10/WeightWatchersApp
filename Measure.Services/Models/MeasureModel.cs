using System;
using System.Collections.Generic;
using System.Text;

namespace Measure.Services.Models
{
    public class MeasureModel
    {
        public int id { get; set; }
        public int cardId { get; set; }
        public float weight { get; set; }
        public DateTime date { get; set; }
        public eStatus status { get; set; }
    }
    public enum eStatus
    {
        inProsses=1, success, failed
    }
}
