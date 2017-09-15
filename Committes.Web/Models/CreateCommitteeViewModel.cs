using Committes.Models;
using Committes.Repositories.Persistence.Core;
using Committes.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Committes.Web.Models
{
    public class CreateCommitteeViewModel
    {
        public CreateCommitteeViewModel(IUnitOfWork db, int id)
        {
            Sectors = db.SectorsRepository.List.Include(x => x.Governrates).OrderBy(x => x.Title).ToList();
            Jobs = db.JobsRepository.List.OrderBy(j => j.Title).ToList();
            Specialities = db.SpecialitiesRepository.List.OrderBy(s => s.Name).ToList();
            CommitteRoles = db.RolesRepository.List.OrderBy(r => r.Title).ToList();
            //Labs = db.LabsRepository.List.OrderBy(r => r.Title).ToList();

            InspectorEditor = new MemberDto();
            AssistanceEditor = new MemberDto();
            ExaminorEditor = new MemberDto();
            ObserverEditor = new MemberDto();

            if (id == 0)
            {
                Committee = new Committee();
                var settings = Util.AppSettings;
                Committee.SchoolYear = settings.CurrentSchoolYear;
                Committee.Term = settings.CurrentTerm; 
            }
            else
            {
                Committee = db.CommitteesRepository.FindBy(id);
                SelectedLM = Committee.LearningManagement;
                SelectedGov = SelectedLM.Governrate;
                SelectedSector = SelectedGov.Sector;

            }

            CommitteeTypes = new List<dynamic>();
            LearningTypes = new List<dynamic>();


            var _committeeTypes = new List<string> { "منتظم", "عمال", "قرار", "مزدوج" };
            var _learningTypes = new List<string> { "صناعى", "طباعة", "مزدوج" };

            _committeeTypes.ForEach(x =>
            {
                CommitteeTypes.Add(new { Name = x, Selected = (!string.IsNullOrWhiteSpace( Committee.CommitteType) && Committee.CommitteType.Contains(x)) });
            });

            _learningTypes.ForEach(x =>
            {
                LearningTypes.Add(new { Name = x, Selected = (!string.IsNullOrWhiteSpace(Committee.LearningType) && Committee.LearningType.Contains(x)) });
            });



        }

        public IList<dynamic> CommitteeTypes { get; set; }

        public IList<dynamic> LearningTypes { get; set; }

        public MemberDto InspectorEditor { get; set; }

        public MemberDto AssistanceEditor { get; set; }

        public CommitteeLab LabEditor { get; set; }

        public CommitteeDivision DivisionEditor { get; set; }

        public MemberDto ExaminorEditor { get; set; }

        public MemberDto ObserverEditor { get; private set; }

        public IList<Sector> Sectors { get; set; }

        public IList<Job> Jobs { get; set; }

        public IList<Speciality> Specialities { get; set; }

        public IList<CommitteRole> CommitteRoles { get; set; }

        public Committee Committee { get; set; }

        public Sector SelectedSector { get; set; }
        public Governrate SelectedGov { get; set; }
        public LearningManagement SelectedLM { get; set; }
    }
}