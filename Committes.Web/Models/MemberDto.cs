using Committes.Models;
using System.ComponentModel.DataAnnotations;

namespace Committes.Web.Models
{
    public class MemberDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int JobId { get; set; }

        public int WorkPlaceId { get; set; }

        public int? SpecialityId { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string EvaluationDate { get; set; }

        public string MeetingDate { get; set; }

        public int? CommitteRoleId { get; set; }

        public bool Theorotical { get; set; }

        public int? CommitteeLabId { get; set; }

        public int? CommitteeDivisionId { get; set; }

    }
}