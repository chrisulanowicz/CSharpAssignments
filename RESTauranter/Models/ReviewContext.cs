using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Models
{

    public class ReviewsContext : DbContext
    {
        public ReviewsContext(DbContextOptions<ReviewsContext> options) : base(options) { }

        public DbSet<Review> Reviews { get; set; }

    }

}