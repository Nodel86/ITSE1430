/*
 * ITSE 1430
 * Sample implementation
 */
using System;
using System.Collections.Generic;
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

        #region Private Members

        private string _title, _description;
        
        #endregion
    }
}
