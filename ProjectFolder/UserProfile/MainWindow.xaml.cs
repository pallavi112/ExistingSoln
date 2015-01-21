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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserProfile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabItem_KeyDown(object sender, KeyEventArgs e)
        {

        }



        private void AddModule_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void CreateNewClient_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new CreateClient();
            newForm.Show();
        }

        private void CreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new CreateUserWindow();
            newForm.Show();
        }

        private void CreateNewUserGroup_Click(object sender, RoutedEventArgs e)
        {
            var newForm = new CreateUserGroup();
            newForm.Show();
        }
    }
}
