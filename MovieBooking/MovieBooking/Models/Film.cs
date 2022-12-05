using System.ComponentModel.DataAnnotations.Schema;

namespace MovieBooking.Models
{
    public class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilmId { get; set; }
        public string? FilmName { get; set; }
        public string? TitleRating { get; set; }
    }
}
