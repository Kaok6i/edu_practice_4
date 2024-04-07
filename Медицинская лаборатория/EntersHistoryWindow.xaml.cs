using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Медицинская_лаборатория
{
    /// <summary>
    /// Логика взаимодействия для EntersHistoryWindow.xaml
    /// </summary>
    public partial class EntersHistoryWindow : Window
    {
        public EntersHistoryWindow()
        {
            InitializeComponent();
        }
        LaboratoryEntities entity = new LaboratoryEntities();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            entersDG.ItemsSource = entity.Enters.ToList();
        }

        private void backBttn_Click(object sender, RoutedEventArgs e)
        {
            var mainWndw = new MainWindow();
            mainWndw.Show();
            this.Close();
        }

        private void searchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            
                txtHintSearch.Visibility = Visibility.Visible;
                if (searchTB.Text.Length > 0)
                {
                    txtHintSearch.Visibility = Visibility.Hidden;
                }
            
        }
    }
}
