using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Data.Entities
{
    public class ItemSupplier
    {
        //Item Supplier Table
        //ItemSupplier – table name
        //ItemSupplierID - field
        //ItemID - field
        //OrganisationID - field

        public int ItemSupplierID { get; set; }
        public Guid ItemID { get; set; }
        public int OrganisationID { get; set; }

    }
}
