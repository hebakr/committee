using Committes.Infrastructure.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Committes.Models
{
    public class Job : EntityBase
    {
        [MaxLength(150)]
        public string Title { get; set; }
    }
}
