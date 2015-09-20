using HomeCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations {
    public class GenreConfiguration : EntityBaseConfiguration<Genre> {
        public GenreConfiguration() {
            Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
