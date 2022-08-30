using DevopsProject_1.DbContexts;
using DevopsProject_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace DevopsProject_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private ApplicationDbContext _db;
        public MoviesController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _db.Movies;
        }
        [HttpPost]
        public IActionResult Post(Movie movie)
        {
            if (movie != null)
            {
                var guid = Guid.NewGuid();
                var filepath = Path.Combine("wwwroot",guid + ".jpg");
                if(movie.Image!=null){
                FileStream fs= new FileStream(filepath, FileMode.Create);
                    movie.Image.CopyTo(fs);
                }
                _db.Movies.Add(movie);
                _db.SaveChanges();
                return Ok(movie);
            }
            else
                return StatusCode(404);
        
        }
        [HttpPut]
        public IActionResult Put(int id,Movie movies)
        {
             var movie=_db.Movies.Find(id); 
            if (movie != null)
            {
                var guid = Guid.NewGuid();
                var filepath = Path.Combine("wwwroot", guid + ".jpg");
                if (movie.Image != null)
                {
                    FileStream fs = new FileStream(filepath, FileMode.Create);
                    movie.Image.CopyTo(fs);
                    movie.Imageurl = filepath;
                }
                _db.Movies.Add(movie);
                _db.SaveChanges();
                return Ok(movie);
            }
            else
                return StatusCode(404);
        }
        public void Delete(int id)
        { 
            var movies=_db.Movies.Find(id);
            _db.Movies.Remove(movies);

        }
    }
}
