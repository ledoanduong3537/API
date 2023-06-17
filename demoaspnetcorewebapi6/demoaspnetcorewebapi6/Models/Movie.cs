using System.ComponentModel.DataAnnotations;

namespace demoaspnetcorewebapi6.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
