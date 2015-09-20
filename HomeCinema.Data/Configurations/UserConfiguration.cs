using HomeCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations {
    public class UserConfiguration : EntityBaseConfiguration<User> {
        public UserConfiguration() {
            Property(t => t.Username)
                .HasMaxLength(100)
                .IsRequired();

            Property(t => t.Email)
                .HasMaxLength(200)
                .IsRequired();

            Property(t => t.Password)
                .HasMaxLength(200)
                .IsRequired();

            Property(t => t.Salt)
                .HasMaxLength(200)
                .IsRequired();

            Property(t => t.IsLocked)
                .IsRequired();

            Property(t => t.DateCreated);
        }
    }
}
