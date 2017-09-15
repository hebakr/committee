using Committes.Models;
using Committes.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                WorkPlaceId = member.WorkPlaceId,
                Theorotical = member.Theorotical,
                MeetingDate = member.MeetingDate
                
            };
        }
    }
}