/*

 * ITSE 1430

 * Lab 2
 * Ashton Harris

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    class Movie
    {
        /// <summary>Provides information about a Movie.</summary>

        /// <summary>Gets or sets the description.</summary>

        public string Description

        {

            get { return description ?? ""; }

            set { description = value ?? ""; }

        }

        /// <summary>Gets or sets the name.</summary>

        /// <value></value>

        public string Title

        {

            get { return _title ?? ""; }

            set { _title = value; }

        }


        private bool Owned()
        {
            if (Owned.Checkbox == "")
            {
                return true("Status = Owned");
            }
            return false("No movies available.");
            {
/              Title is required

            if (String.IsNullOrEmpty(title))

                    return "Name cannot be empty";



                //Price >= 0

                if (Title < 0)

                    return "Title must be >= 0"
                        return "";
        }
            #region Private Members

        private string title;

        private string description;


    }
}

            
            

                

