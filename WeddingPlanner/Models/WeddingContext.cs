using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{

    public class WeddingContext : DbContext
    {
        public WeddingContext(DbContextOptions<WeddingContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

    }

}