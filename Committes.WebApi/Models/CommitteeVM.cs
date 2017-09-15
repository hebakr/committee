using Committes.Models;
using Committes.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Committes.WebApi.Models
{
    public class CommitteeVM
    {
        private Committee _committee;

        public CommitteeVM()
        {

        }


        public CommitteeVM(Committee committee)
        {
            if (committee == null || committee.Id == 0) return;

            _committee = committee;
           
            Id = committee.Id;
            Name = committee.School.Title;
            Number = committee.Number;
            Phone = committee.Phone;
            Address = committee.Address;
            SchoolYear = committee.SchoolYear;
            Term = committee.Term;
            StudentCount = committee.StudentCount;
            DoctorName = committee.DoctorName;
            DoctorStartDate = committee.DoctorStartDate;
            CommitteType = committee.CommitteType;
            LearningType = committee.LearningType;
            
            SectorId = committee.School.LearningManagement.Governrate.SectorId;
            Sector = committee.School.LearningManagement.Governrate.Sector.Title;
            GovernrateId = committee.School.LearningManagement.GovernrateId;
            Governrate = committee.School.LearningManagement.Governrate.Title;
            LearningManagement = committee.School.LearningManagement.Title;
            LearningManagementId = committee.School.LearningManagement.Id;
            
            School = committee.School;
            SchoolId = committee.School.Id;

            ChiefStartDate = committee.ChiefStartDate;
            ChiefEndDate = committee.ChiefEndDate;

            SuperInspectorStartDate = committee.SuperInspectorStartDate;
            SuperInspectorEndDate = committee.SuperInspectorEndDate;

            Chief = Mapper.Map(committee.Chief);
            SuperInspector = Mapper.Map(committee.SuperInspector);
        }


        public string Name { get; set; }

        public int Number { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string SchoolYear { get; set; }

        public string Term { get; set; }


        public int? StudentCount { get; set; }


        public string DoctorName { get; set; }

        public string DoctorStartDate { get; set; }

        public string CommitteType { get; set; }

        public string LearningType { get; set; }

        public string Sector { get; set; }
        public int? SectorId { get; set; }

        public string Governrate { get; set; }
        public int GovernrateId { get; set; }

        public string LearningManagement { get; set; }
        public int LearningManagementId { get; set; }

        public School School { get; set; }

        public int? SchoolId { get; set; }

        public MemberDto Chief { get; set; }

        public MemberDto SuperInspector { get; set; }

        public DateTime? ChiefStartDate { get; set; }
        public DateTime? ChiefEndDate { get; set; }

        public DateTime? SuperInspectorStartDate { get; set; }
        public DateTime? SuperInspectorEndDate { get; set; }

        public IList<MemberDto> Inspectors
        {
            get
            {
                if (_committee == null || _committee.Inspectors == null) return null;
                return _committee.Inspectors.Select(x => Mapper.Map(x)).ToList();
            }
        }
        public IList<MemberDto> Assistances
        {
            get
            {
                if (_committee == null || _committee.Assistances == null) return null;
                return _committee.Assistances.Select(x => Mapper.Map(x)).ToList();
            }
        }
        public IList<MemberDto> Observers
        {
            get
            {
                if (_committee == null || _committee.Observers == null) return null;
                return _committee.Observers.Select(x => Mapper.Map(x)).ToList();
            }
        }
        public IList<MemberDto> Examinors
        {
            get
            {
                if (_committee == null || _committee.Examinors == null) return null;
                return _committee.Examinors.Select(x => Mapper.Map(x)).ToList();
            }
        }

        public IList<MemberDto> TheoroticalMembers
        {
            get
            {
                if (_committee == null || _committee.Examinors == null) return null;
                return Examinors.Where(e => e.Theorotical).ToList();
            }
        }

        public IList<LabGroup> Labs
        {
            get
            {
                if (_committee == null) return null;
                return _committee.Labs.Select(l => CreateLabGroup(l)).ToList();
            }
        }

        public IList<LabGroup> Divisions
        {
            get
            {
                if (_committee == null) return null;
                return _committee.Divisions.Select(d => CreateDivisionGroup(d)).ToList();
            }
        }

        public int Id { get; set; }

        private LabGroup CreateDivisionGroup(CommitteeDivision div)
        {
            if (_committee == null) return null;
            return new LabGroup
            {
                Id = div.Id,
                Title = div.Title,
                StudentCount = div.StudentCount,
                Members = _committee.Examinors.Where(x => x.CommitteeDivisionId == div.Id).Select(x => Mapper.Map(x)).ToList()
            };
        }

        private LabGroup CreateLabGroup(CommitteeLab lab)
        {
            if (_committee == null) return null;
            return new LabGroup
            {
                Id = lab.Id,
                Title = lab.Title,
                StudentCount = lab.StudentCount,
                Members = _committee.Examinors.Where(x => x.CommitteeLabId == lab.Id).Select(x => Mapper.Map(x)).ToList()
            };
        }
    }

    public class LabGroup
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string StudentCount { get; set; }

        public IList<MemberDto> Members { get; set; }
    }
}