using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenThumb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Plantid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Plantid);
                });

            migrationBuilder.CreateTable(
                name: "Advice",
                columns: table => new
                {
                    AdviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advice", x => x.AdviceId);
                    table.ForeignKey(
                        name: "FK_Advice_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Plantid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Plantid", "Name" },
                values: new object[,]
                {
                    { 1, "Rose" },
                    { 2, "Pine tree" },
                    { 3, "Rosemary" },
                    { 4, "Tulip" },
                    { 5, "Lavender" },
                    { 6, "Orchid" },
                    { 7, "Sunflower" },
                    { 8, "Maple" },
                    { 9, "Jasmine" },
                    { 10, "Lily" },
                    { 11, "Cactus" },
                    { 12, "Peppermint" }
                });

            migrationBuilder.InsertData(
                table: "Advice",
                columns: new[] { "AdviceId", "Description", "PlantId" },
                values: new object[,]
                {
                    { 1, "Place in a sunny location and water regularly to promote blooming.", 1 },
                    { 2, "Thrives in well-drained soil and requires minimal watering; avoid overwatering.", 2 },
                    { 3, "Water sparingly and place in a sunny location; tolerates drought and prefers warmer climates.", 3 },
                    { 4, "Plant in well-drained soil and avoid overwatering to prevent root rot.", 4 },
                    { 5, "Place in a sunny location, water sparingly, and trim back flowers to encourage growth.", 5 },
                    { 6, "Water moderately, avoid overwatering; place in indirect light and provide support for upright growth.", 6 },
                    { 7, "Plant in a sunny location, provide support to prevent toppling, and water regularly.", 7 },
                    { 8, "Thrives in moist, well-drained soil; avoid waterlogging and provide protection in extreme weather.", 8 },
                    { 9, "Plant in well-drained soil, provide support for climbing varieties, and water consistently.", 9 },
                    { 10, "Plant in well-drained soil, water regularly, and provide support for taller varieties.", 10 },
                    { 11, "Use well-draining soil, water sparingly, and place in a sunny location; avoid overwatering.", 11 },
                    { 12, "Plant in partial shade, keep soil consistently moist, and prune regularly to encourage bushy growth.", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advice_PlantId",
                table: "Advice",
                column: "PlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advice");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
