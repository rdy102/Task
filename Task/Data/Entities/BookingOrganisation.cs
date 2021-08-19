using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Data.Entities
{
    public class BookingOrganisation
    {
        //Booking Organisation Join Table
        //BookingOrganisation – table name
        //BookingOrganisationID - field
        //OrganisationID - field
        //BookingID - field
       
        public int BookingOrganisationID { get; set; }
       
        public int OrganisationID { get; set; }
        public Guid BookingID { get; set; }
        
        
    }
}
