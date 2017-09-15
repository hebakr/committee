using Committes.Models;
using Committes.Repositories.Persistence.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Committes.Web.Controllers.api
{
    public class JobsController : ApiController
    {
        private readonly IUnitOfWork _db;

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
        public Job Post([FromBody]Job job)
        {
            _db.JobsRepository.Add(job);
            _db.Commit();

            return job;

        }

        // PUT: api/Jobs/5
        public void Put([FromBody]Job job)
        {
            _db.JobsRepository.Update(job);
            _db.Commit();

        }

        // DELETE: api/Jobs/5
        public void Delete(int id)
        {
            _db.JobsRepository.Remove(id);

            _db.Commit();
        }
    }
}
