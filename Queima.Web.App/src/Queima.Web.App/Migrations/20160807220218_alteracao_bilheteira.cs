using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Queima.Web.App.Migrations
{
    public partial class alteracao_bilheteira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosVenda_Bilheteiras_BilheteiraId",
                table: "PontosVenda");

            migrationBuilder.DropIndex(
                name: "IX_PontosVenda_BilheteiraId",
                table: "PontosVenda");

            migrationBuilder.DropColumn(
                name: "BilheteiraId",
                table: "PontosVenda");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoIngressoSemanal",
                table: "Bilheteiras",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoIngressoSemanal",
                table: "Bilheteiras");

            migrationBuilder.AddColumn<int>(
                name: "BilheteiraId",
                table: "PontosVenda",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PontosVenda_BilheteiraId",
                table: "PontosVenda",
                column: "BilheteiraId");

            migrationBuilder.AddForeignKey(
                name: "FK_PontosVenda_Bilheteiras_BilheteiraId",
                table: "PontosVenda",
                column: "BilheteiraId",
                principalTable: "Bilheteiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
