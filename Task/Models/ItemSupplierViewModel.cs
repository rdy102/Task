using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class ItemSupplierViewModel
    {
        public int ItemSupplierID { get; set; }
        public Guid ItemID { get; set; }
        public int OrganisationID { get; set; }
    }
}
