using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class BookingOrganisationViewModel
    {
        public int BookingOrganisationID { get; set; }
        public int OrganisationID { get; set; }
        public Guid BookingID { get; set; }
    }
}
