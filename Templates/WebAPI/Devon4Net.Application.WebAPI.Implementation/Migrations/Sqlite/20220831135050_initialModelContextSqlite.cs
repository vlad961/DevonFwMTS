using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Devon4Net.Application.WebAPI.Implementation.Migrations.Sqlite
{
    public partial class initialModelContextSqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    ShowOrder = table.Column<int>(type: "INTEGER", nullable: true),
                    ModificationCounter = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    MimeType = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Extension = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ContentType = table.Column<int>(type: "INTEGER", nullable: true),
                    ModificationCounter = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<double>(type: "double(16, 10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SeatsNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(4000)", nullable: true),
                    Price = table.Column<double>(type: "double(16, 10)", nullable: true),
                    IdImage = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dish_image",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    Password = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    IdRole = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_0_0",
                        column: x => x.IdRole,
                        principalTable: "UserRole",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DishCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdDish = table.Column<long>(type: "INTEGER", nullable: false),
                    IdCategory = table.Column<long>(type: "INTEGER", nullable: false),
                    ModificationCounter = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishCategory_0_0",
                        column: x => x.IdCategory,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DishCategory_1_0",
                        column: x => x.IdDish,
                        principalTable: "Dish",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DishIngredient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdDish = table.Column<long>(type: "INTEGER", nullable: false),
                    IdIngredient = table.Column<long>(type: "INTEGER", nullable: false),
                    ModificationCounter = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishIngredient_0_0",
                        column: x => x.IdIngredient,
                        principalTable: "Ingredient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DishIngredient_1_0",
                        column: x => x.IdDish,
                        principalTable: "Dish",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<long>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    ReservationToken = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    Comments = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Canceled = table.Column<bool>(type: "INTEGER", nullable: true, defaultValueSql: "((0))"),
                    IdBookingType = table.Column<int>(type: "INTEGER", nullable: true),
                    TableId = table.Column<long>(type: "INTEGER", nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Assistants = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_0_0",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservation_table",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserFavourite",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUser = table.Column<long>(type: "INTEGER", nullable: false),
                    IdDish = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavourite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavourite_0_0",
                        column: x => x.IdDish,
                        principalTable: "Dish",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFavourite_1_0",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvitedGuest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdBooking = table.Column<long>(type: "INTEGER", nullable: false),
                    GuestToken = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    Accepted = table.Column<bool>(type: "INTEGER", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitedGuest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvitationGuest_0_0",
                        column: x => x.IdBooking,
                        principalTable: "Booking",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdReservation = table.Column<long>(type: "INTEGER", nullable: true),
                    IdInvitationGuest = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_0_0",
                        column: x => x.IdReservation,
                        principalTable: "Booking",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_0_1",
                        column: x => x.IdInvitationGuest,
                        principalTable: "InvitedGuest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderLine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdDish = table.Column<long>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: true),
                    Comment = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    IdOrder = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLine_0_0",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderLine_1_0",
                        column: x => x.IdDish,
                        principalTable: "Dish",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDishExtraIngredient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdOrderLine = table.Column<long>(type: "INTEGER", nullable: false),
                    IdIngredient = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDishExtraIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDIshExtraIngredient_0_0",
                        column: x => x.IdOrderLine,
                        principalTable: "OrderLine",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDIshExtraIngredient_1_0",
                        column: x => x.IdIngredient,
                        principalTable: "Ingredient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Id",
                table: "Booking",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TableId",
                table: "Booking",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_IdImage",
                table: "Dish",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_DishCategory_IdCategory",
                table: "DishCategory",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_DishCategory_IdDish",
                table: "DishCategory",
                column: "IdDish");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredient_IdDish",
                table: "DishIngredient",
                column: "IdDish");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredient_IdIngredient",
                table: "DishIngredient",
                column: "IdIngredient");

            migrationBuilder.CreateIndex(
                name: "IX_InvitedGuest_Id",
                table: "InvitedGuest",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvitedGuest_IdBooking",
                table: "InvitedGuest",
                column: "IdBooking");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdInvitationGuest",
                table: "Order",
                column: "IdInvitationGuest");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdReservation",
                table: "Order",
                column: "IdReservation");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDishExtraIngredient_IdIngredient",
                table: "OrderDishExtraIngredient",
                column: "IdIngredient");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDishExtraIngredient_IdOrderLine",
                table: "OrderDishExtraIngredient",
                column: "IdOrderLine");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_IdDish",
                table: "OrderLine",
                column: "IdDish");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_IdOrder",
                table: "OrderLine",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdRole",
                table: "User",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavourite_IdDish",
                table: "UserFavourite",
                column: "IdDish");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavourite_IdUser",
                table: "UserFavourite",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishCategory");

            migrationBuilder.DropTable(
                name: "DishIngredient");

            migrationBuilder.DropTable(
                name: "OrderDishExtraIngredient");

            migrationBuilder.DropTable(
                name: "UserFavourite");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "OrderLine");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "InvitedGuest");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
