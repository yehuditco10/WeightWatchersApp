using System;
using Microsoft.EntityFrameworkCore;

namespace Measure.Data
{
    public class MeasureContext : DbContext
    {
        public DbSet<Entities.Measure> Measures { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source =ILBHARTMANLT; Initial Catalog = weightWatchers; Integrated Security = True");
                base.OnConfiguring(optionsBuilder);
            }
        }
        public MeasureContext(DbContextOptions<MeasureContext> options)
       : base(options)
        { }
        public MeasureContext()
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Entities.Measure>().ToTable("Measure");

            modelBuilder.Entity<Entities.Measure>()
                               .Property(m => m.id);
            modelBuilder.Entity<Entities.Measure>()
                                  .Property(m => m.whight)
                                  .HasDefaultValue(0);
            modelBuilder.Entity<Entities.Measure>()
               .Property(m => m.cardId)
               .HasDefaultValue(0);
            modelBuilder.Entity<Entities.Measure>()
                .Property(u => u.date)
                .HasDefaultValueSql(DateTime.Now.ToString());
            modelBuilder.Entity<Entities.Measure>()
                .Property(u => u.status);
        }
    }
}

