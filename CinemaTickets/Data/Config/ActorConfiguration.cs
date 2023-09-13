﻿using CinemaTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTickets.Data.Config
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProfilePictureUrl)
                .IsRequired();

            builder.Property(x => x.FullName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100).IsRequired();

            builder.Property(x => x.Bio)
                .HasColumnType("VARCHAR")
                .HasColumnName("Biography")
                .HasMaxLength(250).IsRequired();

        }
    }
}
