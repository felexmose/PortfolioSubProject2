using DataLayer;
using DataLayer.Models;

namespace Assignment4.Tests
{
    public class DataServiceTests
    {
        /* tests*/
        [Fact]
        public void Actor_Object_HasIdPrimaryNameBirthyearDeathyearPrimaryprofessions()
        {
            var actor = new NameBasic();
            Assert.Null(actor.Id);
            Assert.Null(actor.PrimaryName);
            Assert.Null(actor.BirthYear);
            Assert.Null(actor.DeathYear);
            Assert.Null(actor.PrimaryProfessions);
        }

        [Fact]
        public void MovieRating_Object_HasIdAverageRatingVotes()
        {
            var movieRating = new MovieRating();
            Assert.Null(movieRating.Id);
            Assert.Equal(0, movieRating.AverageRating);
            Assert.Equal(0, movieRating.Votes);            
        }

        [Fact]
        public void Bookmark_Object_HasIdUseridMovieId()
        {
            var bookmark = new Bookmark();            
            Assert.Null( bookmark.Id);
            Assert.Equal(0, bookmark.UserId);
            Assert.Null(bookmark.MovieId);
        }

        [Fact]
        public void Episode_Object_HasIdParentIdSeasonNumberEpisodeNumber()
        {
            var episode = new Episode();
            Assert.Null(episode.Id);
            Assert.Null(episode.ParentId);
            Assert.Null(episode.SeasonNumber);
            Assert.Null(episode.EpisodeNumber);
        }

        [Fact]
        public void Movie_Object_HasIdTypePrimaryTitleOriginalTitleIsAdultStartYearEndYearRunTimeMinutesGenres()
        {
            var movie = new Movie();
            Assert.Null(movie.Id);
            Assert.Null(movie.Type);
            Assert.Null(movie.PrimaryTitle);
            Assert.Null(movie.OriginalTitle);
            Assert.False(movie.IsAdult);
            Assert.Null(movie.StartYear);
            Assert.Null(movie.EndYear);
            Assert.Null(movie.RunTimeMinutes);
            Assert.Null(movie.Genres);
        }

        [Fact]
        public void SearchHistory_Object_HasIdUserIdMovieId()
        {
            var searchHistory = new SearchHistory();
            Assert.Equal(0,searchHistory.Id);
            Assert.Equal(0, searchHistory.UserId);
            Assert.Null(searchHistory.MovieId);
        }

        [Fact]
        public void UserMovieRating_Object_HasIdUserIdMovieIdRating()
        {
            var userMovieRating = new UserMovieRating();
            Assert.Null(userMovieRating.Id);
            Assert.Equal(0, userMovieRating.UserId);
            Assert.Null(userMovieRating.MovieId);
            Assert.Equal(0, userMovieRating.Rating);
        }

        [Fact]
        public void User_Object_HasIdNameEmailPassword()
        {
            var user = new User();
            Assert.Null(user.Id);
            Assert.Null(user.Name);
            Assert.Null(user.email);
            Assert.Null(user.passwordHash);
        }

        [Fact]
        public void GetActor_ValidId_ReturnsActorObject()
        {
            var service = new DataService();
            var actor = service.GetActor("nm0015623");
            Assert.Equal("1977", actor!.BirthYear);
        }

        [Fact]
        public void GetMovie_ValidId_ReturnsActorObject()
        {
            var service = new DataService();
            var movie = service.GetMovie("tt8769260");
            Assert.Equal("2019", movie!.EndYear);
        }

        [Fact]
        public void GetSpecificEpisode_ValidId_ReturnsActorObject()
        {
            var service = new DataService();
            var episode = service.GetSpecificEpisode("tt0583438");
            Assert.Equal(1, episode!.EpisodeNumber );
        }
    }
}
