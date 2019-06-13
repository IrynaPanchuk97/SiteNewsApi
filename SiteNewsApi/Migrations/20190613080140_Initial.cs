﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteNewsApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ModDate = table.Column<DateTime>(nullable: true),
                    CreateId = table.Column<int>(nullable: true),
                    ModId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_User_CreateId",
                        column: x => x.CreateId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true),
                    ModDate = table.Column<DateTime>(nullable: true),
                    CreateId = table.Column<int>(nullable: true),
                    ModId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_User_CreateId",
                        column: x => x.CreateId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_News_User_ModId",
                        column: x => x.ModId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersNews",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false),
                    IdNews = table.Column<int>(nullable: false),
                    LikedLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersNews", x => new { x.IdUser, x.IdNews });
                    table.ForeignKey(
                        name: "FK_UsersNews_News_IdNews",
                        column: x => x.IdNews,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersNews_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_CreateId",
                table: "News",
                column: "CreateId");

            migrationBuilder.CreateIndex(
                name: "IX_News_ModId",
                table: "News",
                column: "ModId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreateId",
                table: "User",
                column: "CreateId",
                unique: true,
                filter: "[CreateId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsersNews_IdNews",
                table: "UsersNews",
                column: "IdNews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersNews");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
