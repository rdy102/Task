using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Task.Data.Entities;
using Task.Data.Repository;

namespace Task.Controllers
{
    [Route("/organisationApi")]
    [ApiController]
    public class OrganisationApiController : Controller
    {
        private readonly IEntities db;

        public OrganisationApiController(IEntities entities)
        {
            db = entities;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Organisation>> GetAll()
        {
            try
            { 
                return Ok(db.GetAllProducts());
            }
            catch (Exception ex)
            {
                return BadRequest("Bad Request, failed to get products");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult GetOneOrganisation(int id)
        {
            Organisation getOneOrganisation = db.GetOrganisationById(id);
            return Ok(getOneOrganisation);
        }

        [HttpDelete("deleteOrganisation/{id:int}")]
        public ActionResult DeleteOrganisation(int id)
        {
            try
            {
                bool canDeleteOrganisation = db.CheckIfOrganisationHasBookingsOrItemSuppliers(id);
                Organisation organisation = db.GetOrganisationById(id);

                if (organisation == null)
                {
                    return NotFound("Requested Organisation does not exist");
                }
 
                if (canDeleteOrganisation)
                {
                    db.Delete(id);
                    return Ok(db.GetAllProducts());
                }

                return BadRequest($"Entity {id} can't be deleted - Requested Entity has more records in database. " + "\nPleasae check Item supplier and Bookings Organisation tables.");
            }
            catch (Exception)
            {
                return NotFound("Bad things happend");
            }

        }
    }
}
