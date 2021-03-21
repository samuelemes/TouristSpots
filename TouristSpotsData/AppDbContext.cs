using Microsoft.EntityFrameworkCore;
using TouristSpotsDomain.Entities;

namespace TouristSpotsData
{
    public class AppDbContext : DbContext
    {
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=D:\users\samue\TOURIST_SPOTS.mdf;Initial Catalog=TOURIST_SPOTS;Integrated Security=True; MultipleActiveResultSets=true");
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<FavoriteTouristSpot> FavoriteTouristSpot { get; set; }
        public DbSet<TouristSpot> TouristSpot { get; set; }
        public DbSet<TouristSpotPhoto> TouristSpotPhoto { get; set; }
        public DbSet<User> User { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            #region Initial Categories are "Park", "Museum", "Theater", "Monument"
                modelBuilder.Entity<Category>().HasData(new Category { id = 1, Nome = "Park" });
                modelBuilder.Entity<Category>().HasData(new Category { id = 2, Nome = "Museum" });
                modelBuilder.Entity<Category>().HasData(new Category { id = 3, Nome = "Theater" });
                modelBuilder.Entity<Category>().HasData(new Category { id = 4, Nome = "Monument" });
            #endregion
        
        
        
        }

    }
}
