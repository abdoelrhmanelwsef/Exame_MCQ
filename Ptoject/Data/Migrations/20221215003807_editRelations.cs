using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ptoject.Data.Migrations
{
    /// <inheritdoc />
    public partial class editRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exames");

            migrationBuilder.DropTable(
                name: "UserAnswer");

            migrationBuilder.DropTable(
                name: "StudentAnswers");

            migrationBuilder.CreateTable(
                name: "AnswerUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeeQuestion = table.Column<double>(type: "float", nullable: false),
                    DegreeeStudent = table.Column<double>(type: "float", nullable: false),
                    ApplicationDbUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerUser_Answers_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerUser_AspNetUsers_ApplicationDbUserId",
                        column: x => x.ApplicationDbUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerUser_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionsId = table.Column<int>(type: "int", nullable: false),
                    ApplicationDbUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionUser_AspNetUsers_ApplicationDbUserId",
                        column: x => x.ApplicationDbUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionUser_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerUser_AnswerID",
                table: "AnswerUser",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerUser_ApplicationDbUserId",
                table: "AnswerUser",
                column: "ApplicationDbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerUser_QuestionID",
                table: "AnswerUser",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionUser_ApplicationDbUserId",
                table: "QuestionUser",
                column: "ApplicationDbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionUser_QuestionsId",
                table: "QuestionUser",
                column: "QuestionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerUser");

            migrationBuilder.DropTable(
                name: "QuestionUser");

            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDbUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exames_AspNetUsers_ApplicationDbUserId",
                        column: x => x.ApplicationDbUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exames_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    AnswerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationDbUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeeQuestion = table.Column<double>(type: "float", nullable: false),
                    DegreeeStudent = table.Column<double>(type: "float", nullable: false),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAnswers_Answers_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAnswers_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Exames_ApplicationDbUserId",
                table: "Exames",
                column: "ApplicationDbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_QuestionsId",
                table: "Exames",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_AnswerID",
                table: "StudentAnswers",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_QuestionID",
                table: "StudentAnswers",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_ApplicationDbUserId",
                table: "UserAnswer",
                column: "ApplicationDbUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswer_StudentAnswersId",
                table: "UserAnswer",
                column: "StudentAnswersId");
        }
    }
}
