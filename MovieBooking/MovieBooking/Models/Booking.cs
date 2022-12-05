using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieBooking.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        //public IEnumerable<Person> Persons { get; set; }

        [Required]
        public int? Name { get; set; }
        [Required]
        public int? Age { get; set; }

    }
}
