using System;
using System.Collections.Generic;
using System.Text;

namespace WeightWatchers.Data.Entities
{
    public class VerificationEmail
    {
        public int Id { get; set; }
        public Guid VerifyPassword { get; set; }

        public string Email { get; set; }

        public DateTime ExpiryDate { get; set; }

        public virtual Subscriber subscriber { get; set; }
    }
}
