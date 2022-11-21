using DataLayer;

var ds = new DataService();

var movies = ds.GetMovies();
//ds.RegisterUser("Richie", "richie@yahoo.com","45632");
//var userRatings = ds.GetUserMovieRatings(1);

//ds.RateMovie(234,"tt8141256 ",4.9);

//var bookmarks = ds.GetBookmarks(1);
//var user = ds.Login("klaus@google.com", "77777");

//var movie = ds.GetMovieRating("tt0088634");

//ds.CreateBookmark(1, "tt0088634");

//ds.RegisterUser(321, "johnny", "johnny@google.com", "77777");




//var users = ds.GetAllUsersAsync();
//var order = ds.GetOrderById(10500);
//var orderByShippingNameList = ds.GetOrderByShippingName("Ernst Handel");
//var productById = ds.GetProductById(3);
//var GetProductsByCategoryId = ds.GetProductsByCategoryId(1);
//var GetAllCategories = ds.GetAllCategories();
//var GetAllOrders = ds.GetAllOrders();

Console.WriteLine($"The movies count: {movies.Count()}");
//Console.WriteLine($"The order date: {order.Date}");
//Console.WriteLine($"The number of orders by shipping name Ernst Handel: {orderByShippingNameList.Count()}");
//Console.WriteLine($"The product by id: {productById.Name}");
//Console.WriteLine($"The number of product by category id 2: {GetProductsByCategoryId.Count()}");
//Console.WriteLine($"The get all categories count: {GetAllCategories.Count()}");
//Console.WriteLine($"The get all orders count: {GetAllOrders.Count()}");