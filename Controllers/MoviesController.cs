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
    public class MoviesController : Controller
    {
        private readonly IMetadataRepository _metadataRepository;
        public MoviesController(IMetadataRepository metadataRepository)
        {
            _metadataRepository = metadataRepository;
        }

        [HttpGet("stats")]
        public IEnumerable<MovieStats> Get()
        {
            return _metadataRepository.GetAllMovieStats();
        }
    }
}
