using Microsoft.EntityFrameworkCore;

namespace demoaspnetcorewebapi6.Models
{
    public class MovieContext : DbContext
        
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        { 
        }
        DbSet<Movie> Movies { get; set; } = null!;
    }
}
