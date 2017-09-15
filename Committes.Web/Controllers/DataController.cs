using Committes.Repositories.Persistence.Core;
using Committes.Services.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Committes.Web.Controllers
{
    public class DataController : Controller
    {
        private readonly IAppService _appService;
        private readonly ICommitteesService _committeesService;

        public DataController(IAppService appService, ICommitteesService committeesService)
        {
            _appService = appService;
            _committeesService = committeesService;
        }
        
        // GET: Data
        public ActionResult Index()
        {
            return Json(_appService.GetAllSectors(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Committees()
        {
            return Json(_committeesService.GetAllCommittes(), JsonRequestBehavior.AllowGet);
        }
    }
}