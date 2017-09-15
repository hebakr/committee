using Committes.Models;
using Committes.Repositories.Persistence.Core;
using Committes.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Committes.WebApi.Controllers.api
{
    [Authorize]
    public class SectorsController : BaseApiController
    {

        public SectorsController(IUnitOfWork db)
        {
            _db = db;
        }
        
        // GET: api/Sectors
        public IEnumerable<Sector> Get()
        {
            return _db.SectorsRepository.List.OrderBy(s => s.Title).ToList();
        }

        // GET: api/Sectors/5
        public Sector Get(int id)
        {
            return _db.SectorsRepository.FindBy(id);
        }

        // POST: api/Sectors
        public Sector Post([FromBody]Sector sector)
        {
            _db.SectorsRepository.Add(sector);
            _db.Commit();

            return sector;
        }

        // PUT: api/Sectors/5
        public void Put([FromBody]Sector sector)
        {
            _db.SectorsRepository.Update(sector);

            _db.Commit();
        }

        // DELETE: api/Sectors/5
        [HttpDelete]
        public void Delete(int id)
        {
            _db.SectorsRepository.Remove(id);

            _db.Commit();
        }

        public IHttpActionResult AddGovernrate([FromBody]Governrate gov)
        {
            _db.GovernratesRepository.Add(gov);

            _db.Commit();

            return Ok(gov);
        }

        public IHttpActionResult UpdateGovernrate([FromBody]Governrate gov)
        {
            _db.GovernratesRepository.Update(gov);

            _db.Commit();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteGovernrate(int id)
        {
            try
            {
                _db.GovernratesRepository.Remove(id);

                _db.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult AddLM([FromBody]LearningManagement lm)
        {
            _db.LearningManagementsRepository.Add(lm);

            _db.Commit();

            return Ok(lm);
        }

        public IHttpActionResult UpdateLM([FromBody]LearningManagement lm)
        {
            _db.LearningManagementsRepository.Update(lm);

            _db.Commit();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteLM(int id)
        {
            try
            {
                _db.LearningManagementsRepository.Remove(id);

                _db.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult AddSchool([FromBody]School school)
        {
            _db.SchoolsRepository.Add(school);
            
            _db.Commit();

            return Ok(school);
        }

        public IHttpActionResult UpdateSchool([FromBody]School school)
        {
            _db.SchoolsRepository.Update(school);

            _db.Commit();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteSchool(int id)
        {
            try
            {
                _db.SchoolsRepository.Remove(id);

                _db.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
