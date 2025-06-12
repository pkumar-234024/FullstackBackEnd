using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiLearning.Infrastructure.Migrations;

  /// <inheritdoc />
  public partial class AddTableClients : Migration
  {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.CreateTable(
              name: "Clients",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                  ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                  CreatedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                  ModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Clients", x => x.Id);
              });

          migrationBuilder.CreateTable(
              name: "Projects",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  ProjectStatus = table.Column<int>(type: "int", nullable: false),
                  PriorityLevel = table.Column<int>(type: "int", nullable: false),
                  ClientId = table.Column<int>(type: "int", nullable: true),
                  ProjectManagerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  TotalTimeLogged = table.Column<double>(type: "float", nullable: false),
                  ClientsId = table.Column<int>(type: "int", nullable: true),
                  CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                  ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                  CreatedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                  ModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Projects", x => x.Id);
                  table.ForeignKey(
                      name: "FK_Projects_Clients_ClientsId",
                      column: x => x.ClientsId,
                      principalTable: "Clients",
                      principalColumn: "Id");
              });

          migrationBuilder.CreateTable(
              name: "TasksItems",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                  Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  AssignedToUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  EstimatedHours = table.Column<double>(type: "float", nullable: false),
                  LoggedHours = table.Column<double>(type: "float", nullable: false),
                  ProjectsId = table.Column<int>(type: "int", nullable: true),
                  CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                  ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                  CreatedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                  ModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_TasksItems", x => x.Id);
                  table.ForeignKey(
                      name: "FK_TasksItems_Projects_ProjectsId",
                      column: x => x.ProjectsId,
                      principalTable: "Projects",
                      principalColumn: "Id");
              });

          migrationBuilder.CreateTable(
              name: "TeamMember",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  ProjectId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  ProjectsId = table.Column<int>(type: "int", nullable: true),
                  CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                  ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                  CreatedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                  ModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_TeamMember", x => x.Id);
                  table.ForeignKey(
                      name: "FK_TeamMember_Projects_ProjectsId",
                      column: x => x.ProjectsId,
                      principalTable: "Projects",
                      principalColumn: "Id");
              });

          migrationBuilder.CreateIndex(
              name: "IX_Projects_ClientsId",
              table: "Projects",
              column: "ClientsId");

          migrationBuilder.CreateIndex(
              name: "IX_TasksItems_ProjectsId",
              table: "TasksItems",
              column: "ProjectsId");

          migrationBuilder.CreateIndex(
              name: "IX_TeamMember_ProjectsId",
              table: "TeamMember",
              column: "ProjectsId");
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropTable(
              name: "TasksItems");

          migrationBuilder.DropTable(
              name: "TeamMember");

          migrationBuilder.DropTable(
              name: "Projects");

          migrationBuilder.DropTable(
              name: "Clients");
      }
  }
