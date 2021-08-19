using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task.Migrations
{
    public partial class INITIALDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Organisations",
              columns: table => new
              {
                  OrganisationID = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  OrganisationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Organisations", x => x.OrganisationID);
              });

            migrationBuilder.CreateTable(
                name: "BookingOrganisations",
                columns: table => new
                {
                    BookingOrganisationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationID = table.Column<int>(type: "int", nullable: false),
                    BookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingOrganisations", x => x.BookingOrganisationID);
                });

            migrationBuilder.CreateTable(
                name: "ContactRelationships",
                columns: table => new
                {
                    ContactRelationshipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelationshipType = table.Column<int>(type: "int", nullable: false),
                    OrganisationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactRelationships", x => x.ContactRelationshipID);
                    table.ForeignKey(
                       name: "FK_ContactRelationships_Organisations_OrganisationID",
                       column: x => x.OrganisationID,
                       principalTable: "Organisations",
                       principalColumn: "OrganisationID");
                });

            migrationBuilder.CreateTable(
                name: "ItemSuppliers",
                columns: table => new
                {
                    ItemSupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganisationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSuppliers", x => x.ItemSupplierID);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationRelationships",
                columns: table => new
                {
                    OrganisationRelationshipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationID = table.Column<int>(type: "int", nullable: false),
                    RelationshipType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationRelationships", x => x.OrganisationRelationshipID);
                    table.ForeignKey(
                    name: "FK_OrganisationRelationships_Organisations_OrganisationID",
                    column: x => x.OrganisationID,
                    principalTable: "Organisations",
                    principalColumn: "OrganisationID");
                });



            migrationBuilder.CreateTable(
                name: "OrganisationNumbers",
                columns: table => new
                {
                    OrganisationNumberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganisationNum = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganisationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationNumbers", x => x.OrganisationNumberID);
                    table.ForeignKey(
                        name: "FK_OrganisationNumbers_Organisations_OrganisationID",
                        column: x => x.OrganisationID,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationNumbers_OrganisationID",
                table: "OrganisationNumbers",
                column: "OrganisationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingOrganisations");

            migrationBuilder.DropTable(
                name: "ContactRelationships");

            migrationBuilder.DropTable(
                name: "ItemSuppliers");

            migrationBuilder.DropTable(
                name: "OrganisationNumbers");

            migrationBuilder.DropTable(
                name: "OrganisationRelationships");

            migrationBuilder.DropTable(
                name: "Organisations");
        }
    }
}
