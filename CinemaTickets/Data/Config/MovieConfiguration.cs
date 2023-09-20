using CinemaTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTickets.Data.Config
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movies>
    {
        public void Configure(EntityTypeBuilder<Movies> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100).IsRequired();


			builder.Property(x => x.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(250).IsRequired();

            builder.Property(x => x.Price).HasPrecision(10, 2);

            builder.Property(x=>x.ImageUrl)
                .IsRequired();

			builder.Property(x => x.Triler)
				.IsRequired();

			builder.OwnsOne(x => x.TimeDate, td =>
            {
                td.Property(p => p.StartTime).HasColumnType("DateTime").HasColumnName("StartTime");
                td.Property(p => p.EndTime).HasColumnType("DateTime").HasColumnName("EndTime");
            });

            builder.HasOne(x=>x.Cinema)
                .WithMany(x=>x.Movies)
                .HasForeignKey(x=>x.CinemaId).IsRequired();

            builder.HasOne(x => x.Producer)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.ProducerId).IsRequired();
        }
    }
}
