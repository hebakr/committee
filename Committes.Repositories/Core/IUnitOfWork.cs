using Committes.Infrastructure.Core;
using Committes.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Committes.Repositories.Persistence.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Committee> CommitteesRepository { get; }
        IRepository<Governrate> GovernratesRepository { get; }
        IRepository<Sector> SectorsRepository { get; }
        IRepository<Member> MembersRepository { get; }
        IRepository<Job> JobsRepository { get; }

        IRepository<Speciality> SpecialitiesRepository { get; }
        IRepository<CommitteRole> RolesRepository { get; }
        IRepository<LearningManagement> LearningManagementsRepository { get;  }
        IRepository<School> SchoolsRepository { get;  }


        int Commit();
        void DeleteCommittee(int id);
    }
}