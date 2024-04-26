using System.Windows;
using RockLife.Classes;
using RockLife.Interfaces;
using RockLife.Login;
using RockLife.Repository;

namespace RockLife
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserRepository _userRepository;
        public LoginWindow()
        {
            InitializeComponent();
            _userRepository = new UserRepository(new RlContext());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Hide();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginField.Text;
            string password = PasswordField.Password; 

            User user = null;
            try
            {
                var users = await _userRepository.FindUsersByLoginAsync(login);
                user = users.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при поиске пользователя: " + ex.Message);
                return;
            }

            if (user != null)
            {
                
                if (user.Password == password)
                {
                    MessageBox.Show("Успешный вход в систему!");

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        AccountWindow accountWindow = new AccountWindow();
                        accountWindow.Show();
                        Close();
                    });
                }

                else
                {
                    MessageBox.Show("Неверный пароль!");
                }
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином не найден!");
            }
        }
    }
}
