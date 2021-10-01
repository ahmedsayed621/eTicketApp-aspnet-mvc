using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketApp.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Profile Picture Is required")]
        public string ProfilePictureURL { get; set; }
        [Required(ErrorMessage = "FullName Is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="FullName must be between 3 and 50 chars")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bio Is required")]
        public string Bio { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
