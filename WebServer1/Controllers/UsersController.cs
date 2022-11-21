using AutoMapper;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebServer1.Models;

namespace WebServer1.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IDataService _dataService;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _generator;

        public UsersController(IDataService dataService, IMapper mapper, LinkGenerator generator)
        {
            _dataService = dataService;
            _mapper = mapper;
            _generator = generator;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser(RegisterUserModel model)
        {
            var user = _mapper.Map<User>(model);

            _dataService.RegisterUser(user.Name, user.email, user.passwordHash);

            return Ok("created");
        }

        [HttpPost("login")]
        public IActionResult Login(RegisterUserModel model)
        {
            var user = _mapper.Map<User>(model);

            var user1 =  _dataService.Login(user.email, user.passwordHash);

            if (user1 == null)
            {
                return NotFound();
            }
            return Ok(user1);
        }

        [HttpGet("bookmarks/all/{id}")]
        public IActionResult GetUsersBookmarks(int id)
        {
            var bookmarks =
                _dataService.GetBookmarks(id).Select(x => CreateBookmarkModel(x));
            if (bookmarks == null)
            {
                return NotFound();
            }
            return Ok(bookmarks);
        }

        [HttpGet("bookmarks/{id}", Name =nameof(GetspecificUserBookmark))]
        public IActionResult GetspecificUserBookmark(int id)
        {
            var bookmark =
                _dataService.GetSpecificBookmark(id);

            if (bookmark == null)
            {
                return NotFound();
            }

            var model = CreateBookmarkModel(bookmark);

            return Ok(model);
        }

        [HttpPost("bookmarks")]
        public IActionResult CreateBookmark(BookmarkCreateModel model)
        {
            var bookmark = _mapper.Map<BookmarkModel>(model);

            _dataService.CreateBookmark(bookmark.UserId, bookmark.MovieId);

            return Ok("created");
        }

        [HttpGet("history/all/{id}")]
        public IActionResult GetUsersHistory(int id)
        {
            var history =
                _dataService.GetSearchHistory(id).Select(x => CreateSearchHistoryModel(x));
            if (history == null)
            {
                return NotFound();
            }
            return Ok(history);
        }

        [HttpGet("history/{id}", Name =nameof(GetSpecificUserHistory))]
        public IActionResult GetSpecificUserHistory(int id)
        {
            var history =
                _dataService.GetSpecificSearchHistory(id);
            if (history == null)
            {
                return NotFound();
            }

            var model = CreateSearchHistoryModel(history);

            return Ok(model);
        }

        [HttpGet("ratings/{id}")]
        public IActionResult GetUsersRatings(int id)
        {
            var ratings =
                _dataService.GetUserMovieRatings(id);
            if (ratings == null)
            {
                return NotFound();
            }
            return Ok(ratings);
        }

        [HttpPost("ratings")]
        public IActionResult CreateRating(RatingCreateModel model)
        {
            var rating = _mapper.Map<UserMovieRating>(model);

            _dataService.RateMovie(rating.UserId, rating.MovieId, rating.Rating);

            return Ok("created");
        }

        private BookmarkModel CreateBookmarkModel(Bookmark bookmark)
        {
            return new BookmarkModel
            {
                Url = _generator.GetUriByName(HttpContext, nameof(GetspecificUserBookmark), new { bookmark.Id }),
                UserId = bookmark.UserId,
                MovieId = bookmark.MovieId
            };
        }

        private SearchHistoryModel CreateSearchHistoryModel(SearchHistory searchHistory)
        {
            return new SearchHistoryModel
            {
                Url = _generator.GetUriByName(HttpContext, nameof(GetSpecificUserHistory), new { searchHistory.Id }),
                UserId=searchHistory.UserId,
                MovieId=searchHistory.MovieId
            };
        }
    }
}
