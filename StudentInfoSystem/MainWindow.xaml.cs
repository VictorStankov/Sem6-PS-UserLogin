using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isLoggedIn = false;

        public MainWindow()
        {
            InitializeComponent();

            if (StudentData.TestStudentsIfEmpty())
                StudentData.CopyTestStudents();

            FillStudStatusChoices();

            Status.ItemsSource = StudStatusChoices;
        }

        private List<string> StudStatusChoices { get; set; }

        public void LoadStudent(Student student)
        {
            FirstName.Text = student.FirstName;
            MiddleName.Text = student.MiddleName;
            LastName.Text = student.Surname;
            Faculty.Text = student.Faculty;
            Specialty.Text = student.Specialty;
            Degree.Text = student.Degree;
            Status.Text = StudStatusChoices[student.Status - 1];
            FacultyNum.Text = student.FacultyNum.ToString();
            Year.Text = student.Year.ToString();
            Stream.Text = student.Stream.ToString();
            Group.Text = student.Group.ToString();
        }
        
        private void ClearInputs(DependencyObject control)
        {
            foreach (var obj in LogicalTreeHelper.GetChildren(control).OfType<Control>())
            {
                switch (obj)
                {
                    case TextBox textBox:
                        textBox.Clear();
                        break;
                    case ComboBox comboBox:
                        comboBox.SelectedItem = null;
                        break;
                    case DataGrid dataGrid:
                        dataGrid.ItemsSource = null;
                        break;
                }
            }

            foreach (var dependencyObject in LogicalTreeHelper.GetChildren(control).OfType<DependencyObject>())
                ClearInputs(dependencyObject);
        }

        private void login_logout_Click(object sender, RoutedEventArgs e)
        {
            if (_isLoggedIn)
            {
                ClearInputs(MainGrid);
                LoginLogout.Content = "Log in";
                _isLoggedIn = false;
            }
            else
            {
                var loginScreen = new LoginScreen(this);
                loginScreen.ShowDialog();
                
                if (string.IsNullOrEmpty(FacultyNum.Text))
                    return;
                
                LoginLogout.Content = "Log out";
                _isLoggedIn = true;
            }
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new SqlConnection(
                       ConfigurationManager.ConnectionStrings["DbConnection"].ToString()))
            {
                var sqlquery = @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();

                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;

                var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    var s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                }
            }
        }

        private void AddStudentGrade(int facNum, string className, int gradeNum)
        {
            using (var context = new StudentInfoContext())
            {
                Student student = context.Students.First(st => st.FacultyNum == facNum);

                if (student != null)
                {
                    context.Grades.Add(new Grade(student, className, gradeNum));
                    context.SaveChanges();
                }
            }
        }

        private void SubmitGrade_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(GradeNum.Text, out int gradeNum))
                return;

            if (int.TryParse(FacultyNum.Text, out int facNum))
            {
                AddStudentGrade(facNum, SubjectName.Text, gradeNum);
            }
        }
    }
}