using Committes.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Committes.Models
{
    public class Sector : EntityBase
    {
        [MaxLength(150)]
        public string Title { get; set; }

        public virtual IList<Governrate> Governrates { get; set; }
    }
}
