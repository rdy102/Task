using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Data.Entities
{
    public class OrganisationNumber
    {
        //Organisation Number Table
        //OrganisationNumber – table name
        //OrganisationNumberID - field
        //OrganisationID - field
        //OrganisationNumber - field

        public int OrganisationNumberID { get; set; }
     
        public Guid OrganisationNum { get; set; }

        //public int OrganisationID { get; set; }
        public int OrganisationID { get; set; }
        
        //public ICollection<Organisation> Organisations { get; set; }
    }
}
