using Committes.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Committes.Models
{
    public class Member : EntityBase
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public int JobId { get; set; }

        public virtual Job Job { get; set; }

        public int? SchoolId { get; set; }

        public virtual School School { get; set; }

        public int? SpecialityId { get; set; }

        public virtual Speciality Speciality { get; set; }

        [MaxLength(50)]
        public string StartDate { get; set; }

        [MaxLength(50)]
        public string EndDate { get; set; }

        [MaxLength(50)]
        public string EvaluationDate { get; set; }

        [MaxLength(50)]
        public string TheoroticalDate { get; set; }

        [MaxLength(50)]
        public string MeetingDate { get; set; }

        public int? CommitteRoleId { get; set; }

        public virtual CommitteRole Role { get; set; }

        public bool Theorotical { get; set; }

        public int? CommitteeLabId { get; set; }

        public virtual CommitteeLab Lab { get; set; }

        public int? CommitteeDivisionId { get; set; }

        public virtual CommitteeDivision Division { get; set; }

        public int? CommitteeId { get; set; }

        public virtual Committee Committee { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

    }

}
