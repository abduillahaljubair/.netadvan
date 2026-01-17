using System.ComponentModel.DataAnnotations;

namespace learningwithos.Models
{
    public class MovieList
    {
       
        public int MovieId { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
