using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AshtonHarris.MovieLib.Web.Mvc.Models
{
    public class MovieViewModel
    
        /// <summary>Provides information about a product.</summary>

        {

            public int Id { get; set; }

            public string Description { get; set; }

            [Required(AllowEmptyStrings = false)]

            public string Title { get; set; }



            [Range(0, Double.MaxValue, ErrorMessage = "Length must be >= 0")]

            public decimal Length { get; set; }



            public bool IsOwned { get; set; }
        }
}