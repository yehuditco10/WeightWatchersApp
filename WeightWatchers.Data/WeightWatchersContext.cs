using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using WeightWatchers.Data.Entities;
namespace WeightWatchers.Data
{
    public class WeightWatchersContext : DbContext, IWeightWatchersContext
    {
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Card> Cards { get; set; }

        public WeightWatchersContext(DbContextOptions<WeightWatchersContext> options)
   : base(options)
        { }
        public WeightWatchersContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["weightWatchersConnection"]);
                base.OnConfiguring(optionsBuilder);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().ToTable("Card");
            modelBuilder.Entity<Subscriber>().ToTable("Subscriber");

            modelBuilder.Entity<Card>()
                               .Property(Subscriber => Subscriber.openDate)
                                   .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Card>()
                              .Property(Subscriber => Subscriber.updateDate)
                                  .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Card>()
                .Property(u => u.weight)
                .HasDefaultValue(0);
            modelBuilder.Entity<Card>()
               .Property(u => u.BMI)
               .HasDefaultValue(0);
            modelBuilder.Entity<Card>()
                .Property(u => u.id);
            // .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Subscriber>()
                .Property(u => u.id);
            //  .HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Subscriber>()

                  .HasIndex(u => u.email)
                  .IsUnique();


            modelBuilder.Entity<Subscriber>()
           .Property(u => u.firstName)
           .IsRequired();

            modelBuilder.Entity<Subscriber>()
           .Property(u => u.password)
           .IsRequired();
        }
    }
}
