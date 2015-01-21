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

namespace UserProfile
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        public CreateUserWindow()
        {
            InitializeComponent();
        }

        //private void UserManagementBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    var newForm = new UserManagement();
        //    newForm.Show();
        //    //this.Close();            
        //}

        private void Label_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
