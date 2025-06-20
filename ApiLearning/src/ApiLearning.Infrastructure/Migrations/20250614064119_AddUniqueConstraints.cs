﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiLearning.Infrastructure.Migrations;

  /// <inheritdoc />
  public partial class AddUniqueConstraints : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.AlterColumn<string>(
              name: "Name",
              table: "Projects",
              type: "nvarchar(450)",
              nullable: false,
              oldClrType: typeof(string),
              oldType: "nvarchar(max)");

          migrationBuilder.CreateIndex(
              name: "IX_Projects_Name",
              table: "Projects",
              column: "Name",
              unique: true);
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropIndex(
              name: "IX_Projects_Name",
              table: "Projects");

          migrationBuilder.AlterColumn<string>(
              name: "Name",
              table: "Projects",
              type: "nvarchar(max)",
              nullable: false,
              oldClrType: typeof(string),
              oldType: "nvarchar(450)");
      }
  }
