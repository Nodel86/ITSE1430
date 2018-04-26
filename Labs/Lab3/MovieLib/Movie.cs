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
    public class Movie
    {
        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }

        public int Id { get; set; }

        /// <summary>Determines if the movie is owned or not.</summary>
        public bool IsOwned { get; set; }

        /// <summary>Gets or sets the length, in minutes.</summary>
        public int Length { get; set; }

        /// <summary>Gets or sets the title.</summary>
        public string Title
        {
            get { return _title ?? ""; }
            set { _title = value; }
        }

        internal object Validate()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )

        {

            var errors = new List<ValidationResult>();



            //Name is required

            if (String.IsNullOrEmpty(_title))

                errors.Add(new ValidationResult("Name cannot be empty",

                             new[] { nameof(Title) }));

             //Price >= 0
            if (Length < 0)

                errors.Add(new ValidationResult("Length must be >= 0",

                            new[] { nameof(Length) }));



            return errors;

        }
        #region Private Members

        private string _title, _description;
        
        #endregion
    }
}
