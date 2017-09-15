using Committes.Models;
using Committes.Repositories.Persistence.Core;
using Committes.Web.Helpers;
using Committes.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Hosting;
using System.Web.Http;

namespace Committes.WebApi.Controllers.api
{
    [Authorize]
    public class CommitteesController : BaseApiController
    {

        public CommitteesController(IUnitOfWork db)
        {
            _db = db;
        }

        public IHttpActionResult Get()
        {
            var data = _db.CommitteesRepository.List
                    .OrderBy(x => x.Number)
                    .Select(c => new { c.Id, Number = c.Number, Name = c.School.Title, Date = c.DateCreated, c.StudentCount, LearningManagement = c.School.LearningManagement.Title })
                    .Take(20)
                    .ToList();

            return Ok(data);
        }

        public IHttpActionResult FindCommittees([FromBody]FindCommitteesModel model)
        {
            var data = _db.CommitteesRepository.List;

            if (!string.IsNullOrWhiteSpace(model.Name))
                data = data.Where(c => c.Name.Contains(model.Name));

            if (model.Number.HasValue)
                data = data.Where(c => c.Number == model.Number.Value);

            var response = data.Select(c => new { c.Id, Number = c.Number, Name = c.School.Title, Date = c.DateCreated, c.StudentCount })
                    .Take(20)
                    .ToList();

            return Ok(new { data = response, model = model });
        }

        public IHttpActionResult GetCommittee(int id)
        {
            var committee = _db.CommitteesRepository.FindBy(id);

            var model = new CommitteeVM(committee);

            return Ok(model);
        }

        [HttpGet]
        public IHttpActionResult FindCommittee(int code)
        {
            var committee = _db.CommitteesRepository.List.FirstOrDefault(c => c.Number == code);

            if (committee == null) return BadRequest( "Invalid code");

            return Ok(new CommitteeVM(committee));
        }

        [HttpGet]
        public IHttpActionResult GetLatest()
        {
            var data = _db.CommitteesRepository
                .List
                .OrderByDescending(x => x.DateCreated)
                .Select(c => new { c.Id, Number = c.Number, Name = c.School.Title, Date = c.DateCreated, c.StudentCount, LearningManagement = c.School.LearningManagement.Title })
                .Take(10)
                .ToList();

            return Ok(data);
        }

        public IHttpActionResult LoadViewModel(int id)
        {
            var model = new CreateCommitteeViewModel(_db, id);

            return Ok(model);
        }

        public IHttpActionResult SaveCommitteeMembers([FromBody]CommitteeVM committee)
        {
            if (!ModelState.IsValid) return BadRequest();

            var committeeObj = _db.CommitteesRepository.FindBy(committee.Id);

            committeeObj.DoctorName = committee.DoctorName;
            committeeObj.DoctorStartDate = committee.DoctorStartDate;
            committeeObj.StudentCount = committee.StudentCount;
            committeeObj.ChiefStartDate = committee.ChiefStartDate;
            committeeObj.ChiefEndDate = committee.ChiefEndDate;
            committeeObj.SuperInspectorStartDate = committee.SuperInspectorStartDate;
            committeeObj.SuperInspectorEndDate = committee.SuperInspectorEndDate;

            if (committeeObj.Chief == null) committeeObj.Chief = new Member();

            committeeObj.Chief.Name = committee.Chief.Name;
            committeeObj.Chief.JobId = committee.Chief.JobObj.Id;
            committeeObj.Chief.SchoolId = committee.Chief.School.Id;
            committeeObj.Chief.StartDate = committee.Chief.StartDate;
            committeeObj.Chief.EndDate = committee.Chief.EndDate;
            committeeObj.Chief.EvaluationDate = committee.Chief.EvaluationDate;
            committeeObj.Chief.CommitteeId = committee.Id;
            committeeObj.Chief.Phone = committee.Chief.Phone;

            if (committeeObj.SuperInspector == null) committeeObj.SuperInspector   = new Member();

            committeeObj.SuperInspector.Name = committee.SuperInspector.Name;
            committeeObj.SuperInspector.JobId = committee.SuperInspector.JobObj.Id;
            committeeObj.SuperInspector.SchoolId = committee.SuperInspector.School.Id;
            committeeObj.SuperInspector.StartDate = committee.SuperInspector.StartDate;
            committeeObj.SuperInspector.EndDate = committee.SuperInspector.EndDate;
            committeeObj.SuperInspector.EvaluationDate = committee.SuperInspector.EvaluationDate;
            committeeObj.SuperInspector.CommitteeId = committee.Id;
            committeeObj.SuperInspector.Phone = committee.SuperInspector.Phone;

            _db.Commit();

            return Ok(committee);

        }

