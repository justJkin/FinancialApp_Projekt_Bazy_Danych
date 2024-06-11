-- Insert Users
INSERT INTO Users (Username, Password, Email, Role) VALUES
('Admin', 'admin123', 'admin@example.com', 'Admin'),
('Anna', 'anna123', 'anna@example.com', 'User'),
('Jan', 'jan123', 'jan@example.com', 'User'),
('Ewa', 'ewa123', 'ewa@example.com', 'User'),
('Piotr', 'piotr123', 'piotr@example.com', 'User'),
('Kasia', 'kasia123', 'kasia@example.com', 'User'),
('Tomek', 'tomek123', 'tomek@example.com', 'User'),
('Magda', 'magda123', 'magda@example.com', 'User'),
('Pawe�', 'pawel123', 'pawel@example.com', 'User'),
('Agnieszka', 'agnieszka123', 'agnieszka@example.com', 'User');

-- Insert UserGroups
INSERT INTO UserGroups (GroupName) VALUES
('Dom'),
('Znajomi'),
('Praca'),
('Mieszkanie');

-- Insert UserGroupMemberships
INSERT INTO UserGroupMemberships (UserID, GroupID) VALUES
(1, 1),
(2, 1),
(3, 2),
(4, 2),
(5, 3),
(6, 3),
(7, 4),
(8, 4),
(9, 1);

