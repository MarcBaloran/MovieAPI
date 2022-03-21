using MovieAPI.Builder;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Repositories
{
    public interface IMetadataRepository
    {
        List<MovieStats> GetAllMovieStats();
        List<Movie> GetAllMovieById(int id);
        List<Movie> AddMovie(Movie movie);
    }
    public class MetadataRepository : IMetadataRepository
    {
        public List<Movie> AddMovie(Movie movie)
        {
            var movieList = MetadataBuilder.GetAllMovies().Build();
            movieList.Add(movie);
            return movieList;
        }

        public List<Movie> GetAllMovieById(int id)
        {
            return MetadataBuilder.GetAllMovies().Build().Where(m => m.MovieId == id).ToList();
        }

        public List<MovieStats> GetAllMovieStats()
        {
            return MetadataBuilder.GetAllMovieStats().BuildMovieStats();
        }
    }
}
