using Committes.Repositories.Persistence.Core;
using Committes.Web.Helpers;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Committes.Web.Controllers.api
{
    public abstract class BaseApiController : ApiController
    {

        public BaseApiController()
        {

            var kernel = new Ninject.StandardKernel();

            kernel.Inject(this);
        }
        [Inject]
        protected IUnitOfWork Db { get; set; }

        [Inject]
        protected Mapper Mapper { get; set; }

    }

}
