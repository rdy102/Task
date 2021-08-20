using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(int id)
        {
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

        public bool CheckIfOrganisationHasBookingsOrItemSuppliers(int id)
        {
            ItemSupplier checkItemSuppliers = _context.ItemSuppliers.FirstOrDefault(i => i.OrganisationID == id);
            BookingOrganisation checkBookingsOrganisation = _context.BookingOrganisations.FirstOrDefault(i => i.OrganisationID == id);
            
            if (checkItemSuppliers == null && checkBookingsOrganisation == null) 
            {
                return true ;
            }

            return false;
        }
    }
}

