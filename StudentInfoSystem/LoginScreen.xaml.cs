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
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public String Username { get; set; }
        public String Password { get; set; }
        MainWindow mainWindow;

        public LoginScreen()
        {
            InitializeComponent();
        }

        public LoginScreen(object caller)
        {
            InitializeComponent();
            mainWindow = (MainWindow)caller;
        }
        

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            User user = UserData.IsUserPassCorrect(Username, Password);
            if (user == null)
            {
                MessageBox.Show("Invalid credentials!");
                return;
            }
            
            StudentValidation studentValidation = new StudentValidation();
            Student student = studentValidation.GetStudentDataByUser(user);

            if (student == null)
            {
                MessageBox.Show("Student not found!");
                return;
            }
            mainWindow.LoadStudent(student);
            Close();
        }
    }
}
