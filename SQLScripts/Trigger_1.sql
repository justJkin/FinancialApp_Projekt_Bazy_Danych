CREATE TRIGGER trgBeforeUserDelete
ON Users
INSTEAD OF DELETE
AS
BEGIN
    -- Deklaracja zmiennych
    DECLARE @UserID INT;
    DECLARE @TransactionCount INT;

    -- Pobranie ID usuwanego u�ytkownika
    SELECT @UserID = UserID FROM deleted;

    -- Sprawdzenie, czy u�ytkownik ma jakie� transakcje
    SELECT @TransactionCount = COUNT(*)
    FROM Transactions
    WHERE UserID = @UserID;

    -- Je�li u�ytkownik ma transakcje, anuluj usuni�cie i wypisz komunikat
    IF @TransactionCount > 0
    BEGIN
        PRINT 'Nie mo�na usun�� u�ytkownika. U�ytkownik ma przypisane transakcje.';
    END
    ELSE
    BEGIN
        -- Usu� u�ytkownika
        DELETE FROM Users
        WHERE UserID = @UserID;

        -- Wypisz komunikat
        PRINT 'U�ytkownik zosta� usuni�ty. U�ytkownik nie mia� �adnych transakcji na koncie.';
    END
END;
GO


-- Pr�bujemy usun�� u�ytkownika o UserID 1 (Admin), kt�ry ma transakcje
DELETE FROM Users WHERE UserID = 1;





public void DeleteUser(int id)
{
    var user = _context.Users.Find(id);
    if (user != null)
    {
        _context.Users.Remove(user);
    }
}


private void DeleteUser_Click(object sender, RoutedEventArgs e)
{
    if (UsersListView.SelectedItem is User selectedUser)
    {
        _userService.DeleteUser(selectedUser.UserID);
        LoadUsers();
    }
    else
    {
        MessageBox.Show("Please select a user to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}

 public void UpdateUser(User user)
 {
     _context.Users.Update(user);
 }

  private void UpdateUser_Click(object sender, RoutedEventArgs e)
 {
     if (UsersListView.SelectedItem is User selectedUser)
     {
         selectedUser.Username = UsernameTextBox.Text;
         selectedUser.Password = PasswordTextBox.Password;
         selectedUser.Email = EmailTextBox.Text;
         _userService.UpdateUser(selectedUser);
         LoadUsers();
     }
     else
     {
         MessageBox.Show("Please select a user to update.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
     }
 }