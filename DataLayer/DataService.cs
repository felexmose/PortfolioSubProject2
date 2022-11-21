using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DataService : IDataService
    {
        private readonly IMDBContext _db;
        public DataService()
        {
            this._db = new IMDBContext();
        }

        public void CreateBookmark(int userId, string movieId)
        {
            try
            {
                Bookmark bookmark = new Bookmark() {UserId = userId, MovieId = movieId  };
                _db.Bookmarks.Add(bookmark);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public NameBasic? GetActor(string id)
        {
            var actor = _db.NameBasics.Where(a => a.Id == id).FirstOrDefault();
            if(actor == null)
            {
                return null;
            }
            return actor;
        }

        public List<NameBasic> getAllActors(int page, int pageSize)
        {
            return _db.NameBasics
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public List<MovieRating> getAllMovieRatings(int page, int pageSize)
        {
            return _db.MovieRatings
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList(); ;
        }

        public List<Bookmark> GetBookmarks(int userId)
        {
            return _db.Bookmarks.Where(x => x.UserId == userId).ToList();
        }

        public List<Episode> GetSpecificEpisodes(string parentId)
        {
            return _db.Episodes.Where(x => x.ParentId == parentId).ToList();
        }

        public List<Episode> GetAllEpisodes(int page, int pageSize)
        {
            return _db.Episodes
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList(); ;
        }

        public Movie? GetMovie(string movieId)
        {
            var movie = _db.Movies.Where(x => x.Id == movieId).FirstOrDefault();
            if(movie == null)
            {
                return null;
            }
            return movie;
        }

        public MovieRating? GetMovieRating(string movieId)
        {
            var movieRating = _db.MovieRatings.Where(x => x.Id == movieId).FirstOrDefault();
            if (movieRating == null) { return null; }
            return movieRating;                     
        }

        public List<Movie> GetMovies(int page, int pageSize)
        {
            return _db.Movies
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList(); ;
        }

        public List<SearchHistory> GetSearchHistory(int userId)
        {
           return _db.SearchHistory.Where(x => x.UserId == userId).ToList();
        }

        // requires function calling
        public List<Movie> GetSimilarMovies(string movieId)
        {
            //var test = _db.Database.ExecuteSqlInterpolated($"select similar_movies({movieId})");
            throw new NotImplementedException();
        }

        public Bookmark? GetSpecificBookmark(int id)
        {
            return _db.Bookmarks.Where(x => x.Id == id).FirstOrDefault();
        }

        public SearchHistory? GetSpecificSearchHistory(int id)
        {
            return _db.SearchHistory.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<UserMovieRating> GetUserMovieRatings(int userId)
        {
            return _db.UserMovieRatings.Where(x => x.UserId == userId).ToList();
        }

        public User? Login(string email, string password)
        {
                var user = _db.Users.Where(x => x.email == email && x.passwordHash == password).FirstOrDefault();
                if (user == null)
                {
                    return null;
                }
                return user;         
        }

        // consider applying the sql function, inorder to save the search history aswell.
        public List<Movie> MovieSearchBySubstring(string substring)
        {
            return _db.Movies.Where(x => x.OriginalTitle.Contains(substring)).ToList();

        }

        // consider applying the rate Function/procedure to recalcuate the overall movie rating table.
        public void RateMovie(int userId, string movieId, Double rating)
        {
            try
            {
                var movieRating = new UserMovieRating() { UserId = userId, MovieId = movieId, Rating = rating };
                _db.UserMovieRatings.Add(movieRating);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RegisterUser( string userName, string email, string password)
        {
            try
            {
                // hash password
                var user = new User() { Name = userName, email = email, passwordHash = password };
                _db.Users.Add(user);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public Episode? GetSpecificEpisode(string id)
        {
            return _db.Episodes.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
