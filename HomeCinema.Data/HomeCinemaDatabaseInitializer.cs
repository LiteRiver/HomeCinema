using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data {
    public class HomeCinemaDatabaseInitializer : MigrateDatabaseToLatestVersion<HomeCinemaContext, HomeCinemaDatabaseConfiguration> {
    }

    public class HomeCinemaDatabaseConfiguration : DbMigrationsConfiguration<HomeCinemaContext> {
        public HomeCinemaDatabaseConfiguration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
