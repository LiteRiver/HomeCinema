using HomeCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations {
    public class MovieConfiguration: EntityBaseConfiguration<Movie> {
        public MovieConfiguration() {
            Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            Property(t => t.GenreId)
                .IsRequired();

            Property(t => t.Director)
                .HasMaxLength(100)
                .IsRequired();

            Property(t => t.Writer)
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.Producer)
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.Rating)
                .IsRequired();

            Property(t => t.Description)
                .HasMaxLength(2000)
                .IsRequired();

            Property(t => t.TrailerURI)
                .HasMaxLength(200);

            HasMany(t => t.Stocks)
                .WithRequired(t => t.Movie)
                .HasForeignKey(t => t.MovieId);
        }
    }
}
