using HomeCinema.Data.Infrastructure;
using HomeCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data {
    public static class UserExtensions {
        public static User GetUserByUsername(this IRepository<User> userRepo, string username) {
            return userRepo.Table.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
