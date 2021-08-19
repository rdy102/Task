using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Entities;

namespace Task.Models
{
    public class ContactRelationshipViewModel
    {
        public int ContactRelationshipID { get; set; }
        public Guid ContactID { get; set; }

        public RelationshipType RelationshipType { get; set; }
        public int OrganisationID { get; set; }
    }
}
