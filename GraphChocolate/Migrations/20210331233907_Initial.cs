using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphChocolate.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToppingId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "First Topping" });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Second Topping" });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name", "ToppingId" },
                values: new object[] { 1, "First Pizza", 1 });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name", "ToppingId" },
                values: new object[] { 2, "Second Pizza", 1 });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name", "ToppingId" },
                values: new object[] { 3, "Third Pizza", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_ToppingId",
                table: "Pizzas",
                column: "ToppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Toppings");
        }
    }
}
