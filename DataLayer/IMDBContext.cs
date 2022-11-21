using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataLayer
{
    public class IMDBContext : DbContext
    {
        const string ConnectionString = "host=localhost;db=postgres;uid=postgres;pwd=23278320";
        //private readonly string _connectionString;
        //public IMDBContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieRating> MovieRatings { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<UserMovieRating> UserMovieRatings { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<NameBasic> NameBasics { get; set; }        
        //public DbSet<OmdData> OmdDatas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.UseNpgsql(ConnectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderDetails>().HasKey(am => new
            //{
            //    am.OrderId,
            //    am.ProductId,
            //});

            //modelBuilder.Entity<OrderDetails>().HasOne(m => m.Product)
            //.WithMany(am => am.).HasForeignKey(m => m.ProductId);

            //modelBuilder.Entity<OrderDetails>().HasOne(a => a.Order)
            //.WithMany(at => at.Product_Orders).HasForeignKey(a => a.OrderId);

            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnName("userid");
            modelBuilder.Entity<User>().Property(x => x.Name).HasColumnName("user_name");
            modelBuilder.Entity<User>().Property(x => x.email).HasColumnName("email");
            modelBuilder.Entity<User>().Property(x => x.passwordHash).HasColumnName("password1");

            modelBuilder.Entity<Movie>().ToTable("title_basics");
            modelBuilder.Entity<Movie>().Property(x => x.Id).HasColumnName("tconst");
            modelBuilder.Entity<Movie>().Property(x => x.Type).HasColumnName("titletype");
            modelBuilder.Entity<Movie>().Property(x => x.PrimaryTitle).HasColumnName("primarytitle");
            modelBuilder.Entity<Movie>().Property(x => x.OriginalTitle).HasColumnName("originaltitle");
            modelBuilder.Entity<Movie>().Property(x => x.IsAdult).HasColumnName("isadult");
            modelBuilder.Entity<Movie>().Property(x => x.StartYear).HasColumnName("startyear");
            modelBuilder.Entity<Movie>().Property(x => x.EndYear).HasColumnName("endyear");
            modelBuilder.Entity<Movie>().Property(x => x.RunTimeMinutes).HasColumnName("runtimeminutes");
            modelBuilder.Entity<Movie>().Property(x => x.Genres).HasColumnName("genres");

            modelBuilder.Entity<MovieRating>().ToTable("title_ratings");
            modelBuilder.Entity<MovieRating>().Property(x => x.Id).HasColumnName("tconst");
            modelBuilder.Entity<MovieRating>().Property(x => x.AverageRating).HasColumnName("averagerating");
            modelBuilder.Entity<MovieRating>().Property(x => x.Votes).HasColumnName("numvotes");

            modelBuilder.Entity<Bookmark>().ToTable("bookmarks");
            modelBuilder.Entity<Bookmark>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Bookmark>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<Bookmark>().Property(x => x.MovieId).HasColumnName("tconst");

            modelBuilder.Entity<UserMovieRating>().ToTable("rating");
            modelBuilder.Entity<UserMovieRating>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<UserMovieRating>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<UserMovieRating>().Property(x => x.Rating).HasColumnName("rating");
            modelBuilder.Entity<UserMovieRating>().Property(x => x.MovieId).HasColumnName("tconst");

            modelBuilder.Entity<SearchHistory>().ToTable("search_history");
            modelBuilder.Entity<SearchHistory>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<SearchHistory>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<SearchHistory>().Property(x => x.MovieId).HasColumnName("tconst");

            modelBuilder.Entity<Episode>().ToTable("title_episode");
            modelBuilder.Entity<Episode>().Property(x => x.Id).HasColumnName("tconst");
            modelBuilder.Entity<Episode>().Property(x => x.ParentId).HasColumnName("parenttconst");
            modelBuilder.Entity<Episode>().Property(x => x.SeasonNumber).HasColumnName("seasonnumber");
            modelBuilder.Entity<Episode>().Property(x => x.EpisodeNumber).HasColumnName("episodenumber");

            modelBuilder.Entity<NameBasic>().ToTable("name_basics_1");
            modelBuilder.Entity<NameBasic>().Property(x => x.Id).HasColumnName("nconst");
            modelBuilder.Entity<NameBasic>().Property(x => x.PrimaryName).HasColumnName("primaryname");
            modelBuilder.Entity<NameBasic>().Property(x => x.BirthYear).HasColumnName("birthyear");
            modelBuilder.Entity<NameBasic>().Property(x => x.DeathYear).HasColumnName("deathyear");
            modelBuilder.Entity<NameBasic>().Property(x => x.PrimaryProfessions).HasColumnName("primaryprofession");
        }
    }
}
