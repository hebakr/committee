using Committes.Models;
using System.ComponentModel.DataAnnotations;

namespace Committes.WebApi.Models
{
    public class MemberDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int JobId { get; set; }
        public string Job { get; set; }

        public Job JobObj { get; set; }

        public School School { get; set; }

        public int SchoolId { get; set; }

        public int? SpecialityId { get; set; }
        public string Speciality { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string EvaluationDate { get; set; }

        public string MeetingDate { get; set; }

        public int? CommitteRoleId { get; set; }
        public string CommitteRole { get; set; }

        public bool Theorotical { get; set; }

        public string TheoroticalDate { get; set; }

        public int? CommitteeLabId { get; set; }

        public int? CommitteeDivisionId { get; set; }

        public string Phone { get; set; }
    }
}