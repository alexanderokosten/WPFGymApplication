using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GymApp.Model
{
    public partial class GymAppModel : DbContext
    {
        public GymAppModel()
            : base("name=GymAppModel")
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<ClientTrainer> ClientTrainer { get; set; }
        public virtual DbSet<GroupLessons> GroupLessons { get; set; }
        public virtual DbSet<SexTable> SexTable { get; set; }
        public virtual DbSet<SignUpForGroupLessons> SignUpForGroupLessons { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<Trainers> Trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>()
                .HasMany(e => e.ClientTrainer)
                .WithRequired(e => e.Clients)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clients>()
                .HasMany(e => e.SignUpForGroupLessons)
                .WithRequired(e => e.Clients)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupLessons>()
                .HasMany(e => e.SignUpForGroupLessons)
                .WithRequired(e => e.GroupLessons)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SexTable>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.SexTable)
                .HasForeignKey(e => e.Sex)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SexTable>()
                .HasMany(e => e.Trainers)
                .WithRequired(e => e.SexTable)
                .HasForeignKey(e => e.Sex)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subscription>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.Subscription1)
                .HasForeignKey(e => e.Subscription)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainers>()
                .HasMany(e => e.ClientTrainer)
                .WithRequired(e => e.Trainers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainers>()
                .HasMany(e => e.GroupLessons)
                .WithRequired(e => e.Trainers)
                .WillCascadeOnDelete(false);
        }
    }
}
