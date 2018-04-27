/*
 * ITSE 1430
 * Ashton Harris
 * Lab3
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    /// <summary>Represents a movie.</summary>
    public class Movie : IValidatableObject
    {
        
        /// <summary>Gets or sets the movie ID.</summary>
            public int Id { get; set; }


        public int Id { get; set; }

        /// <summary>Determines if the movie is owned or not.</summary>
        public bool IsOwned { get; set; }

        /// <summary>Gets or sets the length, in minutes.</summary>
        public int Length { get; set; }

        /// <summary>Gets or sets the name.</summary>
        public string Title
        {
            get { return _title ?? ""; }
            set { _title = value; }
        }

        /// <summary>Validate the product.</summary>

        /// <param name="validationContext">The validation context.</param>

        /// <returns>The validation results.</returns>

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )

        {

            var errors = new List<ValidationResult>();



            //Name is required

            if (String.IsNullOrEmpty(_title))

                errors.Add(new ValidationResult("Name cannot be empty",

                             new[] { nameof(Title) }));
        }

        #region Private Members

        private string _title, _description;
        
        #endregion
    }
}
