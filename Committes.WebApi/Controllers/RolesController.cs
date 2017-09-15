using Committes.Models;
using Committes.Repositories.Persistence.Core;
using Committes.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Committes.WebApi.Controllers.api
{
    [Authorize]
    public class RolesController : BaseApiController
    {

        public RolesController(IUnitOfWork db)
        {
            _db = db;
        }

        // GET: api/Jobs
        public IEnumerable<CommitteRole> Get()
        {
            return _db.RolesRepository.List.OrderBy(s => s.Title).ToList();
        }

        // GET: api/Jobs/5
        public CommitteRole Get(int id)
        {
            return _db.RolesRepository.FindBy(id);
        }

        // POST: api/Jobs
        public CommitteRole Post([FromBody]CommitteRole role)
        {
            _db.RolesRepository.Add(role);
            _db.Commit();

            return role;

        }

        // PUT: api/Jobs/5
        public IHttpActionResult Put([FromBody]RoleDto role)
        {
            var r = _db.RolesRepository.FindBy(role.Id);

            r.Title = role.Title;

            _db.Commit();

            return Ok();

        }

        // DELETE: api/Jobs/5
        public IHttpActionResult Delete(int id)
        {
            _db.RolesRepository.Remove(id);

            _db.Commit();

            return Ok();
        }
    }
}
