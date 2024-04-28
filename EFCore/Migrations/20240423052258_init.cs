using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Book",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Node",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Node", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Node_T_Node_ParentId",
                        column: x => x.ParentId,
                        principalTable: "T_Node",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_Person",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Student",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Teacher",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_USER",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_USER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Comment_T_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "T_Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_PersonCard",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PersonCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_PersonCard_T_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "T_Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "T_Student_Teacher_Relationship",
                columns: table => new
                {
                    StudentsId = table.Column<long>(type: "bigint", nullable: false),
                    TeachersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Student_Teacher_Relationship", x => new { x.StudentsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_T_Student_Teacher_Relationship_T_Student_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "T_Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Student_Teacher_Relationship_T_Teacher_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "T_Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_Bill_Leave",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequesterId = table.Column<long>(type: "bigint", nullable: false),
                    ApproverId = table.Column<long>(type: "bigint", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Bill_Leave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Bill_Leave_T_USER_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "T_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_Bill_Leave_T_USER_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "T_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Bill_Leave_ApproverId",
                table: "T_Bill_Leave",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Bill_Leave_RequesterId",
                table: "T_Bill_Leave",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Book_Id",
                table: "T_Book",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_Comment_ArticleId",
                table: "T_Comment",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Node_ParentId",
                table: "T_Node",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_T_PersonCard_PersonId",
                table: "T_PersonCard",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_T_Student_Teacher_Relationship_TeachersId",
                table: "T_Student_Teacher_Relationship",
                column: "TeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Bill_Leave");

            migrationBuilder.DropTable(
                name: "T_Book");

            migrationBuilder.DropTable(
                name: "T_Comment");

            migrationBuilder.DropTable(
                name: "T_Node");

            migrationBuilder.DropTable(
                name: "T_PersonCard");

            migrationBuilder.DropTable(
                name: "T_Student_Teacher_Relationship");

            migrationBuilder.DropTable(
                name: "T_USER");

            migrationBuilder.DropTable(
                name: "T_Article");

            migrationBuilder.DropTable(
                name: "T_Person");

            migrationBuilder.DropTable(
                name: "T_Student");

            migrationBuilder.DropTable(
                name: "T_Teacher");
        }
    }
}
