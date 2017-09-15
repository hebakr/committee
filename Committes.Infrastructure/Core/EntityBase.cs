using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Committes.Infrastructure.Core
{
    public abstract class EntityBase : IEntityBase<int>
    {
        public int Id { get; set; }

    }
}
