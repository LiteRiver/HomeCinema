using HomeCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations {
    public class UserRoleConfiguration : EntityBaseConfiguration<UserRole> {
        public UserRoleConfiguration() {
            Property(t => t.UserId)
                .IsRequired();

            Property(t => t.RoleId)
                .IsRequired();
        }
    }
}
