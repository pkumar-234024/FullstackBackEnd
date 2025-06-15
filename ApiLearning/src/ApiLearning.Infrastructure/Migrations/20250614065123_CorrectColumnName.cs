using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiLearning.Infrastructure.Migrations;

  /// <inheritdoc />
  public partial class CorrectColumnName : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.AlterColumn<string>(
              name: "ModifiedBy",
              table: "TeamMember",
              type: "nvarchar(max)",
              nullable: false,
              oldClrType: typeof(DateTime),
              oldType: "datetime2");

          migrationBuilder.AlterColumn<string>(
              name: "CreatedBy",
              table: "TeamMember",
              type: "nvarchar(max)",
              nullable: false,
              oldClrType: typeof(DateTime),
              oldType: "datetime2");

          migrationBuilder.AlterColumn<string>(
              name: "ModifiedBy",
              table: "TasksItems",
              type: "nvarchar(max)",
              nullable: false,
              oldClrType: typeof(DateTime),
              oldType: "datetime2");

          migrationBuilder.AlterColumn<string>(
              name: "CreatedBy",
              table: "TasksItems",
              type: "nvarchar(max)",
              nullable: false,
              oldClrType: typeof(DateTime),
              oldType: "datetime2");

          migrationBuilder.AlterColumn<string>(
              name: "ModifiedBy",
              table: "Projects",
              type: "nvarchar(max)",
              nullable: false,
              oldClrType: typeof(DateTime),
              oldType: "datetime2");

          migrationBuilder.AlterColumn<string>(
              name: "CreatedBy",
              table: "Projects",
              type: "nvarchar(max)",
              nullable: false,
              oldClrType: typeof(DateTime),
              oldType: "datetime2");

          migrationBuilder.AlterColumn<string>(
              name: "ModifiedBy",
              table: "Clients",
              type: "nvarchar(max)",
              nullable: false,
              oldClrType: typeof(DateTime),
              oldType: "datetime2");

          migrationBuilder.AlterColumn<string>(
              name: "CreatedBy",
              table: "Clients",
              type: "nvarchar(max)",
              nullable: false,
              oldClrType: typeof(DateTime),
              oldType: "datetime2");

          migrationBuilder.CreateTable(
              name: "AuditEntry",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                  EntityId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  UserId = table.Column<int>(type: "int", nullable: true),
                  Ipaddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_AuditEntry", x => x.Id);
              });

          migrationBuilder.CreateTable(
              name: "AuditEntryDetail",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  AuditEntryId = table.Column<int>(type: "int", nullable: true),
                  FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  OldValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  NewValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_AuditEntryDetail", x => x.Id);
                  table.ForeignKey(
                      name: "FK_AuditEntryDetail_AuditEntry_AuditEntryId",
                      column: x => x.AuditEntryId,
                      principalTable: "AuditEntry",
                      principalColumn: "Id");
              });

          migrationBuilder.CreateIndex(
              name: "IX_AuditEntryDetail_AuditEntryId",
              table: "AuditEntryDetail",
              column: "AuditEntryId");
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropTable(
              name: "AuditEntryDetail");

          migrationBuilder.DropTable(
              name: "AuditEntry");

          migrationBuilder.AlterColumn<DateTime>(
              name: "ModifiedBy",
              table: "TeamMember",
              type: "datetime2",
              nullable: false,
              oldClrType: typeof(string),
              oldType: "nvarchar(max)");

          migrationBuilder.AlterColumn<DateTime>(
              name: "CreatedBy",
              table: "TeamMember",
              type: "datetime2",
              nullable: false,
              oldClrType: typeof(string),
              oldType: "nvarchar(max)");

          migrationBuilder.AlterColumn<DateTime>(
              name: "ModifiedBy",
              table: "TasksItems",
              type: "datetime2",
              nullable: false,
              oldClrType: typeof(string),
              oldType: "nvarchar(max)");

          migrationBuilder.AlterColumn<DateTime>(
              name: "CreatedBy",
              table: "TasksItems",
              type: "datetime2",
              nullable: false,
              oldClrType: typeof(string),
              oldType: "nvarchar(max)");

          migrationBuilder.AlterColumn<DateTime>(
              name: "ModifiedBy",
              table: "Projects",
              type: "datetime2",
              nullable: false,
              oldClrType: typeof(string),
              oldType: "nvarchar(max)");

          migrationBuilder.AlterColumn<DateTime>(
              name: "CreatedBy",
              table: "Projects",
              type: "datetime2",
              nullable: false,
              oldClrType: typeof(string),
              oldType: "nvarchar(max)");

          migrationBuilder.AlterColumn<DateTime>(
              name: "ModifiedBy",
              table: "Clients",
              type: "datetime2",
              nullable: false,
              oldClrType: typeof(string),
              oldType: "nvarchar(max)");

          migrationBuilder.AlterColumn<DateTime>(
              name: "CreatedBy",
              table: "Clients",
              type: "datetime2",
              nullable: false,
              oldClrType: typeof(string),
              oldType: "nvarchar(max)");
      }
  }
