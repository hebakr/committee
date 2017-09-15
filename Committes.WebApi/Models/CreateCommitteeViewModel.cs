using Committes.Models;
using Committes.Repositories.Persistence.Core;
using Committes.Web.Helpers;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Committes.WebApi.Models
{
    public class CreateCommitteeViewModel
    {
        public CreateCommitteeViewModel(IUnitOfWork db, int id)
        {
            Sectors = db.SectorsRepository.List.Include(x => x.Governrates).OrderBy(x => x.Title).ToList();
            Jobs = db.JobsRepository.List.OrderBy(j => j.Title).ToList();
            Specialities = db.SpecialitiesRepository.List.OrderBy(s => s.Name).ToList();
            CommitteRoles = db.RolesRepository.List.OrderBy(r => r.Title).ToList();
            Schools = db.SchoolsRepository.List.OrderBy(r => r.Title).ToList();

            InspectorEditor = new MemberDto();
            AssistanceEditor = new MemberDto();
            ExaminorEditor = new MemberDto();
            ObserverEditor = new MemberDto();
            LabEditor = new LabViewModel();
            LabEditor.StudentTypes.Add(new StudenTypeVM { Title = "منتظم", Count = 0 });
            LabEditor.StudentTypes.Add(new StudenTypeVM { Title = "قرار", Count = 0 });
            LabEditor.StudentTypes.Add(new StudenTypeVM { Title = "عمال", Count = 0 });

            DivisionEditor = new LabViewModel();
            DivisionEditor.StudentTypes.Add(new StudenTypeVM { Title = "منتظم", Count = 0 });
            DivisionEditor.StudentTypes.Add(new StudenTypeVM { Title = "قرار", Count = 0 });
            DivisionEditor.StudentTypes.Add(new StudenTypeVM { Title = "عمال", Count = 0 });

            if (id == 0)
            {
                Committee = new CommitteeVM(new Committee());
                var settings = Util.AppSettings;
                Committee.SchoolYear = settings.CurrentSchoolYear;
                Committee.Term = settings.CurrentTerm; 
            }
            else
            {
                var committee = db.CommitteesRepository.FindBy(id);
                Committee = new CommitteeVM(committee);
                SelectedSchool = committee.School;
                SelectedLM = SelectedSchool.LearningManagement;
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

        public LabViewModel LabEditor { get; set; }

        public LabViewModel DivisionEditor { get; set; }

        public MemberDto ExaminorEditor { get; set; }

        public MemberDto ObserverEditor { get; private set; }

        public IList<Sector> Sectors { get; set; }

        public IList<Job> Jobs { get; set; }

        public IList<School> Schools { get; set; }

        public IList<Speciality> Specialities { get; set; }

        public IList<CommitteRole> CommitteRoles { get; set; }

        public CommitteeVM Committee { get; set; }

        public Sector SelectedSector { get; set; }
        public Governrate SelectedGov { get; set; }
        public LearningManagement SelectedLM { get; set; }
        public School SelectedSchool { get; set; }
    }


}