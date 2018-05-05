////////////////
////Ashton Harris
////ITSE 1430
////Lab5
///////////////
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AshtonHarris.MovieLib;
using AshtonHarris.MovieLib.Data;
using AshtonHarris.MovieLib.Data.Sql;
using AshtonHarris.MovieLib.Web.Mvc.Models;

namespace AshtonHarris.MovieLib.Web.Mvc.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesController()

        {

            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"];

            _database = new SqlMovieDatabase(connString.ConnectionString);

        }

        private readonly IMovieDatabase _database;



        [HttpGet]

        public ActionResult Index()

        {

            var movies = _database.GetAll();
           return View(movies.Select(m => m.ToModel()));

        }

        [HttpGet]

        public ActionResult Create()

        {
          return View(new MovieViewModel());
        }



        [HttpPost]

        public ActionResult Create( MovieViewModel model )

        {

            try

            {

                if (ModelState.IsValid)

                {

                    var movie = model.ToDomain();

                    movie = _database.Add(movie);

                    return RedirectToAction(nameof(Index));

                };

            } catch (Exception e)

            {

                ModelState.AddModelError("", e.Message);

            };



            return View(model);

        }



        [HttpGet]

        public ActionResult Edit( int id )

        {

            var movie = _database.GetAll()

                                    .FirstOrDefault(p => p.Id == id);

            if (movie == null)

                return HttpNotFound();



            return View(movie.ToModel());

        }



        [HttpPost]

        public ActionResult Edit( MovieViewModel model )

        {

            try

            {

                if (ModelState.IsValid)

                {

                    var movie = model.ToDomain();



                    movie = _database.Update(movie);



                    return RedirectToAction("List");

                };

            } catch (Exception e)

            {

                ModelState.AddModelError("", e.Message);

            };



            return View(model);

        }



        [HttpGet]

        [Route("movies/delete/{id}")]

        public ActionResult Delete( int id )

        {

            var movie = _database.GetAll()

                                    .FirstOrDefault(p => p.Id == id);

            if (movie == null)

                return HttpNotFound();



            return View(movie.ToModel());

        }



        [HttpPost]

        public ActionResult Delete( MovieViewModel model )

        {

            try

            {

                var movie = _database.GetAll()

                                        .FirstOrDefault(p => p.Id == model.Id);

                if (movie == null)

                    return HttpNotFound();

                 _database.Remove(model.Id);

             return RedirectToAction(nameof(Index));

            } catch (Exception e)

            {

                ModelState.AddModelError("", e.Message);

            };



            return View(model);

        }

    }

}
    

