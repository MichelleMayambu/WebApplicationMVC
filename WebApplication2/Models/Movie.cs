
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }


        public DateTime? DateAdded { get; set; }

        [Required]
        public int NumberInStock { get; set; }


        public GenreType GenreType { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreTypeId { get; set; }



    }
}

