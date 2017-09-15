using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Committes.Infrastructure.Core
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }
    }
}
