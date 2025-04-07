using System.Security.Cryptography;
using Digital_queueAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Digital_queueAPI.DAL {
    public class AppDbContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<QueueEntry> QueueEntries { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            //primary keys
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Notification>()
                .HasKey(n => n.NotificationId);

            modelBuilder.Entity<Queue>()
                .HasKey(q => q.QueueId);

            modelBuilder.Entity<QueueEntry>()
                .HasKey(q => q.EntryId);

            //User (Customer) -> QueueEntries
            modelBuilder.Entity<QueueEntry>()
                .HasOne(qe => qe.User)
                .WithMany(u => u.QueueEntries)
                .HasForeignKey(qe => qe.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Queue -> QueueEntries
            modelBuilder.Entity<QueueEntry>()
                .HasOne(qe => qe.Queue)
                .WithMany(q => q.QueueEntries)
                .HasForeignKey(qe => qe.QueueId)
                .OnDelete(DeleteBehavior.Cascade);

            // QueueEntry -> Notifications
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.QueueEntry)
                .WithMany(qe => qe.Notifications)
                .HasForeignKey(n => n.EntryId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> Notifications
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //property constraints
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Queue>()
                .Property(q => q.QueueName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Queue>()
                .Property(q => q.Location)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<QueueEntry>()
                .Property(qe => qe.Position)
                .IsRequired();

            modelBuilder.Entity<Notification>()
                .Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
