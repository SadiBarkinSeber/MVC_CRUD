﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_CRUD.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 1, "Kadıköy", "Kadıköy Anadolu Lisesi" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 2, "Kartal", "Kartal Anadolu Lisesi" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 3, "Pendik", "Pendik Anadolu Lisesi" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 1, "Öğrenci 1", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 2, "Öğrenci 2", 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 3, "Öğrenci 3", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
