using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Data;
using Task.Data.Entities;
using Task.Data.Repository;

namespace Task.Controllers
{  
    [Route("/organisationApi/[action]")]
    [ApiController]
    public class OrganisationApiController : Controller
    {
        private readonly IEntities db;

        public OrganisationApiController(IEntities entities)
        {
            db = entities;
        }
        
        [HttpGet]
        public ActionResult <IEnumerable<Organisation>>GetAll()
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


        [HttpDelete("{id:int}")]
        public ActionResult DeleteOrganisation(int id) 
        {
            try
            {
                Organisation checkIfExists = db.GetOrganisationById(id);

                if (checkIfExists != null) {
                    db.Delete(id);
                    return Ok(db.GetAllProducts());
                }
                else 
                {
                    return NotFound("Requested Organisation does not exist");
                }
       
            }
            catch (Exception)
            {
                return NotFound("Entity can't be deleted");
            }
            

           
            
            
            
        }
    }
}
