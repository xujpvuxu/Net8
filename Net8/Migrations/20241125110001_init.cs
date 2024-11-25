using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net8.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false, comment: "信箱"),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "密碼"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, comment: "姓名"),
                    Age = table.Column<int>(type: "int", nullable: true, comment: "年齡"),
                    Gender = table.Column<bool>(type: "bit", nullable: false, comment: "性別(0:女、1:男)"),
                    Region = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "省份"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "城市")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
