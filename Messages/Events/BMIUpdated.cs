using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Events
{
    public class BMIUpdated
    {
        public bool isSucceeded { get; set; }
        public int measureId { get; set; }
    }
}
