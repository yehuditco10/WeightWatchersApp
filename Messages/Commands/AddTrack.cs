using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Commands
{
   public class AddTrack
    {
        public int MeasureId { get; set; }
        public int CardId { get; set; }
        public float Weight { get; set; }
        public float BMI { get; set; }
        public int Trand { get; set; }
        public int Comments { get; set; }
    }
}
