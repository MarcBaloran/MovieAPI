using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Builder
{
    public class MetadataBuilder
    {
        private List<Movie> _movies;
        private List<MovieStats> _movieStats;

        public MetadataBuilder(List<Movie> movies, List<MovieStats> movieStats)
        {
            _movies = movies;
            _movieStats = movieStats;
        }

        public List<Movie> Build()
        {
            return _movies;
        }

        public List<MovieStats> BuildMovieStats()
        {
            return _movieStats;
        }

        public static MetadataBuilder GetAllMovies()
        {
            List<Movie> movies = GetMovies();
            return new MetadataBuilder(movies, null);
        }

        public static MetadataBuilder GetAllMovieStats()
        {
            List<Stats> stats = File.ReadAllLines(@"C:\Users\MarcBaloran\source\repos\MovieAPI\Data\stats.csv")
                                          .Skip(1)
                                          .Select(v => MapCsvToMovieStatsObject(v))
                                          .ToList();

            List<Movie> movies = GetMovies();


            var movieStats = movies.Join(stats, arg => arg.MovieId, arg => arg.MovieId,
                        (movie, stats) =>
                         new MovieStats
                        {
                            MovieId = movie.MovieId,
                            Title = movie.Title,
                            Watches = stats.Watches,
                            AverageWatchDurationMs = 0,
                            ReleaseYear = movie.ReleaseYear
                        }).ToList();
  

             return new MetadataBuilder(null, movieStats);
        } 

        private static List<Movie> GetMovies()
        {
            return File.ReadAllLines(@"C:\Users\MarcBaloran\source\repos\MovieAPI\Data\metadata.csv")
                                          .Skip(1)
                                          .Select(v => MapCsvToMovieObject(v))
                                          .ToList();
        }   

        private static Movie MapCsvToMovieObject(string csvLine)
        {
            string[] values = csvLine.Split(',');
            var movie = new Movie();
            movie.MovieId = Convert.ToInt32(values[0]);
            movie.Title = Convert.ToString(values[1]);
            movie.Language = Convert.ToString(values[2]);
            movie.Duration = Convert.ToString(values[3]);
            movie.ReleaseYear = Convert.ToString(values[4]);
            return movie;
        }

        private static Stats MapCsvToMovieStatsObject(string csvLine)
        {
            string[] values = csvLine.Split(',');
            var stats = new Stats();
            stats.MovieId = Convert.ToInt32(values[0]);
            stats.Watches = Convert.ToInt32(values[1]);
            return stats;
        }

    }
}
