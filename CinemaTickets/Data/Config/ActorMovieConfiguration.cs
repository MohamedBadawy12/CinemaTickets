using CinemaTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTickets.Data.Config
{
    public class ActorMovieConfiguration : IEntityTypeConfiguration<Actor_Movie>
    {
        public void Configure(EntityTypeBuilder<Actor_Movie> builder)
        {
            builder.HasKey(x => new
            {
                x.ActorId,
                x.MovieId
            });

            builder.HasOne(x=>x.Movies).
                WithMany(x=>x.Actor_Movie).
                HasForeignKey(x=>x.MovieId);

            builder.HasOne(x => x.Actor).
                WithMany(x => x.Actor_Movie).
                HasForeignKey(x => x.ActorId);

            builder.ToTable("ActorMovie");
        }
    }
}
