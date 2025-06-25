using OneStopBuy.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

//namespace OneStopBuy.Data
//{
   /** public class ApplicationDbContext : IdentityDbContext
    {
       /**  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)

        {
        }
        public DbSet<OneStopBuy.Models.News> News { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Message>()
                .HasOne<AppUser>(a => a.Sender)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.UserID);
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Post> Posts { get; set; }


        public DbSet<Warranty> Warranties { get; set; }
        public DbSet<UserPostLike> UserPostLikes { get; set; }
        public DbSet<Meeting> Meeting { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

    }
}
   */
