using Committes.Models;
using Committes.WebApi.Models;

namespace Committes.Web.Helpers
{
    public class Mapper
    {
        public static Member Map(MemberDto member)
        {
            return new Member
            {
                Name = member.Name,
                StartDate = member.StartDate,
                EndDate = member.EndDate,
                EvaluationDate = member.EvaluationDate,
                JobId = member.JobId,
                CommitteeDivisionId = member.CommitteeDivisionId,
                CommitteeLabId = member.CommitteeLabId,
                CommitteRoleId = member.CommitteRoleId,
                SpecialityId = member.SpecialityId,
                SchoolId = member.School.Id,
                Theorotical = member.Theorotical,
                MeetingDate = member.MeetingDate,
                TheoroticalDate = member.TheoroticalDate,
                Phone = member.Phone
                
            };
        }

        public static MemberDto Map(Member member)
        {
            if (member == null) return null;

            return new MemberDto
            {
                Id = member.Id,
                Name = member.Name,
                StartDate = member.StartDate,
                EndDate = member.EndDate,
                EvaluationDate = member.EvaluationDate,
                JobId = member.JobId,
                Job = member.Job.Title,
                JobObj = member.Job,
                CommitteeDivisionId = member.CommitteeDivisionId,

                CommitteeLabId = member.CommitteeLabId,
                CommitteRoleId = member.CommitteRoleId,
                CommitteRole = member.Role == null ? string.Empty : member.Role.Title,
                SpecialityId = member.SpecialityId,
                Speciality =  (member.Speciality == null) ? string.Empty : member.Speciality.Name,
                School = member.School,
                Theorotical = member.Theorotical,
                TheoroticalDate = member.TheoroticalDate,
                MeetingDate = member.MeetingDate,
                Phone = member.Phone
            };
        }

    }
}