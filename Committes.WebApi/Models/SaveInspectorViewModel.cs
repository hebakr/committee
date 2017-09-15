using Committes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Committes.WebApi.Models
{
    public class SaveMemberViewModel
    {
        public int CommitteeId { get; set; }

        public MemberDto Member { get; set; }
    }
}