        public IHttpActionResult SaveCommittee([FromBody]CommitteeVM committee)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (committee.Id == 0)
            {
                var c = new Committee();
                c.DateCreated = DateTime.Now;
                c.Number = GetCommitteeNumber();
                c.Name = committee.Name;
                //committeeObj.Number = committee.Number;
                c.Phone = committee.Phone;
                c.Address = committee.Address;
                c.SchoolYear = committee.SchoolYear;
                c.Term = committee.Term;
                //c.LearningManagementId = committee.LearningManagementId;
                c.SchoolId = committee.SchoolId;
                c.StudentCount = committee.StudentCount;
                c.CommitteType = committee.CommitteType;
                c.LearningType = committee.LearningType;

                _db.CommitteesRepository.Add(c);
            }
            else
            {
                var committeeObj = _db.CommitteesRepository.FindBy(committee.Id);

                committeeObj.Name = committee.Name;
                //committeeObj.Number = committee.Number;
                committeeObj.Phone = committee.Phone;
                committeeObj.Address = committee.Address;
                committeeObj.SchoolYear = committee.SchoolYear;
                committeeObj.Term = committee.Term;
                //committeeObj.LearningManagementId = committee.LearningManagementId;
                committeeObj.SchoolId = committee.SchoolId;
                committeeObj.StudentCount = committee.StudentCount;
                committeeObj.CommitteType = committee.CommitteType;
                committeeObj.LearningType = committee.LearningType;

            }

            _db.Commit();

            return Ok(committee);
        }

        private int GetCommitteeNumber()
        {
            if (_db.CommitteesRepository.List.Any())
                return _db.CommitteesRepository.List.Max(c => c.Number) + 1;

            return Util.AppSettings.CommitteStartNumber;
        }

        public IHttpActionResult SaveInspector([FromBody]SaveMemberViewModel model)
        {
            var committee = _db.CommitteesRepository.FindBy(model.CommitteeId);

            var member = Mapper.Map(model.Member);
            member.CommitteeId = model.CommitteeId;

            if (model.Member.Id == 0)
                committee.Inspectors.Add(member);
            else
            {
                var inspector = committee.Inspectors.FirstOrDefault(m => m.Id == model.Member.Id);
                committee.Inspectors.Remove(inspector);
                committee.Inspectors.Add(member);
            }

            _db.Commit();

            member.Job = _db.JobsRepository.FindBy(member.JobId);

            return Ok(committee.Inspectors);
        }

        public IHttpActionResult SaveObserver([FromBody]SaveMemberViewModel model)
        {
            var committee = _db.CommitteesRepository.FindBy(model.CommitteeId);

            var member = Mapper.Map(model.Member);
            member.CommitteeId = model.CommitteeId;

            if (model.Member.Id == 0)
                committee.Observers.Add(member);
            else
            {
                var inspector = committee.Observers.FirstOrDefault(m => m.Id == model.Member.Id);
                committee.Observers.Remove(inspector);
                committee.Observers.Add(member);
            }

            _db.Commit();

            member.Job = _db.JobsRepository.FindBy(member.JobId);

            return Ok(committee.Observers);
        }

        public IHttpActionResult SaveAssistance([FromBody]SaveMemberViewModel model)
        {
            var committee = _db.CommitteesRepository.FindBy(model.CommitteeId);
            var member = Mapper.Map(model.Member);
            member.CommitteeId = model.CommitteeId;

            if (model.Member.Id == 0)
                committee.Assistances.Add(member);
            else
            {
                var assistance = committee.Assistances.FirstOrDefault(m => m.Id == model.Member.Id);
                committee.Assistances.Remove(assistance);
                committee.Assistances.Add(member);
            }

            _db.Commit();

            member.Job = _db.JobsRepository.FindBy(member.JobId);

            return Ok(committee.Assistances);
        }

