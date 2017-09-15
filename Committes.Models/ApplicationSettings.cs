using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Committes.Models
{
    public class ApplicationSettings
    {
        public ApplicationSettings()
        {
            CommitteStartNumber = 1;
            CurrentSchoolYear = DateTime.Now.Year.ToString();
        }

        public int CommitteStartNumber { get; set; }

        public string CurrentSchoolYear { get; set; }

        public string CurrentTerm { get; set; }
    }
}