-- Insert Transactions
INSERT INTO Transactions (UserID, Amount, Date, Description, Type) VALUES
(1, 150.75, GETDATE(), 'Zakup sprz�tu', 'Spendings'),
(2, 200.00, GETDATE(), 'Op�ata za us�ugi', 'Spendings');
-- Insert Transactions for user 2 from 2023-01-01 to 2024-06-11
INSERT INTO Transactions (UserID, Amount, Date, Description, Type) VALUES
(2, 1200.50, '2023-01-10', 'Wynagrodzenie', 'Incomes'),
(2, 75.25, '2023-01-15', 'Zakup książek', 'Spendings'),
(2, 100.00, '2023-01-20', 'Opłata za internet', 'Spendings'),
(2, 300.00, '2023-01-25', 'Zlecenie', 'Incomes'),
(2, 50.00, '2023-01-30', 'Bilet do kina', 'Spendings'),
(2, 150.00, '2023-02-05', 'Zakup odzieży', 'Spendings'),
(2, 1000.00, '2023-02-10', 'Wynagrodzenie', 'Incomes'),
(2, 60.00, '2023-02-15', 'Obiad w restauracji', 'Spendings'),
(2, 80.00, '2023-02-20', 'Zakup artykułów biurowych', 'Spendings'),
(2, 150.00, '2023-02-25', 'Zlecenie', 'Incomes'),
(2, 40.00, '2023-02-28', 'Bilet do teatru', 'Spendings'),
(2, 200.00, '2023-03-05', 'Opłata za telefon', 'Spendings'),
(2, 1100.00, '2023-03-10', 'Wynagrodzenie', 'Incomes'),
(2, 50.00, '2023-03-15', 'Zakup kosmetyków', 'Spendings'),
(2, 90.00, '2023-03-20', 'Obiad w restauracji', 'Spendings'),
(2, 250.00, '2023-03-25', 'Zlecenie', 'Incomes'),
(2, 60.00, '2023-03-30', 'Bilet na koncert', 'Spendings'),
(2, 300.00, '2023-04-05', 'Zakup elektroniki', 'Spendings'),
(2, 1200.00, '2023-04-10', 'Wynagrodzenie', 'Incomes'),
(2, 70.00, '2023-04-15', 'Zakup książek', 'Spendings'),
(2, 100.00, '2023-04-20', 'Opłata za internet', 'Spendings'),
(2, 350.00, '2023-04-25', 'Zlecenie', 'Incomes'),
(2, 55.00, '2023-04-30', 'Bilet do muzeum', 'Spendings'),
(2, 250.00, '2023-05-05', 'Zakup odzieży', 'Spendings'),
(2, 1000.00, '2023-05-10', 'Wynagrodzenie', 'Incomes'),
(2, 65.00, '2023-05-15', 'Obiad w restauracji', 'Spendings'),
(2, 85.00, '2023-05-20', 'Zakup artykułów biurowych', 'Spendings'),
(2, 200.00, '2023-05-25', 'Zlecenie', 'Incomes'),
(2, 45.00, '2023-05-30', 'Bilet do kina', 'Spendings'),
(2, 180.00, '2023-06-05', 'Opłata za telefon', 'Spendings'),
(2, 1100.00, '2023-06-10', 'Wynagrodzenie', 'Incomes'),
(2, 60.00, '2023-06-15', 'Zakup kosmetyków', 'Spendings'),
(2, 90.00, '2023-06-20', 'Obiad w restauracji', 'Spendings'),
(2, 230.00, '2023-06-25', 'Zlecenie', 'Incomes'),
(2, 50.00, '2023-06-30', 'Bilet na koncert', 'Spendings'),
(2, 220.00, '2023-07-05', 'Zakup elektroniki', 'Spendings'),
(2, 1200.00, '2023-07-10', 'Wynagrodzenie', 'Incomes'),
(2, 75.00, '2023-07-15', 'Zakup książek', 'Spendings'),
(2, 100.00, '2023-07-20', 'Opłata za internet', 'Spendings'),
(2, 320.00, '2023-07-25', 'Zlecenie', 'Incomes'),
(2, 55.00, '2023-07-30', 'Bilet do muzeum', 'Spendings'),
(2, 200.00, '2023-08-05', 'Zakup odzieży', 'Spendings'),
(2, 1000.00, '2023-08-10', 'Wynagrodzenie', 'Incomes'),
(2, 70.00, '2023-08-15', 'Obiad w restauracji', 'Spendings'),
(2, 80.00, '2023-08-20', 'Zakup artykułów biurowych', 'Spendings'),
(2, 250.00, '2023-08-25', 'Zlecenie', 'Incomes'),
(2, 45.00, '2023-08-30', 'Bilet do kina', 'Spendings'),
(2, 190.00, '2023-09-05', 'Opłata za telefon', 'Spendings'),
(2, 1100.00, '2023-09-10', 'Wynagrodzenie', 'Incomes'),
(2, 60.00, '2023-09-15', 'Zakup kosmetyków', 'Spendings'),
(2, 90.00, '2023-09-20', 'Obiad w restauracji', 'Spendings'),
(2, 240.00, '2023-09-25', 'Zlecenie', 'Incomes'),
(2, 50.00, '2023-09-30', 'Bilet na koncert', 'Spendings'),
(2, 210.00, '2023-10-05', 'Zakup elektroniki', 'Spendings'),
(2, 1200.00, '2023-10-10', 'Wynagrodzenie', 'Incomes'),
(2, 75.00, '2023-10-15', 'Zakup książek', 'Spendings'),
(2, 100.00, '2023-10-20', 'Opłata za internet', 'Spendings'),
(2, 330.00, '2023-10-25', 'Zlecenie', 'Incomes'),
(2, 55.00, '2023-10-30', 'Bilet do muzeum', 'Spendings'),
(2, 230.00, '2023-11-05', 'Zakup odzieży', 'Spendings'),
(2, 1000.00, '2023-11-10', 'Wynagrodzenie', 'Incomes'),
(2, 65.00, '2023-11-15', 'Obiad w restauracji', 'Spendings'),
(2, 85.00, '2023-11-20', 'Zakup artykułów biurowych', 'Spendings'),
(2, 200.00, '2023-11-25', 'Zlecenie', 'Incomes'),
(2, 45.00, '2023-11-30', 'Bilet do kina', 'Spendings'),
(2, 180.00, '2023-12-05', 'Opłata za telefon', 'Spendings'),
(2, 1100.00, '2023-12-10', 'Wynagrodzenie', 'Incomes'),
(2, 60.00, '2023-12-15', 'Zakup kosmetyków', 'Spendings'),
(2, 90.00, '2023-12-20', 'Obiad w restauracji', 'Spendings'),
(2, 220.00, '2023-12-25', 'Zlecenie', 'Incomes'),
(2, 50.00, '2023-12-30', 'Bilet na koncert', 'Spendings'),
(2, 240.00, '2024-01-05', 'Zakup elektroniki', 'Spendings'),
(2, 1200.00, '2024-01-10', 'Wynagrodzenie', 'Incomes'),
(2, 75.00, '2024-01-15', 'Zakup książek', 'Spendings'),
(2, 100.00, '2024-01-20', 'Opłata za internet', 'Spendings'),
(2, 310.00, '2024-01-25', 'Zlecenie', 'Incomes'),
(2, 55.00, '2024-01-30', 'Bilet do muzeum', 'Spendings'),
(2, 250.00, '2024-02-05', 'Zakup odzieży', 'Spendings'),
(2, 1000.00, '2024-02-10', 'Wynagrodzenie', 'Incomes'),
(2, 70.00, '2024-02-15', 'Obiad w restauracji', 'Spendings'),
(2, 80.00, '2024-02-20', 'Zakup artykułów biurowych', 'Spendings'),
(2, 230.00, '2024-02-25', 'Zlecenie', 'Incomes'),
(2, 45.00, '2024-02-28', 'Bilet do kina', 'Spendings'),
(2, 190.00, '2024-03-05', 'Opłata za telefon', 'Spendings'),
(2, 1100.00, '2024-03-10', 'Wynagrodzenie', 'Incomes'),
(2, 60.00, '2024-03-15', 'Zakup kosmetyków', 'Spendings'),
(2, 90.00, '2024-03-20', 'Obiad w restauracji', 'Spendings'),
(2, 240.00, '2024-03-25', 'Zlecenie', 'Incomes'),
(2, 50.00, '2024-03-30', 'Bilet na koncert', 'Spendings'),
(2, 220.00, '2024-04-05', 'Zakup elektroniki', 'Spendings'),
(2, 1200.00, '2024-04-10', 'Wynagrodzenie', 'Incomes'),
(2, 75.00, '2024-04-15', 'Zakup książek', 'Spendings'),
(2, 100.00, '2024-04-20', 'Opłata za internet', 'Spendings'),
(2, 300.00, '2024-04-25', 'Zlecenie', 'Incomes'),
(2, 55.00, '2024-04-30', 'Bilet do muzeum', 'Spendings'),
(2, 200.00, '2024-05-05', 'Zakup odzieży', 'Spendings'),
(2, 1000.00, '2024-05-10', 'Wynagrodzenie', 'Incomes'),
(2, 65.00, '2024-05-15', 'Obiad w restauracji', 'Spendings'),
(2, 85.00, '2024-05-20', 'Zakup artykułów biurowych', 'Spendings'),
(2, 210.00, '2024-05-25', 'Zlecenie', 'Incomes'),
(2, 45.00, '2024-05-30', 'Bilet do kina', 'Spendings'),
(2, 180.00, '2024-06-05', 'Opłata za telefon', 'Spendings'),
(2, 1100.00, '2024-06-10', 'Wynagrodzenie', 'Incomes'),
(2, 60.00, '2024-06-15', 'Zakup kosmetyków', 'Spendings');


-- Insert SavingGoals
INSERT INTO SavingGoals (UserID, Amount, GoalType, Description) VALUES
(1, 1000.00, 'Short-term', 'Vacation fund'),
(2, 5000.00, 'Long-term', 'Car fund');

-- Insert Reminders
INSERT INTO Reminders (UserID, Frequency, NextReminderDate, Description) VALUES
(1, 'Monthly', DATEADD(month, 1, GETDATE()), 'Rent payment'),
(2, 'Yearly', DATEADD(year, 1, GETDATE()), 'Insurance payment');


-- Insert PeriodicReports
INSERT INTO PeriodicReports (UserID, ReportType, DateFrom, DateTo, ReportData) VALUES
(1, 'Monthly', DATEADD(month, -1, GETDATE()), GETDATE(), 'Sample report data'),
(2, 'Yearly', DATEADD(year, -1, GETDATE()), GETDATE(), 'Sample report data');


