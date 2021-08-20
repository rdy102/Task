using System.ComponentModel.DataAnnotations;

namespace Task.Data.Entities
{
    public class OrganisationRelationship
    {
        [Key]
        public int OrganisationRelationshipID { get; set; }
        public int OrganisationID { get; set; }
        public RelationshipType RelationshipType { get; set; }
    }
}
