using Committes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Committes.Services.Core
{
    public interface ICommitteesService
    {
        IList<Committee> GetAllCommittes();
    }
}
