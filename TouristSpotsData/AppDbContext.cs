using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Entities.Security;

namespace TouristSpotsData
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        private static DbContextOptions<AppDbContext> _options;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            _options = options;
        }
        public static AppDbContext Create()
        {
            return new AppDbContext(_options);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=D:\users\samue\TOURIST_SPOTS.mdf;Initial Catalog=TOURIST_SPOTS;Integrated Security=True; MultipleActiveResultSets=true");
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<FavoriteTouristSpot> FavoriteTouristSpot { get; set; }
        public DbSet<TouristSpot> TouristSpot { get; set; }
        public DbSet<TouristSpotPhoto> TouristSpotPhoto { get; set; }


        //public DbSet<AppUser> User { get; set; }
        //public DbSet<Role> Role { get; set; }
        //public DbSet<UserClaim> UserClaim { get; set; }
        //public DbSet<UserLogin> UserLogin { get; set; }
        //public DbSet<UserRole> UserRole { get; set; }
        //public DbSet<UserRole> UserToken{ get; set; }
        //public DbSet<UserRole> UserRoleClaim { get; set; }








        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            #region Initial Categories are "Park", "Museum", "Theater", "Monument"
                modelBuilder.Entity<Category>().HasData(new Category { id = 1, Nome = "Park" });
                modelBuilder.Entity<Category>().HasData(new Category { id = 2, Nome = "Museum" });
                modelBuilder.Entity<Category>().HasData(new Category { id = 3, Nome = "Theater" });
                modelBuilder.Entity<Category>().HasData(new Category { id = 4, Nome = "Monument" });
            #endregion



            //modelBuilder.Entity<Role>().HasKey(r => new { r.Id });
            //modelBuilder.Entity<AppUser>().HasKey(r => new { r.Id });
            //modelBuilder.Entity<UserRole>().HasKey(r => new { r.UserId, r.RoleId });
            //modelBuilder.Entity<UserClaim>().HasKey(r => new { r.UserId });
            //modelBuilder.Entity<UserLogin>().HasKey(l => new { l.UserId });



            base.OnModelCreating(modelBuilder);


        }
    }
}
