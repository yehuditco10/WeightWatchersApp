using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WeightWatchers.Services.Models;
namespace WeightWatchers.Data
{
    public class WeightWatchersContext : DbContext
    {
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Card> Cards { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-1HT6NS2; Initial Catalog = weightWatchers; Integrated Security = True");
                base.OnConfiguring(optionsBuilder);
            }
        }
        public WeightWatchersContext(DbContextOptions<WeightWatchersContext> options)
   : base(options)
        { }
        public WeightWatchersContext()
        {

        }

    }
}
