﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Data
{
   public abstract class MovieDatabase : IMovieDatabase
    { 
        
        
    /// <summary>Add a new product.</summary>

    /// <param name="movie">The product to add.</param>

    /// <param name="message">Error message.</param>

    /// <returns>The added product.</returns>

    /// <remarks>

    /// Returns an error if product is null, invalid or if a product

    /// with the same name already exists.

    /// </remarks>

    public Movie Add( Movie movie, out string message )

    {

        //Check for null

        if (movie == null)

        {

            message = "Movie cannot be null.";

            return null;

        };



        //Validate product using IValidatableObject

        var errors = movie.validate();


        var error = errors.FirstOrDefault();

        if (error != null)

        {

            message = error.ErrorMessage;

            return null;

        };



        // Verify unique product

        var existing = GetMovieByTitleCore(movie.Title);

        if (existing != null)

        {

            message = "Movie already exists.";

            return null;

        };



        message = null;

        return AddCore(movie);

    }



    /// <summary>Gets all products.</summary>

    /// <returns>The list of products.</returns>

    public IEnumerable<Movie> GetAll()

    {

        return GetAllCore();

    }



    /// <summary>Removes a product.</summary>

    /// <param name="id">The product ID.</param>

    public void Remove( int id )

    {

        //TODO: Return an error if id <= 0



        if (id > 0)

        {

            RemoveCore(id);

        };

    }



    /// <summary>Edits an existing product.</summary>

    /// <param name="movie">The product to update.</param>

    /// <param name="message">Error message.</param>

    /// <returns>The updated product.</returns>

    /// <remarks>

    /// Returns an error if product is null, invalid, product name

    /// already exists or if the product cannot be found.

    /// </remarks>

    public Movie Update( Movie movie, out string message )

    {

        message = "";



        //Check for null

        if (movie == null)

        {

            message = "Product cannot be null.";

            return null;

        };



        //Validate product using IValidatableObject

        //var error = product.Validate();

        var errors = ObjectValidator.Validate(movie);

        if (errors.Count() > 0)

        {

            //Get first error

            message = errors.ElementAt(0).ErrorMessage;

            return null;

        };



        // Verify unique product

        var existing = GetMovieByTitleCore(movie.Title);

        if (existing != null && existing.Id != movie.Id)

        {

            message = "Movie already exists.";

            return null;

        };



        //Find existing

        existing = existing ?? GetCore(movie.Id);

        if (existing == null)

        {

            message = "Movie not found.";

            return null;

        };



        return UpdateCore(movie);

    }



    protected abstract Movie AddCore( Movie movie );

    protected abstract IEnumerable<Movie> GetAllCore();

    protected abstract Movie GetCore( int id );

    protected abstract void RemoveCore( int id );

    protected abstract Movie UpdateCore( Movie movie );

    protected abstract Movie GetMovieByTitleCore( string title );

}

}
