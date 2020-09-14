using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class NotificationTableSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationUser_AspNetUsers_EmployeeUserId",
                table: "NotificationUser");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationUser_Notification_NotificationId",
                table: "NotificationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationUser",
                table: "NotificationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NotificationUser");

            migrationBuilder.RenameTable(
                name: "NotificationUser",
                newName: "UserNotifications");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationUser_EmployeeUserId",
                table: "UserNotifications",
                newName: "IX_UserNotifications_EmployeeUserId");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeUserId",
                table: "UserNotifications",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNotifications",
                table: "UserNotifications",
                columns: new[] { "NotificationId", "EmployeeUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_AspNetUsers_EmployeeUserId",
                table: "UserNotifications",
                column: "EmployeeUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotifications_Notifications_NotificationId",
                table: "UserNotifications",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_AspNetUsers_EmployeeUserId",
                table: "UserNotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotifications_Notifications_NotificationId",
                table: "UserNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNotifications",
                table: "UserNotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.RenameTable(
                name: "UserNotifications",
                newName: "NotificationUser");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");

            migrationBuilder.RenameIndex(
                name: "IX_UserNotifications_EmployeeUserId",
                table: "NotificationUser",
                newName: "IX_NotificationUser_EmployeeUserId");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeUserId",
                table: "NotificationUser",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "NotificationUser",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationUser",
                table: "NotificationUser",
                columns: new[] { "NotificationId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationUser_AspNetUsers_EmployeeUserId",
                table: "NotificationUser",
                column: "EmployeeUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationUser_Notification_NotificationId",
                table: "NotificationUser",
                column: "NotificationId",
                principalTable: "Notification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
