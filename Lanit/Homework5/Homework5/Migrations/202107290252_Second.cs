using Homework5.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework5.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("202107290252_Second")]
    public class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Users",
               columns: table => new
               {
                   ID = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(type: "nvarchar(16)", nullable: false),
                   Surname = table.Column<string>(type: "nvarchar(16)", nullable: false),
                   Age = table.Column<int>(type: "int", nullable: false),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Users", x => x.ID);
               });
        }
    }
}
