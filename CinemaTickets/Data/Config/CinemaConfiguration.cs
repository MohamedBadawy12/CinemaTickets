using CinemaTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTickets.Data.Config
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Logo)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100).IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250).IsRequired();

        }
    }
}
