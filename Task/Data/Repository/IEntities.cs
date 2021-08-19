using System.Collections.Generic;
using Task.Data.Entities;

namespace Task.Data.Repository
{
    public interface IEntities
    {
        IEnumerable<Organisation> GetAllProducts();
        Organisation GetOrganisationById(int id);
        public bool SaveAll();
      
        void Delete(int id);
    }

}