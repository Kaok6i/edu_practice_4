using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        CapthaGenerator Captha = new CapthaGenerator();
        int error = 0;

        public bool captcha;
        public CaptchaWindow()
        {
            InitializeComponent();
            Captcha.Source = Captha.CreateImageHard(800, 800);

        }

        private void refreshBttn_Click(object sender, RoutedEventArgs e)
        {
            Captcha.Source = Captha.CreateImageHard(800, 800);
        }

        private void checkBttn_Click(object sender, RoutedEventArgs e)
        {   
            if (Captha.CapthaChecker(ImageBox.Text))
            {
                
                MessageBox.Show("Вы прошли капчу!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                var atrztnWndw = new MainWindow();
                this.Close();
            }
            
            else
            {
                MessageBox.Show("Вы не прошли капчу!\nПопробуйте ещё раз через 10 секунд.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                captcha = false;
                this.Close();
            }
        }
    }
}
