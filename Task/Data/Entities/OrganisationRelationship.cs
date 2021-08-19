using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Data.Entities
{
    public class OrganisationRelationship
    {
        //Organisation Relationship Table
        //OrganisationRelationship – table name
        //OrganisationRelationshipID- field
        //OrganisationID- field
        //RelationshipType- field
        [Key]
        public int OrganisationRelationshipID { get; set; }
        public int OrganisationID { get; set; }
        public RelationshipType RelationshipType { get; set; }


    }
}
