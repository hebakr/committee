using Committes.Repositories.Persistence.Core;
using Committes.Web.Helpers;
using Committes.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Committes.WebApi.Controllers
{
    [Authorize]
    public class ReportsController : BaseApiController
    {

        public ReportsController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public IHttpActionResult LocationsReport(int? governrate, int? sector)
        {
            var data = _db.CommitteesRepository.List;

            if (governrate.HasValue && governrate.Value > 0)
                data = data.Where(c => c.School.LearningManagement.GovernrateId == governrate.Value);

            if (sector.HasValue && sector.Value > 0)
                data = data.Where(c => c.School.LearningManagement.Governrate.SectorId == sector.Value);

            var committees = data.Select(c => new {
                        c.Number,
                        Name = c.School.Title,
                        c.CommitteType,
                        c.StudentCount,
                        c.Address,
                        c.Phone
                    }).OrderBy(c => c.Number);

            var sectors = _db.SectorsRepository.List.Include(x => x.Governrates).OrderBy(x => x.Title).ToList();


            return Ok(new { committees = committees, sectors = sectors });
        }

        [HttpGet]
        public IHttpActionResult HafzaReport(int? school)
        {
            var sectors = _db.SectorsRepository.List.Include(x => x.Governrates).OrderBy(x => x.Title).ToList();

            if (school.HasValue && school.Value != 0)
            {
                var schoolData = FindSchoolData(school.Value);

                return Ok(new { school = schoolData, sectors = sectors });
            }

            return Ok(new { sectors = sectors });
        }

        public IHttpActionResult GetSectors()
        {
            var sectors = _db.SectorsRepository.List.Include(x => x.Governrates).OrderBy(x => x.Title).ToList();

            return Ok(sectors);
        }

        private dynamic FindSchoolData(int schoolId)
        {
            var school = _db.SchoolsRepository.FindBy(schoolId);

            var members = _db.MembersRepository.List.Where(m => m.SchoolId == schoolId).ToList();

            var dataObj = new
            {
                school.Id,
                school.Title,
                LearningManagement = school.LearningManagement.Title,
                Governrate = school.LearningManagement.Governrate.Title,
                Sector = school.LearningManagement.Governrate.Sector.Title,
                Members = members.Select(m => new {
                    m.Name,
                    Job = m.Job.Title,
                    Committee = m.Committee.School.Title,
                    Address = m.Committee?.Address,
                    Role = m.Role?.Title,
                    m.StartDate
                })
            };

            return dataObj;
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult StatsReport()
        {
            var data = _db.CommitteesRepository
                .List
                .Select(x => new {
                    Governrate = x.School.LearningManagement.Governrate.Title,
                    x.Chief,
                    x.SuperInspector,
                    StudentCount = x.StudentCount,
                    InspectorsCount = x.Inspectors.Count,
                    ExaminorsCount = x.Examinors.Count,
                    AssistancesCount = x.Assistances.Count,
                    ObserversCount = x.Observers.Count,
                    LabsCount = x.Labs.Count,
                    DivisionsCount =  x.Divisions.Count,
                    x.DoctorName
                });

            var result = data.GroupBy(p => p.Governrate)
                   .Select(g => new
                   {
                       name = g.Key,
                       StudentCount = g.Sum(x => x.StudentCount),
                       ChiefCount = g.Where(x => x.Chief != null).Count(),
                       SuperInspectorCount = g.Where(x => x.SuperInspector != null).Count(),
                       InspectorsCount = g.Sum(x => x.InspectorsCount),
                       ExaminorsCount = g.Sum(x => x.ExaminorsCount),
                       AssistancesCount = g.Sum(x => x.AssistancesCount),
                       ObserversCount = g.Sum(x => x.ObserversCount),
                       DoctorsCount = g.Where(x => x.DoctorName != null || x.DoctorName != "").Count()

                   });

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult DeliveryReport(int? sector, int? governrate, int? lm)
        {
            var data = _db.CommitteesRepository.List;

            if (lm.HasValue && lm.Value > 0)
                data = data.Where(c => c.School.LearningManagementId == lm.Value);

            else if (governrate.HasValue && governrate.Value > 0)
                data = data.Where(c => c.School.LearningManagement.GovernrateId == governrate.Value);

            else if (sector.HasValue && sector.Value > 0)
                data = data.Where(c => c.School.LearningManagement.Governrate.SectorId == sector.Value);

            var committees = data.Select(c => new {
                c.Number,
                Name = c.School.Title,
                ChiefName = c.Chief.Name,
                ChiefJob = c.Chief.Job.Title,
                ChiefPhone = c.Chief.Phone,
                SuperInspectorName = c.SuperInspector.Name,
                SuperInspectorJob = c.SuperInspector.Job.Title,
                SuperInspectorPhone = c.SuperInspector.Phone

            }).OrderBy(c => c.Number);

            return Ok(committees);
        }

        [HttpGet]
        public IHttpActionResult DeliveryByDateReport(int? sector, int? governrate, int? lm)
        {
            var data = _db.CommitteesRepository.List;

            if (lm.HasValue && lm.Value > 0)
                data = data.Where(c => c.School.LearningManagementId == lm.Value);

            else if (governrate.HasValue && governrate.Value > 0)
                data = data.Where(c => c.School.LearningManagement.GovernrateId == governrate.Value);

            else if (sector.HasValue && sector.Value > 0)
                data = data.Where(c => c.School.LearningManagement.Governrate.SectorId == sector.Value);

            var d = from c in data
                    group c by c.ChiefStartDate into g
                    where g.Key != null
                    select new { g.Key, Schools = g.Select(c => new {
                        c.Number,
                        Name = c.School.Title,
                        ChiefName = c.Chief.Name,
                        ChiefJob = c.Chief.Job.Title,
                        ChiefPhone = c.Chief.Phone,
                        SuperInspectorName = c.SuperInspector.Name,
                        SuperInspectorJob = c.SuperInspector.Job.Title,
                        SuperInspectorPhone = c.SuperInspector.Phone
                    }) };

            return Ok(d);
        }

        [HttpGet]
        public IHttpActionResult TypeReport(int? sector, int? governrate, int? lm)
        {
            var data = _db.CommitteesRepository.List;

            if (lm.HasValue && lm.Value > 0)
                data = data.Where(c => c.School.LearningManagementId == lm.Value);

            else if (governrate.HasValue && governrate.Value > 0)
                data = data.Where(c => c.School.LearningManagement.GovernrateId == governrate.Value);

            else if (sector.HasValue && sector.Value > 0)
                data = data.Where(c => c.School.LearningManagement.Governrate.SectorId == sector.Value);

            var committees = data.Select(c => new {
                Lm = c.School.LearningManagement.Title,
                c.Number,
                Name = c.School.Title,
                Type = c.CommitteType
            }).OrderBy(c => c.Number);

            return Ok(committees);
        }

    }
}
