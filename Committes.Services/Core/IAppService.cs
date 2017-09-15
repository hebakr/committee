using System.Collections.Generic;
using Committes.Models;

namespace Committes.Services.Core
{
    public interface IAppService
    {
        IList<Sector> GetAllSectors();
    }
}