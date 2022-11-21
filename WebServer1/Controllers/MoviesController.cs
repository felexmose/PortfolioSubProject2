using AutoMapper;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebServer1.Models;

namespace WebServer1.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IDataService _dataService;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _generator;
        private const int MaxPageSize = 25;
        public MoviesController(IDataService dataService, IMapper mapper, LinkGenerator generator)
        {
            _dataService = dataService;
            _mapper = mapper;
            _generator = generator;
        }

        [HttpGet]
        public IActionResult GetAllMovies(int page = 0, int pageSize = 10)
        {
            pageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;
            var movies =
                _dataService.GetMovies(page,pageSize).ToList().Select(x => CreateMovieModel(x));

            return Ok(movies);
        }

        [HttpGet("{id}", Name = nameof(GetMovieId))]
        public IActionResult GetMovieId(string id)
        {
            var movie =
                _dataService.GetMovie(id);

            if (movie == null)
            {
                return NotFound();
            }

            MovieModel model = CreateMovieModel(movie);

            return Ok(model);
        }
        

        [HttpGet("substring/{id}")]
        public IActionResult GetMovieBySubstring(string id)
        {
            var movies = _dataService.MovieSearchBySubstring(id).ToList().Select(x => CreateMovieModel(x));
            
            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movies);
        }

        [HttpGet("episodes")]
        public IActionResult GetAllEpisodes(int page = 0, int pageSize = 10)
        {
            pageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;
            var episodes =
                _dataService.GetAllEpisodes(page,pageSize).ToList().Select(x => CreateEpisodeModel(x));

            return Ok(episodes);
        }

        [HttpGet("episodes/parent/{id}")]
        public IActionResult GetSpecificEpisodes(string id)
        {
            var episode =
                _dataService.GetSpecificEpisodes(id).Select(x => CreateEpisodeModel(x));

            if (episode == null)
            {
                return NotFound();
            }          

            return Ok(episode);
        }

        [HttpGet("episodes/{id}", Name =nameof(GetSpecificEpisode))]
        public IActionResult GetSpecificEpisode(string id)
        {
            var episode =
                _dataService.GetSpecificEpisode(id);

            if (episode == null)
            {
                return NotFound();
            }

            var model = CreateEpisodeModel(episode);

            return Ok(model);
        }

        [HttpGet("ratings")]
        public IActionResult GetAllMovieRatings(int page = 0, int pageSize = 10)
        {
            pageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;
            var ratings =
                _dataService.getAllMovieRatings(page,pageSize).ToList().Select(x => CreateMovieRatingModel(x));

            return Ok(ratings);
        }

        [HttpGet("ratings/{id}", Name = nameof(GetSpecificMovieRating))]
        public IActionResult GetSpecificMovieRating(string id)
        {
            var rating =
                _dataService.GetMovieRating(id);

            if (rating == null)
            {
                return NotFound();
            }

            var model = CreateMovieRatingModel(rating);

            return Ok(model);
        }

        private MovieRatingModel CreateMovieRatingModel(MovieRating movieRating)
        {
            return new MovieRatingModel
            {
                Url = _generator.GetUriByName(HttpContext, nameof(GetSpecificMovieRating), new { movieRating.Id }),
                AverageRating = movieRating.AverageRating,
                Votes = movieRating.Votes
            };
        }

        private MovieModel CreateMovieModel(Movie? movie)
        {
            return new MovieModel
            {
                Url = _generator.GetUriByName(HttpContext, nameof(GetMovieId), new { movie.Id }),
                Type = movie.Type,
                PrimaryTitle = movie.PrimaryTitle,
                OriginalTitle = movie.OriginalTitle,
                IsAdult = movie.IsAdult,
                StartYear = movie.StartYear,
                EndYear = movie.EndYear,
                RunTimeMinutes = movie.RunTimeMinutes,
                Genres = movie.Genres
            };
        }

        private EpisodeModel CreateEpisodeModel(Episode episode)
        {
            return new EpisodeModel
            {
                Url = _generator.GetUriByName(HttpContext, nameof(GetSpecificEpisode), new { episode.Id }),
                ParentId = episode.ParentId,
                SeasonNumber = episode.SeasonNumber,
                EpisodeNumber = episode.EpisodeNumber
            };
        }
    }
}
