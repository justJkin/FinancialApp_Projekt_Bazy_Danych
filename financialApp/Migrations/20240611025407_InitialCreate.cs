using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace financialApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "PeriodicReports",
                columns: table => new
                {
                    ReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ReportType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportData = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodicReports", x => x.ReportID);
                    table.ForeignKey(
                        name: "FK_PeriodicReports_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    ReminderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextReminderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.ReminderID);
                    table.ForeignKey(
                        name: "FK_Reminders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingGoals",
                columns: table => new
                {
                    GoalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingGoals", x => x.GoalID);
                    table.ForeignKey(
                        name: "FK_SavingGoals_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupMemberships",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupMemberships", x => new { x.UserID, x.GroupID });
                    table.ForeignKey(
                        name: "FK_UserGroupMemberships_UserGroups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "UserGroups",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGroupMemberships_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodicReports_UserID",
                table: "PeriodicReports",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_UserID",
                table: "Reminders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SavingGoals_UserID",
                table: "SavingGoals",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserID",
                table: "Transactions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupMemberships_GroupID",
                table: "UserGroupMemberships",
                column: "GroupID");

            // Dodawanie procedury CalculateUserBalance
            migrationBuilder.Sql(@"
                CREATE PROCEDURE CalculateUserBalance
                    @UserID INT,
                    @StartDate DATE,
                    @EndDate DATE
                AS
                BEGIN
                    DECLARE @TotalIncomes DECIMAL(18, 2);
                    DECLARE @TotalSpendings DECIMAL(18, 2);
                    DECLARE @Balance DECIMAL(18, 2);

                    SELECT @TotalIncomes = ISNULL(SUM(Amount), 0)
                    FROM Transactions
                    WHERE UserID = @UserID
                      AND Type = 'Incomes'
                      AND Date BETWEEN @StartDate AND @EndDate;

                    SELECT @TotalSpendings = ISNULL(SUM(Amount), 0)
                    FROM Transactions
                    WHERE UserID = @UserID
                      AND Type = 'Spendings'
                      AND Date BETWEEN @StartDate AND @EndDate;

                    SET @Balance = @TotalIncomes - @TotalSpendings;

                    IF @Balance >= 0
                    BEGIN
                        PRINT 'User has a positive balance of ' + CAST(@Balance AS NVARCHAR(50));
                    END
                    ELSE
                    BEGIN
                        PRINT 'User has a negative balance of ' + CAST(@Balance AS NVARCHAR(50));
                    END
                END;
            ");

            // Dodawanie procedury GenerateUserFinancialReport
            migrationBuilder.Sql(@"
                CREATE PROCEDURE GenerateUserFinancialReport
                    @UserID INT,
                    @StartDate DATE,
                    @EndDate DATE
                AS
                BEGIN
                    DECLARE @TotalIncomes DECIMAL(18, 2);
                    DECLARE @TotalSpendings DECIMAL(18, 2);
                    DECLARE @Balance DECIMAL(18, 2);

                    SELECT @TotalIncomes = ISNULL(SUM(Amount), 0)
                    FROM Transactions
                    WHERE UserID = @UserID AND Type = 'Incomes' AND Date BETWEEN @StartDate AND @EndDate;

                    SELECT @TotalSpendings = ISNULL(SUM(Amount), 0)
                    FROM Transactions
                    WHERE UserID = @UserID AND Type = 'Spendings' AND Date BETWEEN @StartDate AND @EndDate;

                    SET @Balance = @TotalIncomes - @TotalSpendings;

                    SELECT 
                        @UserID AS UserID,
                        @TotalIncomes AS TotalIncomes,
                        @TotalSpendings AS TotalSpendings,
                        @Balance AS Balance;

                    SELECT
                        TransactionID,
                        Amount,
                        Date,
                        Description,
                        Type
                    FROM Transactions
                    WHERE UserID = @UserID AND Date BETWEEN @StartDate AND @EndDate
                    ORDER BY Date;
                END;
            ");

            // Dodawanie funkcji fnAverageMonthlySpendings
            migrationBuilder.Sql(@"
                CREATE FUNCTION dbo.fnAverageMonthlySpendings
                (
                    @UserID INT
                )
                RETURNS DECIMAL(18, 2)
                AS
                BEGIN
                    DECLARE @AverageSpendings DECIMAL(18, 2);

                    SELECT @AverageSpendings = AVG(MonthlySpendings)
                    FROM
                    (
                        SELECT SUM(Amount) AS MonthlySpendings
                        FROM Transactions
                        WHERE UserID = @UserID AND Type = 'Spendings'
                        GROUP BY YEAR(Date), MONTH(Date)
                    ) AS MonthlyData;

                    RETURN @AverageSpendings;
                END;
            ");

            // Dodawanie funkcji fnFinancialReport
            migrationBuilder.Sql(@"
                CREATE FUNCTION dbo.fnFinancialReport
                (
                    @UserID INT,
                    @StartDate DATE,
                    @EndDate DATE
                )
                RETURNS @FinancialReport TABLE
                (
                    UserID INT,
                    TotalIncomes DECIMAL(18, 2),
                    TotalSpendings DECIMAL(18, 2),
                    Balance DECIMAL(18, 2)
                )
                AS
                BEGIN
                    INSERT INTO @FinancialReport (UserID, TotalIncomes, TotalSpendings, Balance)
                    SELECT
                        @UserID AS UserID,
                        SUM(CASE WHEN Type = 'Incomes' THEN Amount ELSE 0 END) AS TotalIncomes,
                        SUM(CASE WHEN Type = 'Spendings' THEN Amount ELSE 0 END) AS TotalSpendings,
                        SUM(CASE WHEN Type = 'Incomes' THEN Amount ELSE 0 END) - SUM(CASE WHEN Type = 'Spendings' THEN Amount ELSE 0 END) AS Balance
                    FROM Transactions
                    WHERE UserID = @UserID AND Date BETWEEN @StartDate AND @EndDate;

                    RETURN;
                END;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "PeriodicReports");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "SavingGoals");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserGroupMemberships");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "Users");

            // Usuwanie procedury CalculateUserBalance
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS CalculateUserBalance");

            // Usuwanie procedury GenerateUserFinancialReport
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GenerateUserFinancialReport");

            // Usuwanie funkcji fnAverageMonthlySpendings
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS dbo.fnAverageMonthlySpendings");

            // Usuwanie funkcji fnFinancialReport
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS dbo.fnFinancialReport");
        }
    }
}
