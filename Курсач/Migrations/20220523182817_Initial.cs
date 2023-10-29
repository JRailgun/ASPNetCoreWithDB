﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Курсач.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Телефонный справочник",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    s_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    t_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Телефонный справочник", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Телефонный справочник");
        }
    }
}
