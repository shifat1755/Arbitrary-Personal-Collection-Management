using Microsoft.EntityFrameworkCore;
using APCM.Models.Entities;

namespace APCM.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<CustomFieldValue> CustomFieldValues { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Tag> hashTags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomFieldValue>()
                    .HasKey(cfv => cfv.Id);
            modelBuilder.Entity<CustomFieldValue>()
                .HasOne<Item>()
                .WithMany(i => i.CustomFieldValues)
                .HasForeignKey(fk => fk.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomField>()
                    .HasKey(cfv => cfv.Id);
            modelBuilder.Entity<CustomField>()
                .HasOne<Collection>()
                .WithMany(i => i.CustomFields)
                .HasForeignKey(cf => cf.CollectionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Collection>()
                .HasKey(cfv => cfv.Id);
            modelBuilder.Entity<Collection>()
                .HasOne<User>()
                .WithMany(i => i.Collections)
                .HasForeignKey(cf => cf.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Item>()
                .HasKey(cfv => cfv.Id);
            modelBuilder.Entity<Item>()
                .HasOne<Collection>()
                .WithMany(i => i.Items)
                .HasForeignKey(cf => cf.CollectionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Like>()
                .HasKey(cfv => cfv.Id);
            modelBuilder.Entity<Like>()
                .HasOne(cf => cf.Item)
                .WithMany(i => i.Likes)
                .HasForeignKey(cf => cf.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasKey(cfv => cfv.Id);
            modelBuilder.Entity<Comment>()
                .HasOne(cf => cf.Item)
                .WithMany(i => i.Comments)
                .HasForeignKey(cf => cf.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
