using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreType> GenreTypes { get; set; }
        public Movie Movies { get; set; }
        public string Title
        {
            get
            {
                if (Movies != null && Movies.Id != 0)
                  

                    return "Edit Movie";

                return "New Movie";
            }
        }

    }
}