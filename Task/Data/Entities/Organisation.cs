using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Data.Entities
{
    public class Organisation
    {

       
        
        public int OrganisationID { get; set; }
        [Required]
        [MaxLength(50)]
        public string OrganisationName { get; set; }

       
        public ICollection<OrganisationNumber> OrganisationNumbers { get; set; }
        public ICollection<OrganisationRelationship> OrganisationRelationships { get; set; }
        public ICollection<ContactRelationship> ContactRelationships { get; set; }
    }
}
