using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PromoCodeFactory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2024, 11, 6, 19, 57, 45, 620, DateTimeKind.Local).AddTicks(3120)),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "preferences",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2024, 11, 6, 19, 57, 45, 638, DateTimeKind.Local).AddTicks(6820)),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_preferences", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2024, 11, 6, 19, 57, 45, 639, DateTimeKind.Local).AddTicks(7110)),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer_preferences",
                columns: table => new
                {
                    customer_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    preference_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer_preferences", x => new { x.customer_id, x.preference_id });
                    table.ForeignKey(
                        name: "fk_customer_preferences_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_customer_preferences_preferences_preference_id",
                        column: x => x.preference_id,
                        principalTable: "preferences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    role_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    applied_promo_codes_count = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2024, 11, 6, 19, 57, 45, 637, DateTimeKind.Local).AddTicks(870)),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employees", x => x.id);
                    table.ForeignKey(
                        name: "fk_employees_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "promo_codes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    service_info = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    begin_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    end_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    partner_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    partner_manager_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    preference_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2024, 11, 6, 19, 57, 45, 639, DateTimeKind.Local).AddTicks(2110)),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promo_codes", x => x.id);
                    table.ForeignKey(
                        name: "fk_promo_codes_employees_partner_manager_id",
                        column: x => x.partner_manager_id,
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_promo_codes_preferences_preference_id",
                        column: x => x.preference_id,
                        principalTable: "preferences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "email", "first_name", "last_name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"), "ivan_sergeev@mail.ru", "Иван", "Петров", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f766e2bf-340a-46ea-bff3-f1700b435895"), "marivanna@somemail.ru", "Мария", "Ивановна", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "preferences",
                columns: new[] { "id", "name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("76324c47-68d2-472d-abb8-33cfa8cc0c84"), "Дети", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c4bda62e-fc74-4256-a956-4760b3858cbd"), "Семья", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ef7f299f-92d7-459f-896e-078ed53ef99c"), "Театр", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "description", "name", "updated_at" },
                values: new object[,]
                {
                    { new Guid("53729686-a368-4eeb-8bfa-cc69b6050d02"), "Админ", "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0ae7aac-5493-45cd-ad16-87426a5e7665"), "Манагер", "Manager", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "customer_preferences",
                columns: new[] { "customer_id", "preference_id" },
                values: new object[,]
                {
                    { new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"), new Guid("76324c47-68d2-472d-abb8-33cfa8cc0c84") },
                    { new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"), new Guid("c4bda62e-fc74-4256-a956-4760b3858cbd") },
                    { new Guid("f766e2bf-340a-46ea-bff3-f1700b435895"), new Guid("ef7f299f-92d7-459f-896e-078ed53ef99c") }
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "id", "applied_promo_codes_count", "email", "first_name", "last_name", "role_id", "updated_at" },
                values: new object[,]
                {
                    { new Guid("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f"), 5, "sansanich@somemail.ru", "Сан", "Саныч", new Guid("53729686-a368-4eeb-8bfa-cc69b6050d02"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f766e2bf-340a-46ea-bff3-f1700b435895"), 10, "marivanna@somemail.ru", "Мария", "Ивановна", new Guid("b0ae7aac-5493-45cd-ad16-87426a5e7665"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "ix_customer_preferences_preference_id",
                table: "customer_preferences",
                column: "preference_id");

            migrationBuilder.CreateIndex(
                name: "ix_employees_role_id",
                table: "employees",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_promo_codes_partner_manager_id",
                table: "promo_codes",
                column: "partner_manager_id");

            migrationBuilder.CreateIndex(
                name: "ix_promo_codes_preference_id",
                table: "promo_codes",
                column: "preference_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer_preferences");

            migrationBuilder.DropTable(
                name: "promo_codes");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "preferences");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
