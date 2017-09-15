using Committes.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Committes.Models
{
    public class Committee : EntityBase
    {
        public Committee()
        {
            Inspectors = new List<Member>();
            Assistances = new List<Member>();
            Observers = new List<Member>();
        }

        [MaxLength(150)]
        public string Name { get; set; }

        public int Number { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string SchoolYear { get; set; }

        [MaxLength(50)]
        public string Term { get; set; }


        public int? StudentCount { get; set; }

        public virtual IList<CommitteeLab> Labs { get; set; }

        public virtual IList<CommitteeDivision> Divisions { get; set; }

        public int? SchoolId { get; set; }

        public virtual School School { get; set; }

        public virtual Member Chief { get; set; }

        public virtual Member SuperInspector { get; set; }

        [MaxLength(150)]
        public string DoctorName { get; set; }

        [MaxLength(50)]
        public string DoctorStartDate { get; set; }

        public DateTime? ChiefStartDate { get; set; }
        public DateTime? ChiefEndDate { get; set; }

        public DateTime? SuperInspectorStartDate { get; set; }
        public DateTime? SuperInspectorEndDate { get; set; }

        [MaxLength(50)]
        public string CommitteType { get; set; }

        [MaxLength(50)]
        public string LearningType { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual IList<Member> Inspectors { get; set; }

        public virtual IList<Member> Assistances { get; set; }

        public virtual IList<Member> Examinors { get; set; }

        public virtual IList<Member> Observers { get; set; }

    }
}
