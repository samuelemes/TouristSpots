using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Entities.Security;

namespace TouristSpotsData
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options)
        //    : base(options)
        //{
        //}
        //public static AppDbContext Create()
        //{
        //    return new AppDbContext();
        //}

 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|TouristSpot.mdf;Initial Catalog=TouristSpot;Integrated Security=True; MultipleActiveResultSets=true");
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<FavoriteTouristSpot> FavoriteTouristSpot { get; set; }
        public DbSet<TouristSpot> TouristSpot { get; set; }
        public DbSet<TouristSpotPhoto> TouristSpotPhoto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Initial Categories are "Park", "Museum", "Theater", "Monument"
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Nome = "Park" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Nome = "Museum" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Nome = "Theater" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 4, Nome = "Monument" });
            #endregion

            #region Usuario Administrador
            modelBuilder.Entity<AppUser>().HasData(new AppUser { Id = 1, IsAdmin = true, UserName = "samuelemes" });
            #endregion






            base.OnModelCreating(modelBuilder);


        }

        
    }
}
