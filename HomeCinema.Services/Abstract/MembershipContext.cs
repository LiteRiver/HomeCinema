using HomeCinema.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace HomeCinema.Services.Abstract {
    public class MembershipContext {
        public IPrincipal Principal { get; set; }

        public User User { get; set; }

        public bool IsValid {
            get { return Principal != null; }
        }
    }
}
