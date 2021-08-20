using System;

namespace Task.Data.Entities
{
    public class BookingOrganisation
    {   
        public int BookingOrganisationID { get; set; }  
        public int OrganisationID { get; set; }
        public Guid BookingID { get; set; }
    }
}
