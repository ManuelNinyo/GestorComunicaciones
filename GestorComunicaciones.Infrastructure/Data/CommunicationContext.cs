using System;
using System.Reflection;
using GestorComunicaciones.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GestorComunicaciones.Infrastructure.Data
{
    public partial class CommunicationContext : DbContext
    {
        public CommunicationContext()
        {
        }

        public CommunicationContext(DbContextOptions<CommunicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Communication> Communications { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<CommunicationType> CommunicationTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.HasSequence("ExternosCount");

            modelBuilder.HasSequence("InternosCount");


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
