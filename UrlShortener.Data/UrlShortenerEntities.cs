using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using UrlShortener.Model.Models;

namespace UrlShortener.Data
{
    public class UrlShortenerEntities : DbContext
    {
        public UrlShortenerEntities(String connectionString = "UrlShortererEntities")
            : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Link> Links { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Link>().Property(link => link.Short)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UIX_Links_Short") { IsUnique = true }));

            modelBuilder.Entity<Link>().Property(link => link.Original)
                .HasMaxLength(500)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UIX_Links_Original") { IsUnique = true }));

            modelBuilder.Entity<Link>().HasMany(link => link.AppUsers).WithMany(appUser => appUser.Links);

            modelBuilder.Entity<AppUser>().Property(appUser=>appUser.Identity)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UIX_AppUsers_Identity") { IsUnique = true }));
        }
    }
}
