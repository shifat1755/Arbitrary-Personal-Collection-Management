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
        public DbSet<CustomFieldValue>CustomFIeldValues { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<HashTag> hashTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomField>()
                .HasOne<Collection>()
                .WithMany(c=>c.CustomFields)
                .HasForeignKey(cf=>cf.CollectionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Item>()
                .HasOne<Collection>()
                .WithMany(i => i.Items)
                .HasForeignKey(k => k.CollectionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomFieldValue>()
                .HasOne<CustomField>()
                .WithMany()
                .HasForeignKey(c => c.CustomFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomFieldValue>()
                .HasOne<Item>()
                .WithMany(c=>c.CustomFieldValues)
                .HasForeignKey(cf=>cf.ItemId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Collection>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c=>c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}
