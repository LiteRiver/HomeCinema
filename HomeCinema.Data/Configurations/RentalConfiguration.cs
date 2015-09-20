using HomeCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations {
    public class RentalConfiguration : EntityBaseConfiguration<Rental> {
        public RentalConfiguration() {
            Property(t => t.CustomerId)
                .IsRequired();

            Property(t => t.StockId)
                .IsRequired();

            Property(t => t.Status)
                .HasMaxLength(10)
                .IsRequired();

            Property(t => t.ReturnedDate)
                .IsOptional();
        }
    }
}
