using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTickets.Migrations
{
    public partial class NewActorMovieInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_AcrorId",
                table: "ActorMovie");

            migrationBuilder.RenameColumn(
                name: "AcrorId",
                table: "ActorMovie",
                newName: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                table: "ActorMovie",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovie_Actors_ActorId",
                table: "ActorMovie");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "ActorMovie",
                newName: "AcrorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovie_Actors_AcrorId",
                table: "ActorMovie",
                column: "AcrorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
