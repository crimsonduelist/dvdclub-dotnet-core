using DvdClub.Core.Enumeration;
using System.ComponentModel.DataAnnotations;

namespace DvdClub.Core.Entities {
    public class Movie {

        [Key]
        [Display(Name = "movieid")]
        public int Id { get; set; }
        [Required]
        /*add unique annotation*/
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        /*configure copies relationship with movies*/

        public virtual ICollection<Copy> Copies { get; set; }

        public Movie() {
            Copies = new List<Copy>();
        }
        public Movie(string title, string description, Genre genre) {
            Copies = new List<Copy>();
            Title = title;
            Description = description;
            Genre = genre;
        }
    }
}
