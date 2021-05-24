
using GestorComunicaciones.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorComunicaciones.Infrastructure.Data.Configurations
{
    class CommunicationTypeConfiguration : IEntityTypeConfiguration<CommunicationType>
    {
        public void Configure(EntityTypeBuilder<CommunicationType> builder)
        {
            builder.ToTable("TipoCorrespondencia");

            builder.HasIndex(e => e.Name, "UQ__Roles__75E3EFCF25561859")
                .IsUnique();

            builder.Property(e => e.Name)
                .HasColumnName("Nombre")
                .HasMaxLength(50)
                .IsUnicode(false);


        }
    }
}

