using Committes.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Committes.Repositories.Persistence.DbContexts
{
    public class AppDbContext : BaseContext<AppDbContext>, IAppDbContext
    {

        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Governrate> Governrates { get; set; }
        public DbSet<Committee> Committees { get; set; }

        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<LearningManagement> LearningManagements { get; set; }
        public DbSet<CommitteRole> CommitteRoles { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Member> Members { get; set; }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }


    }

}
