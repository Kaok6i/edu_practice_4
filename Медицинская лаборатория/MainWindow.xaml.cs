using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Медицинская_лаборатория
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool captcha = true;
        DispatcherTimer Timer = new DispatcherTimer();

        int sec = 10;
        public MainWindow()
        {
            InitializeComponent();
            passwordCloseButton.Visibility = Visibility.Hidden;
        }
        LaboratoryEntities entity = new LaboratoryEntities();
        int errorCount = 0;
        private void logBttn_Click(object sender, RoutedEventArgs e)
        {

                if (entity.Employees.Any(u => u.Login == loginTB.Text) &&
                (entity.Employees.Any(u => u.Password == passwordTB.Text)
                || entity.Employees.Any(u => u.Password == passwordPB.Password)))
                //проверка логина и пароля на существование в бд

                {

                    Employees user = entity.Employees.
                        First(x => x.Login == loginTB.Text);
                    errorCount = 0;
                    if (user.ID_Role == 2)
                    {
                        var entersWndw = new EntersHistoryWindow();
                        entersWndw.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Вы успешно зашли, но не имеете доступа к истории входов," +
                            "\nтак как вы не администратор.",
                            "Уведомление", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось войти в систему", "Уведомление",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    errorCount++;
                }
            
            if(errorCount >1)
            {
                var cptchWndw = new CaptchaWindow();
                cptchWndw.ShowDialog();
                if (captcha == false)
                {
                    loginTB.IsEnabled = false;
                    passwordPB.IsEnabled = false;
                    passwordTB.IsEnabled = false;
                    logBttn.IsEnabled = false;
                    countDownTB.Visibility = Visibility.Visible;
                    sec = 10;
                    timer();
                }
            }
        }
        public void timer()
        {
            
            Timer.Interval = new TimeSpan(0, 0, 0, 1);
            Timer.Tick += DispatcherTimer_Tick;
            Timer.Start();
        }
        void DispatcherTimer_Tick(object sender, EventArgs e)
        {

            if (sec > 0)
            {
                sec--;
                countDownTB.Text = String.Format("0{0}:{1}", sec / 60, sec % 60);
            }
            else
            {
                Timer.Tick -= DispatcherTimer_Tick;
                Timer.Stop();
                loginTB.IsEnabled = true;
                passwordPB.IsEnabled = true;
                passwordTB.IsEnabled = true;
                logBttn.IsEnabled = true;
                countDownTB.Visibility = Visibility.Hidden;
                ;
                errorCount = 0;
            }
        }
        private void passwordPB_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtHintPassword.Visibility = Visibility.Visible;
            if (passwordPB.Password.Length > 0)
            {
                txtHintPassword.Visibility = Visibility.Hidden;
            }
        }

        private void loginTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtHintLogin.Visibility = Visibility.Visible;
            if (loginTB.Text.Length > 0)
            {
                txtHintLogin.Visibility = Visibility.Hidden;
            }
        }
        private void passwordOpenButton_Click(object sender, RoutedEventArgs e)//функция для открытия пароль
        {
            passwordOpenButton.Visibility = Visibility.Hidden;
            passwordCloseButton.Visibility = Visibility.Visible;
            passwordTB.Text = passwordPB.Password;
            passwordTB.Visibility = Visibility.Visible;
            passwordPB.Visibility = Visibility.Hidden;
        }

        private void passwordCloseButton_Click(object sender, RoutedEventArgs e)//функция для закрытия пароля
        {
            passwordOpenButton.Visibility = Visibility.Visible;
            passwordCloseButton.Visibility = Visibility.Hidden;
            passwordPB.Password = passwordTB.Text;
            passwordTB.Visibility = Visibility.Hidden;
            passwordPB.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
