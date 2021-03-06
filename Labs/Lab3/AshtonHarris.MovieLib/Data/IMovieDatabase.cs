﻿/////////////
////Ashton Harris
////ITSE 14340
/////Lab3
////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AshtonHarris.MovieLib.Data
{
    public interface IMovieDatabase
    {
        Movie Add( Movie movie, out string message );
        Movie Update( Movie movie, out string message );
        IEnumerable<Movie> GetAll();
        void Remove( int id );
    }
}