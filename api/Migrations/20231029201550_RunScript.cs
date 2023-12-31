﻿using System.Globalization;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RunScript : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var migrationAttribute = (MigrationAttribute)this.GetType()
            .GetCustomAttributes(typeof(MigrationAttribute), false)
            .Single();

            migrationBuilder.Sql(File.ReadAllText(string.Format(
                CultureInfo.InvariantCulture,
                "{1}{0}Migrations{0}{2}",
                Path.DirectorySeparatorChar,
                AppContext.BaseDirectory,
                $"{migrationAttribute.Id}.sql")));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
