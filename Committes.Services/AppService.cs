using Committes.Models;
using Committes.Repositories.Persistence.Core;
using Committes.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Committes.Services
{
    public class AppService : IAppService
    {
        private readonly IUnitOfWork _db;

        public AppService(IUnitOfWork db)
        {
            _db = db;
        }

        public IList<Sector> GetAllSectors()
        {
            return _db.SectorsRepository.List.ToList();
        }
    }
}
