/*
 * ITSE 1430
 * Ashton Harris
 * Lab3
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Data
{
    public interface IMovieDatabase 

    {

        /// <summary>Adds a movie to the database.</summary>

        /// <param name="movie">The product to add.</param>
       /// <param name="message">The error message, if any.</param>

        /// <returns>The added movie.</returns>

        /// <exception cref="ArgumentNullException"><paramref name="movie"/> is null.</exception>

        /// <exception cref="ValidationException"><paramref name="movie"/> is invalid.</exception>

        /// <exception cref="Exception">A product with the same name already exists.</exception>

        /// <remarks>

        /// Generates an error if:

        /// <paramref name="movie"/> is null or invalid.

        /// A movie with the same name already exists.

        /// </remarks>

        Movie Add( Movie movie, out string message );



        /// <summary>Gets all the movies.</summary>

        /// <returns>The list of movies.</returns>

        IEnumerable<Movie> GetAll();



        /// <summary>Removes a product.</summary>

        /// <param name="id">The ID of the project.</param>

        /// <exception cref="ArgumentOutOfRangeException"><paramref name="Title"/> is less than or equal to zero.</exception>

        /// <remarks>

        /// Returns an error if <paramref name="id"/> is less than or

        /// equal to zero.

        /// </remarks>

        void Remove( int id );
       


        /// <summary>Updates an existing movie in the database.</summary>

        /// <param name="movie">The movie to update.</param>

        /// <returns>The updated movie.</returns>

        /// <exception cref="ArgumentNullException"><paramref name="movie"/> is null.</exception>

        /// <exception cref="ValidationException"><paramref name="movie"/> is invalid.</exception>

        /// <exception cref="Exception">A movie with the same name already exists.</exception>

        /// <exception cref="ArgumentException">The product does not exist.</exception>

        /// <remarks>

        /// Generates an error if:

        /// <paramref name="movie"/> is null or invalid.

        /// A movie with the same name already exists.

        /// The movie does not exist.

        /// </remarks>

        Movie Update( Movie movie );
    }
}