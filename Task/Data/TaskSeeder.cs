using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Task.Data.Entities;

namespace Task.Data
{
    public class TaskSeeder
    {
        private readonly TaskContext _context;
        private readonly IWebHostEnvironment _env;

        public TaskSeeder(TaskContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();


            if (!_context.Organisations.Any())
            {
                /// create sample data
                /// 
                var filePath = Path.Combine(_env.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filePath);
                var organisation = JsonSerializer.Deserialize<IEnumerable<Organisation>>(json);

                _context.Organisations.AddRange(organisation);
                _context.SaveChanges();


                ////Seed OrganisationBooking
                ///
                List<BookingOrganisation> bookingOrganisationsList = new List<BookingOrganisation>();
                foreach (var item in organisation)
                {
                    int id = item.OrganisationID;

                    BookingOrganisation bo = new BookingOrganisation()
                    {
                        OrganisationID = id,
                        BookingID = Guid.NewGuid()
                    };
                    bookingOrganisationsList.Add(bo);
                }
                _context.AddRange(bookingOrganisationsList);
                _context.SaveChanges();

                ///Seed ItemSupplier
                ///

                List<ItemSupplier> itemSupplierList = new List<ItemSupplier>();
                foreach (var item in organisation)
                {
                    int id = item.OrganisationID;

                    ItemSupplier itemSupplier = new ItemSupplier()
                    {
                        ItemID = Guid.NewGuid(),
                        OrganisationID = id
                    };
                    itemSupplierList.Add(itemSupplier);


                }
                _context.AddRange(itemSupplierList);
                _context.SaveChanges();

                ///Seed Organisation number
                ///
                List<OrganisationNumber> organisationNumbersList = new List<OrganisationNumber>();

                foreach (var item in organisation)
                {
                    int id = item.OrganisationID;
                    OrganisationNumber organisationNumber = new OrganisationNumber()
                    {
                        OrganisationID = item.OrganisationID,
                        OrganisationNum = Guid.NewGuid()
                    };



                    organisationNumbersList.Add(organisationNumber);
                    
                }
                    _context.AddRange(organisationNumbersList);
                    _context.SaveChanges();

                //Seed OrganisationRelationship
                ///
                List<OrganisationRelationship> organisationRelationShipList = new List<OrganisationRelationship>();

                foreach (var item in organisation)
                {
                    
                    OrganisationRelationship organisationRel = new OrganisationRelationship()
                    {
                        OrganisationID = item.OrganisationID,
                        RelationshipType = RelationshipType.OneToManyRelationship
                    };



                    organisationRelationShipList.Add(organisationRel);

                }
                _context.AddRange(organisationRelationShipList);
                _context.SaveChanges();

                // Seed ConctactRelationshp

                List<ContactRelationship> contactRelList = new List<ContactRelationship>();

                foreach (var item in organisation)
                {
                    ContactRelationship contactRel = new ContactRelationship()
                    {
                        OrganisationID = item.OrganisationID,
                        ContactID = Guid.NewGuid(),
                        RelationshipType = RelationshipType.OneToManyRelationship
                    };

                    contactRelList.Add(contactRel);
                }
                _context.AddRange(contactRelList);
                _context.SaveChanges();

            }




           






        }

    }


    }

