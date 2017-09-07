using Microsoft.EntityFrameworkCore;

namespace ****project-name****.Models
{

    public class ****model-name****Context : DbContext
    {
        public ****model-name****Context(DbContextOptions<****model-name****Context> options) : base(options) { }

        public DbSet<****model-name****> ****model-name**** { get; set; }

    }

}