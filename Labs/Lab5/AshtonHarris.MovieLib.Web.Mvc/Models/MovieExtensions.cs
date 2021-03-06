﻿////////////////
////Ashton Harris
////ITSE 1430
////Lab5
///////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AshtonHarris.MovieLib.Web.Mvc.Models;

namespace AshtonHarris.MovieLib.Web.Mvc.Models
{
    public static class MovieExtensions

    {

        public static MovieViewModel ToModel( this Movie source )

                    => new MovieViewModel() {

                        Id = source.Id,

                        Title = source.Title,

                        Description = source.Description,

                        IsOwned = source.IsOwned,

                        Length = source.Length

                    };



        public static Movie ToDomain( this MovieViewModel source )

                    => new Movie() {

                        Id = source.Id,

                        Title = source.Title,

                        Description = source.Description,

                        IsOwned = source.IsOwned,

                        Length = source.Length

                    };

    }

}