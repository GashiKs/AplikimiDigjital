using Microsoft.EntityFrameworkCore;
using AplikimiDigjital.Entities;
using AplikimiDigjital.Models;

namespace AplikimiDigjital.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AplikimiEntity> Aplikimet { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().HasKey(x => x.ID);
            modelBuilder.Entity<AplikimiEntity>().HasKey(x => x.ID);
            modelBuilder.Entity<CommentEntity>().HasKey(x => x.ID);
        }
    }
}
