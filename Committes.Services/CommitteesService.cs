using Committes.Repositories.Persistence.Core;
using Committes.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Committes.Models;

namespace Committes.Services
{
    public class CommitteesService : ICommitteesService
    {
        private readonly IUnitOfWork _db;

        public CommitteesService(IUnitOfWork db)
        {
            _db = db;
        }

        public IList<Committee> GetAllCommittes()
        {
            return _db.CommitteesRepository.List.ToList();
        }
    }
}
