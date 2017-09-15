using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Committes.Web.Models
{
    public class LabViewModel
    {
        public int Id { get; set; }

        public int CommitteeId { get; set; }
        public string Title { get; set; }
        public string StudentCount { get; set; }
        public string StudentType { get; set; }
        public string ExamDate { get; set; }
        public string EvalDate { get; set; }
        public string WorkShopCount { get; set; }
        public string WorkShopCapacity { get; set; }
        public string GroupsCount { get; set; }
    }
}