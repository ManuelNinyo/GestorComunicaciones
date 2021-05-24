using GestorComunicaciones.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorComunicaciones.Infrastructure.Data.Configurations
{
    class CommunicationConfiguration : IEntityTypeConfiguration<Communication>
    {
        public void Configure(EntityTypeBuilder<Communication> builder)
        {
            builder.ToTable("Comunicaciones");

            builder.Property(e => e.ConsecutiveCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Consecutivo");

            builder.Property(e => e.Content).IsUnicode(false)
                .HasColumnName("Contenido");

            builder.Property(e => e.CommunicationTypeId)
                .HasColumnName("TipoCorrespondencia");

            builder.Property(e => e.RecipientId)
                .HasColumnName("Destinatario");

            builder.Property(e => e.SenderId)
                .HasColumnName("Remitente");


            builder.HasOne(d => d.Recipient)
                .WithMany(p => p.ReceivedCommunications)
                .HasForeignKey(d => d.RecipientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comunicac__Desti__2D27B809");

            builder.HasOne(d => d.Sender)
                .WithMany(p => p.SentCommunications)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comunicac__Remit__2C3393D0");

            builder.HasOne(d => d.CommunicationType)
                .WithMany(p => p.Communications)
                .HasForeignKey(d => d.CommunicationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comunicac__TipoC__2E1BDC42");


        }
    }

}
