using HomeCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations {
    public class CustomerConfiguration : EntityBaseConfiguration<Customer> {
        public CustomerConfiguration() {
            Property(t => t.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            Property(t => t.LastName)
                .HasMaxLength(100)
                .IsRequired();

            Property(t => t.IdentityCard)
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.UniqueKey)
                .IsRequired();

            Property(t => t.Mobile)
                .HasMaxLength(15);

            Property(t => t.Email)
                .HasMaxLength(200)
                .IsRequired();

            Property(t => t.DateOfBirth).IsRequired();
        }
    }
}
