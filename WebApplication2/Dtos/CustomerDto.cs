using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "please enter customer name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Min18YearsMember]
        public DateTime? BirthDate { get; set; }

        public string Gender { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

      //removed reference objects and models to create DTo's for them

    }
}