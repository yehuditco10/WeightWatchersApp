using Microsoft.EntityFrameworkCore;
using WeightWatchers.Data.Entities;

namespace WeightWatchers.Data
{
    public interface IWeightWatchersContext
    {
        DbSet<Card> Cards { get; set; }
        DbSet<Subscriber> Subscribers { get; set; }
     
    }
}
