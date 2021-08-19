using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Data.Entities;

namespace Task.Models
{
    public class OrganisationRelationshipViewModel
    {
        public int OrganisationRelationshipID { get; set; }
        public int OrganisationID { get; set; }
        public RelationshipType RelationshipType { get; set; }
    }
}
