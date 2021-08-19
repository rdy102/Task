using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Entities;

namespace Task.Data.Repository
{
    public class Entities : IEntities
    {
        private readonly TaskContext _context;

        public Entities(TaskContext entities)
        {
            _context = entities;
        }

       

        public IEnumerable<BookingOrganisation> GetAllBookings()
        {
            return _context.BookingOrganisations.ToList();
        }

        public IEnumerable<Organisation> GetAllProducts()
        {
            // Compare Id from BO and IS 
            var results = _context.Organisations.Include(n => n.OrganisationNumbers)
                .Include(o => o.OrganisationRelationships)
                .Include(c => c.ContactRelationships)
                .OrderBy(i => i.OrganisationName).ToList();
            return results;

        }
        public Organisation GetOrganisationById(int id)
        {
            Organisation result = _context.Organisations.Find(id);
            
            return result;
        }


        public void Delete(int id) {

           

            //if in check list ID does not exist
            List<BookingOrganisation> checkListBookingTable = _context.BookingOrganisations.ToList();
            List<ItemSupplier> checkListItemSupplierTable = _context.ItemSuppliers.ToList();


            if (!checkListBookingTable.Any(i => i.OrganisationID == id) &&
                !checkListItemSupplierTable.All(i => i.OrganisationID == id))
            {

                ContactRelationship contactRelationshipToDelete = _context.ContactRelationships
                    .FirstOrDefault(i => i.OrganisationID == id);

                OrganisationNumber organisationNumberToDelete = _context.OrganisationNumbers
                    .FirstOrDefault(i => i.OrganisationID == id);

                OrganisationRelationship organisationRelationshipToDel = _context.OrganisationRelationships
                    .FirstOrDefault(i => i.OrganisationID == id);

                Organisation organisationToDelete = _context.Organisations
                    .FirstOrDefault(i => i.OrganisationID == id);



                if (contactRelationshipToDelete != null) _context.ContactRelationships.Remove(contactRelationshipToDelete);
                if (organisationNumberToDelete != null) _context.OrganisationNumbers.Remove(organisationNumberToDelete);
                if (organisationRelationshipToDel != null) _context.OrganisationRelationships.Remove(organisationRelationshipToDel);
                if (organisationToDelete != null) _context.Organisations.Remove(organisationToDelete);

                _context.SaveChanges();

            }
                   
            }

     
        public bool SaveAll()
        {
            
            return _context.SaveChanges() > 0;
        }

    }
}

