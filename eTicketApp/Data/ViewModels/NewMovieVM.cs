using eTicketApp.Data;
using eTicketApp.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketApp.Models
{
    public class NewMovieVM

    {
        public int Id { get; set; }

        [Display(Name="Movie Name")]
        [Required(ErrorMessage ="Name is requierd")]
        public string Name { get; set; }
        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is requierd")]
        public string Description { get; set; }
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is requierd")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is requierd")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is requierd")]
        public double Price { get; set; }
        [Display(Name = "Movie Poster")]
        [Required(ErrorMessage = "Poster is requierd")]
        public string ImageURL { get; set; }
        [Display(Name = "Select A Cateory")]
        [Required(ErrorMessage = "Movie Category is requierd")]
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        [Display(Name = "Select Actor(s) ")]
        [Required(ErrorMessage = "Movie actor(s) is requierd")]
        public List<int> ActorIds { get; set; }

        //Cinema
        [Display(Name = "Select A Cinema")]
        [Required(ErrorMessage = "Movie Cinema is requierd")]
        public int CinemaId { get; set; }


        //Producer
        [Display(Name = "Select A Producer")]
        [Required(ErrorMessage = "Movie Producer is requierd")]
        public int ProducerId { get; set; }
        

    }
}
