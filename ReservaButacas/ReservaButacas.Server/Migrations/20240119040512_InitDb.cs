using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservaButacas.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Age = table.Column<short>(type: "smallint", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    AllowedAge = table.Column<short>(type: "smallint", nullable: false),
                    LengthMinutes = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Billboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Billboards_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Billboards_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<short>(type: "smallint", nullable: false),
                    RowNumber = table.Column<short>(type: "smallint", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    BillboardId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Billboards_BillboardId",
                        column: x => x.BillboardId,
                        principalTable: "Billboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Billboards_MovieId",
                table: "Billboards",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Billboards_RoomId",
                table: "Billboards",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BillboardId",
                table: "Bookings",
                column: "BillboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SeatId",
                table: "Bookings",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DocumentNumber",
                table: "Customers",
                column: "DocumentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_RoomId",
                table: "Seats",
                column: "RoomId");


            //ROOMS
            migrationBuilder.InsertData(
               table: "Rooms",
               columns: new[] { "Id", "Name", "Number", "Status" },
               values: new object[] { 1, "Sala VIPTERROR", 4, true });

            migrationBuilder.InsertData(
               table: "Rooms",
               columns: new[] { "Id", "Name", "Number", "Status" },
               values: new object[] { 2, "Sala VIPTERROR2", 4, true });

            migrationBuilder.InsertData(
               table: "Rooms",
               columns: new[] { "Id", "Name", "Number", "Status" },
               values: new object[] { 3, "Sala VIP", 4, true });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "Number", "Status" },
                values: new object[] { 4, "Sala de Proyecciones Especiales", 5, true });


            //SEATS
            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "RowNumber", "RoomId", "Status" },
                values: new object[] { 1, 4, 3, 3, true });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "RowNumber", "RoomId", "Status" },
                values: new object[] { 2, 6, 3, 4, true });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "RowNumber", "RoomId", "Status" },
                values: new object[] { 3, 5, 2, 3, true });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "RowNumber", "RoomId", "Status" },
                values: new object[] { 4, 6, 3, 1, true });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "RowNumber", "RoomId", "Status" },
                values: new object[] { 5, 6, 3, 2, true });


            //CUSTOMERS
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DocumentNumber", "Name", "Lastname", "Age", "PhoneNumber", "Email", "Status" },
                values: new object[] { 1, "0987541623", "Laura", "González", 28, "987654321", "laura@example.com", true });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DocumentNumber", "Name", "Lastname", "Age", "PhoneNumber", "Email", "Status" },
                values: new object[] { 2, "0807501623", "Carlos", "Martínez", 35, "654321987", "carlos@example.com", true });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DocumentNumber", "Name", "Lastname", "Age", "PhoneNumber", "Email", "Status" },
                values: new object[] { 3, "0865712346", "Isabel", "Ramírez", 22, "321987654", "isabel@example.com", true });

            //MOVIES
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "Genre", "AllowedAge", "LengthMinutes", "Status" },
                values: new object[] { 1, "Titanic", 1, 12, 195, true });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "Genre", "AllowedAge", "LengthMinutes", "Status" },
                values: new object[] { 2, "The Dark Knight", 2, 14, 152, true });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "Genre", "AllowedAge", "LengthMinutes", "Status"},
                values: new object[] { 3, "El Horror Nocturno", 6 , 16 , 160 , true });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "Genre", "AllowedAge", "LengthMinutes", "Status" },
                values: new object[] { 4, "Inception", 3, 12, 148, true });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name", "Genre", "AllowedAge", "LengthMinutes", "Status" },
                values: new object[] { 5, "Pesadilla en la Oscuridad", 6, 18, 130, true });

            //BILLBOARDS
            migrationBuilder.InsertData(
                table: "Billboards",
                columns: new[] { "Id", "Date", "StartTime", "EndTime", "MovieId", "RoomId", "Status" },
                values: new object[] { 1, new DateTime(2023, 12, 1), new TimeSpan(15, 0, 0), new TimeSpan(17, 0, 0), 3, 3, true });

            migrationBuilder.InsertData(
                table: "Billboards",
                columns: new[] { "Id", "Date", "StartTime", "EndTime", "MovieId", "RoomId", "Status" },
                values: new object[] { 2, new DateTime(2024, 1, 19), new TimeSpan(18, 0, 0), new TimeSpan(20, 0, 0), 1, 4, true });

            migrationBuilder.InsertData(
                table: "Billboards",
                columns: new[] { "Id", "Date", "StartTime", "EndTime", "MovieId", "RoomId", "Status" },
                values: new object[] { 3, new DateTime(2024, 1, 19), new TimeSpan(18, 0, 0), new TimeSpan(20, 0, 0), 3, 1, true });

            migrationBuilder.InsertData(
                table: "Billboards",
                columns: new[] { "Id", "Date", "StartTime", "EndTime", "MovieId", "RoomId", "Status" },
                values: new object[] { 4, new DateTime(2024, 1, 19), new TimeSpan(18, 0, 0), new TimeSpan(20, 0, 0), 5, 2, true });

            //BOOKINGS
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Date", "CustomerId", "SeatId", "BillboardId", "Status" },
                values: new object[] { 1, DateTime.Now, 2, 2, 2, true });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Date", "CustomerId", "SeatId", "BillboardId", "Status" },
                values: new object[] { 2, DateTime.Now, 3, 1, 1, true });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Date", "CustomerId", "SeatId", "BillboardId", "Status" },
                values: new object[] { 3, DateTime.Now, 3, 3, 1, true });

            migrationBuilder.InsertData(
               table: "Bookings",
               columns: new[] { "Id", "Date", "CustomerId", "SeatId", "BillboardId", "Status" },
               values: new object[] { 4, DateTime.Now, 3, 1, 3, true });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Date", "CustomerId", "SeatId", "BillboardId", "Status" },
                values: new object[] { 5, DateTime.Now, 3, 3, 4, true });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Billboards");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
