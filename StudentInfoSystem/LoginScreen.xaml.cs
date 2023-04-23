using System.Windows;
using UserLogin;

namespace StudentInfoSystem
{
    public partial class LoginScreen : Window
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
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
            var user = UserData.IsUserPassCorrect(Username, Password);
            if (user == null)
            {
                MessageBox.Show("Invalid credentials!");
                return;
            }
            
            var student = StudentValidation.GetStudentDataByUser(user);

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
