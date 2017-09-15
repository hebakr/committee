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
    public class SpecialitiesController : ApiController
    {
        private readonly IUnitOfWork _db;

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
        public Speciality Post([FromBody]Speciality speciality)
        {
            _db.SpecialitiesRepository.Add(speciality);
            _db.Commit();

            return speciality;

        }

        // PUT: api/Specialities/5
        public void Put([FromBody]Speciality speciality)
        {
            _db.SpecialitiesRepository.Update(speciality);
            _db.Commit();

        }

        // DELETE: api/Specialities/5
        public void Delete(int id)
        {
            _db.SpecialitiesRepository.Remove(id);

            _db.Commit();
        }
    }
}
