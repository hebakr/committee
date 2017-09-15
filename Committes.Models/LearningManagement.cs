using Committes.Infrastructure.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Committes.Models
{
    public class LearningManagement : EntityBase
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        public int GovernrateId { get; set; }

        public virtual Governrate Governrate { get; set; }

        public virtual IList<School> Schools { get; set; }
    }
}
