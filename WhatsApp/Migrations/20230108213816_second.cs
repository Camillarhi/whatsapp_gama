using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsApp.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MessageReplyId",
                table: "Conversations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ContactId",
                table: "Messages",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Contacts_ContactId",
                table: "Messages",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Contacts_ContactId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ContactId",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "MessageReplyId",
                table: "Conversations",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
