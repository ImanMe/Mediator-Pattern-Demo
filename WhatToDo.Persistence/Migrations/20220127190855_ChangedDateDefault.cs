using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatToDo.Persistence.Migrations
{
    public partial class ChangedDateDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ToDoItems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 27, 14, 2, 45, 512, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ToDoItems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 1, 27, 14, 2, 45, 512, DateTimeKind.Local).AddTicks(1036));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ToDoItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 27, 14, 2, 45, 512, DateTimeKind.Local).AddTicks(1336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ToDoItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 27, 14, 2, 45, 512, DateTimeKind.Local).AddTicks(1036),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");
        }
    }
}
