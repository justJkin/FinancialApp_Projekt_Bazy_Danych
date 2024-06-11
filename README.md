FinancialApp
FinancialApp is a comprehensive financial management application that allows users to track their incomes, expenses, savings, and generate detailed financial reports. This application is built with .NET and WPF and uses Entity Framework Core for database operations.

Features
User Authentication: Secure login and registration functionality.
Dashboard: Overview of total balance, expenses, incomes, and savings.
Transaction Management: Add, view, and manage incomes and expenses.
Financial Reports: Generate detailed financial reports using stored procedures and functions.
Average Monthly Spendings: Calculate and display average monthly spendings.
Admin Panel: Special functionalities for admin users to manage all user accounts.
Reminders: Set and manage financial reminders.
Getting Started
Prerequisites
.NET 6.0 SDK
SQL Server
Visual Studio (Recommended)
Installation
Clone the repository:

bash
Skopiuj kod
git clone https://github.com/yourusername/financialApp.git
cd financialApp
Update the database connection string in App.xaml.cs:

csharp
Skopiuj kod
options.UseSqlServer("Server=your_server_name;Database=FinancialDatabaseApp;Trusted_Connection=True;TrustServerCertificate=True;");
Apply migrations and create the database:

bash
Skopiuj kod
dotnet ef database update
Build and run the application:

bash
Skopiuj kod
dotnet build
dotnet run
Usage
User Dashboard
Check Graphs: View graphical representations of your financial data.
Add Incomes/Spendings: Add new income or spending transactions.
Generate Financial Report: Generate a detailed financial report.
Average Monthly Spendings: Calculate and display average monthly spendings.
Admin Dashboard
Manage Users: Admins can add, update, and delete user accounts.
View Reports: Admins can view detailed reports of all users.
Database Schema
The application uses the following tables:

Users: Stores user information.
Transactions: Stores transaction details for incomes and spendings.
SavingGoals: Stores user saving goals.
Reminders: Stores reminder information.
UserGroups: Stores user group information.
UserGroupMemberships: Stores user-group membership relationships.
Stored Procedures and Functions
The application uses various stored procedures and functions for generating reports and calculating balances. These are applied during the initial database migration.

Contributing
Contributions are welcome! Please fork the repository and create a pull request with your changes.

License
This project is licensed under the MIT License - see the LICENSE file for details.

Acknowledgments
Thanks to the open-source community for the tools and libraries used in this project.
Special thanks to all contributors.
