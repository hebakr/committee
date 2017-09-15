using Committes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Committes.Web.Models
{
    public class CommitteeVM
    {
        public Committee Committee { get; set; }

        public IList<Member> TheoroticalMembers
        {
            get
            {
                return Committee.Examinors.Where(e => e.Theorotical).ToList();
            }
        }

        public IList<LabGroup> Labs
        {
            get
            {
                return Committee.Labs.Select(l => CreateLabGroup(l)).ToList();
            }
        }

        public IList<LabGroup> Divisions
        {
            get
            {
                return Committee.Divisions.Select(d => CreateDivisionGroup(d)).ToList();
            }
        }

        private LabGroup CreateDivisionGroup(CommitteeDivision div)
        {
            return new LabGroup
            {
                Id = div.Id,
                Title = div.Title,
                StudentCount = div.StudentCount,
                Members = Committee.Examinors.Where(x => x.CommitteeDivisionId == div.Id).ToList()
            };
        }

        private LabGroup CreateLabGroup(CommitteeLab lab)
        {
            return new LabGroup
            {
                Id = lab.Id,
                Title = lab.Title,
                StudentCount = lab.StudentCount,
                Members = Committee.Examinors.Where(x => x.CommitteeLabId == lab.Id).ToList()
            };
        }
    }

    public class LabGroup
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string StudentCount { get; set; }

        public IList<Member> Members { get; set; }
    }
}