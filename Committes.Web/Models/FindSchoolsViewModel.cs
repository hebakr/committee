using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Committes.Web.Models
{
    public class FindSchoolsViewModel
    {
        public int Sector  { get; set; }
        public int Governrate { get; set; }

        public string Number { get; set; }
    }
}