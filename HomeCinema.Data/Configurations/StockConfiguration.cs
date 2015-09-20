using HomeCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations {
    public class StockConfiguration : EntityBaseConfiguration<Stock>{
        public StockConfiguration() {
            Property(t => t.MovieId)
                .IsRequired();

            Property(t => t.UniqueKey)
                .IsRequired();

            Property(t => t.IsAvaliable)
                .IsRequired();

            HasMany(t => t.Rentals)
                .WithRequired(t => t.Stock)
                .HasForeignKey(t => t.StockId);
        }
    }
}
