using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Entities.Security;

namespace TouristSpotsData
{
    //public class AppDbContext : IdentityUserContext<AppUser, int, AppUserClaim,AppUserLogin, AppUserToken>
    public class AppDbContext : DbContext
        //IdentityDbContext<AppUser, AppRole, int
        //, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken
        //>
    //public class AppDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
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
        public DbSet<AppUser> Usuario { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region CONFIGURAÇÃO IDENTITY CUSTOM
                //var maxKeyLength = 255;
                //modelBuilder.Entity<AppUser>(b =>
                //{
                //    // Primary key
                //    b.HasKey(u => u.Id);

                //    // Indexes for "normalized" username and email, to allow efficient lookups
                //    b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
                //    b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

                //    // Maps to the AspNetUsers table
                //    b.ToTable("AspNetUsers");

                //    // A concurrency token for use with the optimistic concurrency checking
                //    b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

                //    // Limit the size of columns to use efficient database types
                //    b.Property(u => u.UserName).HasMaxLength(256);
                //    b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                //    b.Property(u => u.Email).HasMaxLength(256);
                //    b.Property(u => u.NormalizedEmail).HasMaxLength(256);

                //    // The relationships between User and other entity types
                //    // Note that these relationships are configured with no navigation properties

                //    // Each User can have many UserClaims
                //    b.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

                //    // Each User can have many UserLogins
                //    b.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

                //    // Each User can have many UserTokens
                //    b.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

                //    // Each User can have many entries in the UserRole join table
                //    b.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
                //});

                //modelBuilder.Entity<AppUserClaim>(b =>
                //{
                //    // Primary key
                //    b.HasKey(uc => uc.Id);

                //    // Maps to the AspNetUserClaims table
                //    b.ToTable("AspNetUserClaims");
                //});

                //modelBuilder.Entity<AppUserLogin>(b =>
                //{
                //    // Composite primary key consisting of the LoginProvider and the key to use
                //    // with that provider
                //    b.HasKey(l => new { l.LoginProvider, l.ProviderKey });

                //    // Limit the size of the composite key columns due to common DB restrictions
                //    b.Property(l => l.LoginProvider).HasMaxLength(128);
                //    b.Property(l => l.ProviderKey).HasMaxLength(128);

                //    // Maps to the AspNetUserLogins table
                //    b.ToTable("AspNetUserLogins");
                //});

                //modelBuilder.Entity<AppUserToken>(b =>
                //{
                //    // Composite primary key consisting of the UserId, LoginProvider and Name
                //    b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

                //    // Limit the size of the composite key columns due to common DB restrictions
                //    b.Property(t => t.LoginProvider).HasMaxLength(maxKeyLength);
                //    b.Property(t => t.Name).HasMaxLength(maxKeyLength);

                //    // Maps to the AspNetUserTokens table
                //    b.ToTable("AspNetUserTokens");
                //});

                //modelBuilder.Entity<AppRole>(b =>
                //{
                //    // Primary key
                //    b.HasKey(r => r.Id);

                //    // Index for "normalized" role name to allow efficient lookups
                //    b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

                //    // Maps to the AspNetRoles table
                //    b.ToTable("AspNetRoles");

                //    // A concurrency token for use with the optimistic concurrency checking
                //    b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

                //    // Limit the size of columns to use efficient database types
                //    b.Property(u => u.Name).HasMaxLength(256);
                //    b.Property(u => u.NormalizedName).HasMaxLength(256);

                //    // The relationships between Role and other entity types
                //    // Note that these relationships are configured with no navigation properties

                //    // Each Role can have many entries in the UserRole join table
                //    b.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

                //    // Each Role can have many associated RoleClaims
                //    b.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
                //});

                //modelBuilder.Entity<AppRoleClaim>(b =>
                //{
                //    // Primary key
                //    b.HasKey(rc => rc.Id);

                //    // Maps to the AspNetRoleClaims table
                //    b.ToTable("AspNetRoleClaims");
                //});

                //modelBuilder.Entity<AppUserRole>(b =>
                //{
                //    // Primary key
                //    b.HasKey(r => new { r.UserId, r.RoleId });

                //    // Maps to the AspNetUserRoles table
                //    b.ToTable("AspNetUserRoles");
                //});

            #endregion CONFIGURE IDENTITY CUSTO KEY



            #region Initial Categories are "Park", "Museum", "Theater", "Monument"
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Nome = "Park" });
                modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Nome = "Museum" });
                modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Nome = "Theater" });
                modelBuilder.Entity<Category>().HasData(new Category { Id = 4, Nome = "Monument" });
            #endregion



            


            base.OnModelCreating(modelBuilder);


        }
    }
}
