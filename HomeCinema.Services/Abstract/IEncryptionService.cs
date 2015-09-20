﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Services.Abstract {
    public interface IEncryptionService {
        string CreateSalt();

        string Encrypt(string password, string salt);
    }
}
