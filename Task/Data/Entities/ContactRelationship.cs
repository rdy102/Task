using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Data.Entities
{
    public class ContactRelationship
    {

        //Contact Relationship Table
        //ContactRelationship – table name
        //ContactRelationshipID - field
        //ContactID - field
        //RelationshipType - field
        //OrganisationID - field
        
        public int ContactRelationshipID { get; set; }
        public Guid ContactID { get; set; }
        
        public RelationshipType RelationshipType{ get; set; }
        public int OrganisationID { get; set; }

    }
}
