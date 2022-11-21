using DataLayer.Models;

namespace DataLayer
{
    public interface IDataService
    {
        User? Login(string email, string password);
        void RegisterUser(string userName, string email, string password);
        List<Movie> GetMovies(int page, int pageSize);
        Movie? GetMovie(string movieId);
        List<Movie> MovieSearchBySubstring(string substring);
        List<Episode> GetAllEpisodes(int page, int pageSize);
        List<NameBasic> getAllActors(int page, int pageSize);
        NameBasic? GetActor(string id);
        List<Movie> GetSimilarMovies(string movieId);
        MovieRating? GetMovieRating(string movieId);
        List<MovieRating> getAllMovieRatings(int page, int pageSize);
        void RateMovie(int userId, string movieId, Double rating);
        List<SearchHistory> GetSearchHistory(int userId);
        void CreateBookmark(int userId, string movieId);
        List<Bookmark> GetBookmarks(int userId);
        Bookmark? GetSpecificBookmark(int id);
        SearchHistory? GetSpecificSearchHistory(int id);
        List<UserMovieRating> GetUserMovieRatings(int userId);
        List<Episode> GetSpecificEpisodes(string parentId);
        Episode GetSpecificEpisode(string id);
    }
}
