using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using MovieAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("[controller]")]
    public class MetadataController : Controller
    {
        private readonly IMetadataRepository _metadataRepository;

        public MetadataController(IMetadataRepository metadataRepository)
        {
            _metadataRepository = metadataRepository;
        }

        [HttpGet(":{movieId}")]
        public IEnumerable<Movie> Get([FromRoute] int movieId)
        {
            return _metadataRepository.GetAllMovieById(movieId);
        }


        [HttpPost]
        public ActionResult AddMovie(Movie model)
        {
            Movie movie = new Movie
            {
                MovieId = model.MovieId,
                Title = model.Title,
                Language = model.Language,
                Duration = model.Duration,
                ReleaseYear = model.ReleaseYear
            };

            var result = _metadataRepository.AddMovie(movie);

            return Ok(result);
        }
    }
}
