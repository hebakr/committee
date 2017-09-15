using Committes.Repositories.Persistence.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Committes.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IUnitOfWork _db;

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);

            //if (_db != null)
            //    _db.Dispose();
        }

    }
}
