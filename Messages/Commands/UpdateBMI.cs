using System;
using System.Collections.Generic;
using System.Text;

namespace Messages.Commands
{
    public class UpdateBMI
    {
        public int cardId { get; set; }
        public int measureId { get; set; }
        public float weight { get; set; }
    }
}
