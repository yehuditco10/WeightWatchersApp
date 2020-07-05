using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WeightWatchers.Services.Models;
namespace WeightWatchers.Data
{
   public class WeightWatchersContext : DbContext
    {
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public WeightWatchersContext(DbContextOptions<WeightWatchersContext> options)
   : base(options)
        { }
        public WeightWatchersContext()
        {

        }

    }
}
