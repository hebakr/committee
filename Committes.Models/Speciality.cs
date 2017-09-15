using Committes.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Committes.Models
{
    public class Speciality : EntityBase
    {
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
