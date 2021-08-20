using System;

namespace Task.Data.Entities
{
    public class ItemSupplier
    {      
        public int ItemSupplierID { get; set; }
        public Guid ItemID { get; set; }
        public int OrganisationID { get; set; }
    }
}
