using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExamProject.Migrations
{
    /// <inheritdoc />
    public partial class AddmoreSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HtmlQuestions",
                columns: table => new
                {
                    HtmlModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionText1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionText2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionText3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionText4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectOption = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlQuestions", x => x.HtmlModelId);
                });

            migrationBuilder.CreateTable(
                name: "SQLQuestions",
                columns: table => new
                {
                    SQLModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionText1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionText2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionText3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionText4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectOption = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SQLQuestions", x => x.SQLModelId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HtmlQuestions");

            migrationBuilder.DropTable(
                name: "SQLQuestions");
        }
    }
}