        public IHttpActionResult SaveExaminor([FromBody]SaveMemberViewModel model)
        {
            var committee = _db.CommitteesRepository.FindBy(model.CommitteeId);

            var member = Mapper.Map(model.Member);
            member.CommitteeId = model.CommitteeId;

            if (model.Member.Id == 0)
                committee.Examinors.Add(member);
            else
            {
                var examinor = committee.Examinors.FirstOrDefault(m => m.Id == model.Member.Id);
                committee.Examinors.Remove(examinor);
                committee.Examinors.Add(member);
            }

            _db.Commit();


            member.Job = _db.JobsRepository.FindBy(member.JobId);

            return Ok(committee.Examinors);
        }

        public IHttpActionResult SaveLab([FromBody]LabViewModel model)
        {
            var committee = _db.CommitteesRepository.FindBy(model.CommitteeId);

            if (model.Id == 0)
                committee.Labs.Add(new CommitteeLab { Title = model.Title, SchoolName = model.SchoolName, StudentCount = model.StudentCount, StudentType = model.StudentType, EvalDate = model.EvalDate, ExamDate = model.ExamDate });
            else
            {
                var lab = committee.Labs.FirstOrDefault(m => m.Id == model.Id);
                committee.Labs.Remove(lab);
                committee.Labs.Add(new CommitteeLab { Title = model.Title, SchoolName = model.SchoolName, StudentCount = model.StudentCount, StudentType = model.StudentType, EvalDate = model.EvalDate, ExamDate = model.ExamDate });
            }

            _db.Commit();


            var labs = committee.Labs;

            return Ok(labs);
        }

        [HttpGet]
        public IHttpActionResult RemoveLab(int labId, int committeeId)
        {
            var committee = _db.CommitteesRepository.FindBy(committeeId);

            var lab = committee.Labs.SingleOrDefault(l => l.Id == labId);

            if (lab == null) return BadRequest();

            committee.Labs.Remove(lab);

            _db.Commit();

            return Ok();
        }

        public IHttpActionResult SaveDivision([FromBody]LabViewModel model)
        {
            var committee = _db.CommitteesRepository.FindBy(model.CommitteeId);

            if (model.Id == 0)
                committee.Divisions.Add(new CommitteeDivision { Title = model.Title, SchoolName = model.SchoolName, StudentCount = model.StudentCount, StudentType = model.StudentType, EvalDate = model.EvalDate, ExamDate = model.ExamDate, WorkShopCount = model.WorkShopCount, WorkShopCapacity = model.WorkShopCapacity, GroupsCount = model.GroupsCount });
            else
            {
                var div = committee.Divisions.FirstOrDefault(m => m.Id == model.Id);
                committee.Divisions.Remove(div);
                committee.Divisions.Add(new CommitteeDivision { Title = model.Title, SchoolName = model.SchoolName, StudentCount = model.StudentCount, StudentType = model.StudentType, EvalDate = model.EvalDate, ExamDate = model.ExamDate, WorkShopCount = model.WorkShopCount, WorkShopCapacity = model.WorkShopCapacity, GroupsCount = model.GroupsCount });
            }

            _db.Commit();


            var divs = committee.Divisions;

            return Ok(divs);
        }

        [HttpGet]
        public IHttpActionResult RemoveDivision(int divisionId, int committeeId)
        {
            var committee = _db.CommitteesRepository.FindBy(committeeId);

            var division = committee.Divisions.SingleOrDefault(l => l.Id == divisionId);

            if (division == null) return BadRequest();

            committee.Divisions.Remove(division);

            _db.Commit();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult ValidateNumber(int number, int id)
        {
            var result = _db.CommitteesRepository.List.Any(c => c.Number == number && (id == 0 || c.Id != id));

            return Ok(new { isValid = !result });
        }

        [HttpGet]
        public IHttpActionResult AppSettings()
        {
            return Ok(Util.AppSettings);
        }

        [HttpPost]
        public IHttpActionResult AppSettings([FromBody]ApplicationSettings data)
        {
            var filePath = ConfigurationManager.AppSettings["AppSettingsFile"];

            var strSettings = JsonConvert.SerializeObject(data);

            //save to file 
            Util.SaveContentToFile(strSettings, HostingEnvironment.MapPath(filePath));

            return Ok(data);
        }

        public IHttpActionResult ReOrderCommitteesNumbers()
        {
            var committees = _db.CommitteesRepository.List.OrderBy(c => c.Number);

            var committeeNumber = Util.AppSettings.CommitteStartNumber;

            foreach (var item in committees)
                item.Number = committeeNumber++;

            _db.Commit();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult DeleteCommittee(int id)
        {
            _db.DeleteCommittee(id);

            return Ok();
        }



    }
}
