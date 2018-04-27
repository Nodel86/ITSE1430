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

namespace MovieLib.Data.Memory
{  /// <summary>Provides an in-memory product database.</summary>

    public class MemoryMovieDatabase : IMovieDatabase

    {

        protected override Movie AddCore( Movie movie )

        {

            // Clone the object

            movie.Title = _nextTitle++;

            _movie.Add(Clone(movie));



            // Return a copy

            return movie;

        }



        protected override Movie GetCore( int name )

        {

            //for (var index = 0; index < _movie.Length; ++index)

            foreach (var movie in _movie)

            {

                string Title = null;
                if (movie.Title == Title)

                    return movie;

            };



            return null;

        }



        protected override IEnumerable<Movie> GetAllCore()

        {

            //Iterator syntax

            foreach (var movie in _movie)

            {

                if (movie != null)

                    yield return Clone(movie);

            };

        }



        protected override void RemoveCore( int Title )

        {

            var existing = GetCore(Title);

            if (existing != null)

                _movie.Remove(existing);

        }



        protected override Movie UpdateCore( Movie movie )

        {

            var existing = GetCore(movie.Title);



            // Clone the object

            Copy(existing, movie);



            return movie;

        }

        private void Copy( object existing, Movie movie )
        {
            throw new NotImplementedException();
        }

        private object GetCore( string title )
        {
            throw new NotImplementedException();
        }

        protected override Movie GetMovieByTitleCore( string Title )

        {

            foreach (var movie in _movie)

            {

                string title = null;
                if (String.Compare(movie.Title, title, true) == 0)

                    return movie;

            };



            return null;

        }



        #region Private Members



        //Clone a movie

        private Movie Clone( Movie item )

        {

            var newMovie = new Movie();

            Copy(newMovie, item);



            return newMovie;

        }



        //Copy a product from one object to another

        private void Copy( Movie target, Movie source )

        {

            target.Title = source.Title;

            target.Description = source.Description;

            target.Length = source.Length;

            target.IsOwned = source.IsOwned;

        }

        Movie IMovieDatabase.Add( Movie movie )
        {
            throw new NotImplementedException();
        }

        IEnumerable<Movie> IMovieDatabase.GetAll()
        {
            throw new NotImplementedException();
        }

        void IMovieDatabase.Remove( int id )
        {
            throw new NotImplementedException();
        }

        Movie IMovieDatabase.Update( Movie movie )
        {
            throw new NotImplementedException();
        }

        void IMovieDatabase.Add( Movie movie, out object message )
        {
            throw new NotImplementedException();
        }

        void IMovieDatabase.Update( Movie movie, out object message )
        {
            throw new NotImplementedException();
        }

        void IMovieDatabase.Remove( object id )
        {
            throw new NotImplementedException();
        }

        private readonly List<Movie> _movie = new List<Movie>();

        private int _nextId = 1;



        #endregion

    }

}

