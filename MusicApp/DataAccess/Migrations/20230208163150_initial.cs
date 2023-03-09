using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SongsData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSongWasPlayed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MilisecondsPlayed = table.Column<double>(type: "float", nullable: false),
                    CountryStreamFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlbumName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonSongStarted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonSongEnded = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongsData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongsData");
        }
    }
}
