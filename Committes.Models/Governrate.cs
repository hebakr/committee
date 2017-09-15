using Committes.Infrastructure.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Committes.Models
{
    public class Governrate : EntityBase
    {
        [MaxLength(150)]
        public string Title { get; set; }

        public int? SectorId { get; set; }

        public virtual Sector Sector { get; set; }

        public virtual IList<LearningManagement> LearningManagements { get; set; }
    }
}
