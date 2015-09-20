using HomeCinema.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Services {
    public class EncryptionService : IEncryptionService {

        public string CreateSalt() {
            using(var rng = new RNGCryptoServiceProvider()){
                var buf = new byte[0x10];
                rng.GetBytes(buf);
                return Convert.ToBase64String(buf);
            }
        }

        public string Encrypt(string password, string salt) {
            using (var sha256 = SHA256.Create()) {
                var plain = string.Format("{0}{1}", password, salt);
                var buf = sha256.ComputeHash(Encoding.UTF8.GetBytes(plain));
                return Convert.ToBase64String(buf);
            }
        }
    }
}
