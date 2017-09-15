using Committes.Infrastructure.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Committes.Models
{
    public class School : EntityBase
    {
        [MaxLength(150)]
        public string Title { get; set; }

        public int? LearningManagementId { get; set; }

        public virtual LearningManagement LearningManagement { get; set; }

    }
}
