using NServiceBus;
using System;

namespace Messages
{
    public class UpdateCard:ICommand
    {
        public int cardId { get; set; }
        public int measureId { get; set; }
        public float weight { get; set; }
    }
}
