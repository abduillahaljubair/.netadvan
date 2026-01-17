using learningwithos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace learningwithos.Controllers
{
    public class MovieController : Controller
    {

        //attribite routing
        [Route("/movies/list")] 
        public IActionResult MovieList()
        {
            MovieList movie1 = getMovieList();
            return View(movie1);
        }
        [Route("/movies/details/{id=int}")]
        [Route("/movies/{id=int}/{category}")]
        public IActionResult Details(int id,string category)
        {
            MovieList movie1 = getMovieList();

            return Content("the movie name is "+movie1.Name+"with id and category "+id+category);
        }

        public MovieList getMovieList()
        {
            MovieList movie = new MovieList();
            movie.MovieId = 1;
            movie.Name = "Inception";
            return movie;
        }
        public IActionResult redirect()
        {
            return RedirectToAction("MovieList");//function call
        }
        public IActionResult redirect2()
        {
            return RedirectToAction("Index","Home");
            //Home controller er index file e chole jabe 
        
        }

        //direct website ee chole jabe
        public IActionResult redirect3()
        {
            return Redirect("https://www.google.com/");


        }
//        🔹 তাহলে কেন এটা use করা হয়?
//✅ 1. JavaScript / AJAX এ data পাঠাতে

//Page reload না করে data আনতে

//✅ 2. API বানাতে

//Frontend(HTML/JS/React) ↔ Backend(C#) এর মধ্যে data exchange

//✅ 3. Dynamic data দেখাতে

//Database থেকে data এনে page-এ দেখাতে
        public JsonResult getData()
        {
            return Json(new { Name = "abdullah", Age = 24 });
        }
        public FileResult GetFile()
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "download.jpg");
            var filebytes = System.IO.File.ReadAllBytes(filepath);
            return File(filebytes, "image/jpg", "download.jpg");
        }
        [Route("/movies/save")]

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save1(MovieList m1)
        {
            if (!ModelState.IsValid)
                return View(m1);

            // save...
            return RedirectToAction("List");
        }



    }
}
