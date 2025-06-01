using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeavyApps.Blog.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Biografia = table.Column<string>(type: "varchar(100)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", maxLength: 200, nullable: false),
                    SubTitulo = table.Column<string>(type: "varchar(100)", maxLength: 200, nullable: false),
                    Corpo = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fonte = table.Column<string>(type: "varchar(100)", nullable: false),
                    AutorID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(100)", nullable: false),
                    Categoria = table.Column<string>(type: "varchar(100)", nullable: false),
                    Resumo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Link = table.Column<string>(type: "varchar(100)", nullable: false),
                    Likes = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Posts_Autores_AutorID",
                        column: x => x.AutorID,
                        principalTable: "Autores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AutorID",
                table: "Posts",
                column: "AutorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
