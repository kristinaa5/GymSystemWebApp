using GymSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymSystem
{
    public class GymSystemDBContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<UserTraining> UserTrainings { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=GymSystem;Trusted_Connection=True");

        //}

        public GymSystemDBContext(DbContextOptions<GymSystemDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

           //modelBuilder.Entity<UserTraining>().HasKey(x => new { x.UserId, x.TrainingId });

            modelBuilder.Entity<UserTraining>()
                .HasOne(ulc => ulc.user)
                .WithMany(u => u.userTrainings)
                .HasForeignKey(ulc => ulc.UserId);

            modelBuilder.Entity<UserTraining>()
                .HasOne(ulc => ulc.training)
                .WithMany(u => u.userTrainings)
                .HasForeignKey(ulc => ulc.TrainingId);

        }
    }
}
