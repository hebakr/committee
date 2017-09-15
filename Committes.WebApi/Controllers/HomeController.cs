using Committes.Repositories.Persistence.Core;
using Committes.Web.Helpers;
using Committes.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Committes.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _db;

        public HomeController(IUnitOfWork db)
        {
            _db = db;
        }


        // GET: Home
        public ActionResult Index()
        {
            return Redirect("/index.html");
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult DownloadAssignmentLetters(int id)
        {
            var committee = _db.CommitteesRepository.FindBy(id);
            //Response.Headers.Add("Content-Type", "application/msword");
            //Response.Headers.Add("Content-Disposition", $"attachment; filename='committee-{committee.Number}.doc");
            return View(committee);
        }

        public ActionResult DownloadAssignmentLetterForMember(int member)
        {
            var model = _db.MembersRepository.FindBy(member);
            //Response.Headers.Add("Content-Type", "application/msword");
            //Response.Headers.Add("Content-Disposition", $"attachment; filename='committee-{committee.Number}.doc");
            return View(model);
        }

        public ActionResult ComitteeStructure(int id, string format = "", byte part = 1)
        {
            var committee = _db.CommitteesRepository.FindBy(id);

            var committeeVM = new CommitteeVM(committee);
            //Response.Hea  ders.Clear();
            //Response.Headers.Add("Content-Type", "application/msword");
            //Response.Headers.Add("Content-Disposition", $"attachment; filename='committee-{committee.Number}.doc");
            if (format.Equals("msword")) {
                var fileName = Server.MapPath(ConfigurationManager.AppSettings["reportFiles"] + "report1.docx");

                Helpers.ReportGenerator.CreateDoc(fileName, committeeVM, part);
                return File(fileName, "application/msword", $"ComitteeStructure{id}-{DateTime.Now}-{part}.docx");
            }

            return View(committeeVM);
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);

            //if (_db != null)
            //    _db.Dispose();
        }

    }
}