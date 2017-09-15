using System.Data.Entity;
using Committes.Models;

namespace Committes.Repositories.Persistence.DbContexts
{
    public interface IAppDbContext
    {
        DbSet<Committee> Committees { get; set; }
        DbSet<CommitteRole> CommitteRoles { get; set; }
        DbSet<Governrate> Governrates { get; set; }
        DbSet<Job> Jobs { get; set; }
        DbSet<LearningManagement> LearningManagements { get; set; }
        DbSet<Member> Members { get; set; }
        DbSet<Sector> Sectors { get; set; }
        DbSet<Speciality> Specialities { get; set; }
    }
}