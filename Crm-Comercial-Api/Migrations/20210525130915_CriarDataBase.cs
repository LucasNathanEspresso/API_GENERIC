using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crm.Comercial.Api.Migrations
{
    public partial class CriarDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_CONTATO",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    DD = table.Column<string>(maxLength: 3, nullable: false),
                    NumTelefone = table.Column<string>(maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CONTATO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_LOGIN",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeUsr = table.Column<string>(maxLength: 100, nullable: false),
                    Senha = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_LOGIN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_MENU",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Classe = table.Column<string>(nullable: true),
                    Visible = table.Column<bool>(nullable: false),
                    IconColor = table.Column<string>(nullable: true),
                    FlagAtivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_MENU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PERFIL",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Flag = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DtCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PERFIL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_VALIDACAO",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodValidacao = table.Column<string>(nullable: false),
                    DtCadastro = table.Column<DateTime>(nullable: false),
                    DtEnvio = table.Column<DateTime>(nullable: false),
                    DtValidacao = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_VALIDACAO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USUARIO",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true),
                    NomeFatasia = table.Column<string>(nullable: true),
                    DtNascimento = table.Column<DateTime>(nullable: false),
                    DtCadastro = table.Column<DateTime>(nullable: false),
                    FlgAtivo = table.Column<bool>(nullable: false),
                    LoginId = table.Column<long>(nullable: false),
                    ContatoId = table.Column<long>(nullable: true),
                    PerfilId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USUARIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_USUARIO_TBL_CONTATO_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "TBL_CONTATO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBL_USUARIO_TBL_LOGIN_LoginId",
                        column: x => x.LoginId,
                        principalTable: "TBL_LOGIN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_VINCULO_MENU",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MenuId = table.Column<long>(nullable: false),
                    PerfilId = table.Column<long>(nullable: true),
                    Visualizar = table.Column<bool>(nullable: false),
                    Criar = table.Column<bool>(nullable: false),
                    Editar = table.Column<bool>(nullable: false),
                    Deletar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_VINCULO_MENU", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_VINCULO_MENU_TBL_MENU_MenuId",
                        column: x => x.MenuId,
                        principalTable: "TBL_MENU",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_USUARIO_ContatoId",
                table: "TBL_USUARIO",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_USUARIO_LoginId",
                table: "TBL_USUARIO",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_VINCULO_MENU_MenuId",
                table: "TBL_VINCULO_MENU",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_PERFIL");

            migrationBuilder.DropTable(
                name: "TBL_USUARIO");

            migrationBuilder.DropTable(
                name: "TBL_VALIDACAO");

            migrationBuilder.DropTable(
                name: "TBL_VINCULO_MENU");

            migrationBuilder.DropTable(
                name: "TBL_CONTATO");

            migrationBuilder.DropTable(
                name: "TBL_LOGIN");

            migrationBuilder.DropTable(
                name: "TBL_MENU");
        }
    }
}
