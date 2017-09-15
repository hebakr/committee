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
    public class SpecialitiesController : BaseApiController
    {
        public SpecialitiesController(IUnitOfWork db)
        {
            _db = db;
        }

        // GET: api/Specialities
        public IEnumerable<Speciality> Get()
        {
            return _db.SpecialitiesRepository.List.OrderBy(s => s.Name).ToList();
        }

        // GET: api/Specialities/5
        public Speciality Get(int id)
        {
            return _db.SpecialitiesRepository.FindBy(id);
        }

        // POST: api/Specialities
        public IHttpActionResult Post([FromBody]Speciality speciality)
        {
            _db.SpecialitiesRepository.Add(speciality);
            _db.Commit();

            return Ok(speciality);

        }

        // PUT: api/Specialities/5
        public IHttpActionResult Put([FromBody]SpecialityDto speciality)
        {
            var s = _db.SpecialitiesRepository.FindBy(speciality.Id);
            s.Name = speciality.Name;
            _db.Commit();

            return Ok();
        }

        // DELETE: api/Specialities/5
        public IHttpActionResult Delete(int id)
        {
            _db.SpecialitiesRepository.Remove(id);

            _db.Commit();

            return Ok();
        }
    }
}
