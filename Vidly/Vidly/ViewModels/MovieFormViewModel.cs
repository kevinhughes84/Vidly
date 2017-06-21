using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public List<GenreType> GenreTypes { get; set; }
        public Movie Movies { get; set; }
        public string Title
        {
            get
            {
                if (Movies != null && Movies.Id != 0)
                { 
                    return "Edit Movie";
                }
                else
                { 
                    return "New Movie";
                }
            }
        }

    }
}