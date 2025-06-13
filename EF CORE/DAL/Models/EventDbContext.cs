using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public class EventDbContext : DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<EventDetails> EventDetails { get; set; }
        public DbSet<SessionInfo> SessionInfos { get; set; }
        public DbSet<SpeakersDetails> SpeakersDetails { get; set; }
        public DbSet<ParticipantEventDetails> ParticipantEventDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure connection string using helper class
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseHelper.GetConnectionString());
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-Many: EventDetails → SessionInfo
            modelBuilder.Entity<SessionInfo>()
                        .HasOne<EventDetails>()
                        .WithMany()
                        .HasForeignKey(s => s.EventId);

            // Optional Speaker relationship
            modelBuilder.Entity<SessionInfo>()
                        .HasOne<SpeakersDetails>()
                        .WithMany()
                        .HasForeignKey(s => s.SpeakerId)
                        .OnDelete(DeleteBehavior.SetNull);

            // ParticipantEventDetails → UserInfo (FK: ParticipantEmailId)
            modelBuilder.Entity<ParticipantEventDetails>()
                        .HasOne<UserInfo>()
                        .WithMany()
                        .HasForeignKey(p => p.ParticipantEmailId);

            // ParticipantEventDetails → EventDetails
            modelBuilder.Entity<ParticipantEventDetails>()
                        .HasOne<EventDetails>()
                        .WithMany()
                        .HasForeignKey(p => p.EventId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
