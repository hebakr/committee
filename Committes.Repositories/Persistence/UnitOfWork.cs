using Committes.Infrastructure.Core;
using Committes.Infrastructure.Persistence;
using Committes.Models;
using Committes.Repositories.Persistence.Core;
using System;
using System.Data.Entity;

namespace Committes.Repositories.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        private IRepository<Sector> _sectorsRepository = null;
        private IRepository<Governrate> _governratesRepository = null;
        private IRepository<Committee> _committeesRepository = null;
        private IRepository<Member> _membersRepository = null;
        private IRepository<Job> _jobsRepository = null;
        private IRepository<Speciality> _specialitiesRepository = null;
        private IRepository<CommitteRole> _rolesRepository = null;
        private IRepository<LearningManagement> _learningManagementsRepository = null;
        private IRepository<School> _schoolsRepository = null;

        public IRepository<Sector> SectorsRepository => _sectorsRepository ?? (_sectorsRepository = new Repository<Sector>(_context));
        public IRepository<Governrate> GovernratesRepository => _governratesRepository ?? (_governratesRepository = new Repository<Governrate>(_context));
        public IRepository<Committee> CommitteesRepository => _committeesRepository ?? (_committeesRepository = new Repository<Committee>(_context));
        public IRepository<Member> MembersRepository => _membersRepository ?? (_membersRepository = new Repository<Member>(_context));
        public IRepository<Job> JobsRepository => _jobsRepository ?? (_jobsRepository = new Repository<Job>(_context));
        public IRepository<Speciality> SpecialitiesRepository => _specialitiesRepository ?? (_specialitiesRepository = new Repository<Speciality>(_context));
        public IRepository<CommitteRole> RolesRepository => _rolesRepository ?? (_rolesRepository = new Repository<CommitteRole>(_context));
        public IRepository<LearningManagement> LearningManagementsRepository => _learningManagementsRepository ?? (_learningManagementsRepository = new Repository<LearningManagement>(_context));
        public IRepository<School> SchoolsRepository => _schoolsRepository ?? (_schoolsRepository = new Repository<School>(_context));

        public int Commit()
        {
            return _context.SaveChanges();
        }

        private bool _disposed;

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_context != null) _context.Dispose();
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void DeleteCommittee(int id)
        {
            _context.Database.ExecuteSqlCommand("EXEC DeleteCommittee {0}", id);
        }
    }
}
