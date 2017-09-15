using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Committes.WebApi.Models
{
    public class FindCommitteesModel
    {
        public string Name { get; set; }

        public int? Number { get; set; }
    }
}