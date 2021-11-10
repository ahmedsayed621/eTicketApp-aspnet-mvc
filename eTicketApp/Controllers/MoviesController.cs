using eTicketApp.Data;
using eTicketApp.Data.Services;
using eTicketApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _sevice;
        public MoviesController(IMoviesService service)
        {
            _sevice = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _sevice.GetAllAsync(n=>n.Cinema);
            return View(allMovies);
        }

        //Filter
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _sevice.GetAllAsync(n => n.Cinema);
            if(!string.IsNullOrEmpty(searchString))
            {
                var filterResult = allMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filterResult);
            }
            return View("Index", allMovies);
        }

        //Get: Movies/Details/1 
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _sevice.GetMovieByIdAsync(id);
            return View(movieDetails);
        }


        //Get: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropDownData = await _sevice.GetNewMovieDropDownsValues();
            ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas,"Id" ,"Name");
            ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if(!ModelState.IsValid)
            {
                var movieDropDownData = await _sevice.GetNewMovieDropDownsValues();
                ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");

                return View(movie);
            }
            await _sevice.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
        //Get Edit
        public async Task<IActionResult> Edit( int id)
        {
            var movieDetails = await _sevice.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("Empty");
            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageURL = movieDetails.ImageURL,
                CinemaId = movieDetails.CinemaId,
                MovieCategory = movieDetails.MovieCategory,
                ProducerId = movieDetails.ProducerId,
                StartDate=movieDetails.StartDate,
                EndDate=movieDetails.EndDate,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList()


            };



            var movieDropDownData = await _sevice.GetNewMovieDropDownsValues();
            ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( int id, NewMovieVM movie)
        {

            if (id != movie.Id) return View("Empty");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _sevice.GetNewMovieDropDownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _sevice.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));

        }
    }
}
