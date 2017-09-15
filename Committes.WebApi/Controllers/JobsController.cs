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
    public class JobsController : BaseApiController
    {

        public JobsController(IUnitOfWork db)
        {
            _db = db;
        }

        // GET: api/Jobs
        public IEnumerable<Job> Get()
        {
            return _db.JobsRepository.List.OrderBy(s => s.Title).ToList();
        }

        // GET: api/Jobs/5
        public Speciality Get(int id)
        {
            return _db.SpecialitiesRepository.FindBy(id);
        }

        // POST: api/Jobs
        public IHttpActionResult Post([FromBody]Job job)
        {
            _db.JobsRepository.Add(job);
            _db.Commit();

            return Ok();

        }

        // PUT: api/Jobs/5
        public IHttpActionResult Put([FromBody]JobDto job)
        {
            var j = _db.JobsRepository.FindBy(job.Id);
            j.Title = job.Title;

            _db.Commit();

            return Ok();

        }

        // DELETE: api/Jobs/5
        public void Delete(int id)
        {
            _db.JobsRepository.Remove(id);

            _db.Commit();
        }
    }
}
