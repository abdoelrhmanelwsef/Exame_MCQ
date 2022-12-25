using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ptoject.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTabelUserAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationDbUserId",
                table: "StudentAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDbUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentAnswersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswer_AspNetUsers_ApplicationDbUserId",
                        column: x => x.ApplicationDbUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnswer_StudentAnswers_StudentAnswersId",
                        column: x => x.StudentAnswersId,
                        principalTable: "StudentAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_ApplicationDbUserId",
                table: "UserAnswer",
                column: "ApplicationDbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_StudentAnswersId",
                table: "UserAnswer",
                column: "StudentAnswersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnswer");

            migrationBuilder.DropColumn(
                name: "ApplicationDbUserId",
                table: "StudentAnswers");
        }
    }
}
