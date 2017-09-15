using Committes.Infrastructure.Core;
using System.ComponentModel.DataAnnotations;

namespace Committes.Models
{
    public class CommitteRole : EntityBase
    {
        [MaxLength(150)]
        public string Title { get; set; }
    }
}
