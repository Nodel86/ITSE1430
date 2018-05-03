using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AshtonHarris.MovieLib.Data
{
    public interface IMovieDatabase
    {
        Movie Add( Movie movie  );
        Movie Update( Movie movie);
        IEnumerable<Movie> GetAll();
        void Remove( int id );
    }
}