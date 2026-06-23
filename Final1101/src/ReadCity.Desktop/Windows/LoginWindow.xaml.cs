using System.Windows;
using ReadCity.Desktop.Services;

namespace ReadCity.Desktop
{
    /// <summary>
    /// Код окна авторизации пользователя.
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginBox.Focus();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var user = AppServices.Auth.Login(LoginBox.Text, PasswordBox.Password);
            if (user is null)
            {
                ErrorText.Text = "Неверный логин или пароль.";
                return;
            }

            AppState.CurrentUser = user;
            AppSettings.SaveCurrentUser(user);
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
