using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDDDTest.Migrations
{
    /// <inheritdoc />
    public partial class addBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_Chinese = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Title_English = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Body_Chinese = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Body_English = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Blog", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Blog");
        }
    }
}
