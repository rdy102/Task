using System;

namespace Task.Data.Entities
{
    public class ContactRelationship
    {
        public int ContactRelationshipID { get; set; }
        public Guid ContactID { get; set; }     
        public RelationshipType RelationshipType{ get; set; }
        public int OrganisationID { get; set; }
    }
}
