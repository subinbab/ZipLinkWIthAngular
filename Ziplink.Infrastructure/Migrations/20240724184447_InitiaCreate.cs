using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ziplink.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitiaCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entityUrl",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    generatedUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shortenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifieddby = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entityUrl", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entityUrl");
        }
    }
}
