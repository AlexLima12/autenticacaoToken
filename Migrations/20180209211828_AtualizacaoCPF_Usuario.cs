using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace modelobasicoefjwt.Migrations
{
    public partial class AtualizacaoCPF_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Usuarios",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Usuarios");
        }
    }
}
