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
        private bool isLoggedIn = false;

        public MainWindow()
        {
            InitializeComponent();

            if (StudentData.TestStudentsIfEmpty())
                StudentData.CopyTestStudents();

            FillStudStatusChoices();

            Status.ItemsSource = StudStatusChoices;
        }

        public List<string> StudStatusChoices { get; set; }

        public void ClearAllInputs()
        {
            foreach (object field in PersonalDetails.Children)
                if (field is TextBox textBox)
                    textBox.Clear();
                else if (field is ComboBox comboBox)
                    comboBox.SelectedItem = null;

            foreach (object field in StudentInformation.Children)
                if (field is TextBox textBox)
                    textBox.Clear();
                else if (field is ComboBox comboBox)
                    comboBox.SelectedItem = null;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearAllInputs();
        }

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

        private void LoadTestStudent_Click(object sender, RoutedEventArgs e)
        {
            LoadStudent(StudentData.TestStudents[0]);
        }

        public void SetInputsInactive()
        {
            foreach (object field in PersonalDetails.Children)
                if (field is TextBox textBox)
                    textBox.IsEnabled = false;
                else if (field is ComboBox comboBox)
                    comboBox.IsEnabled = false;
                else if (field is Button button)
                    button.IsEnabled = false;

            foreach (object field in StudentInformation.Children)
                if (field is TextBox textBox)
                    textBox.IsEnabled = false;
                else if (field is ComboBox comboBox)
                    comboBox.IsEnabled = false;
                else if (field is Button button)
                    button.IsEnabled = false;
        }

        private void SetInactive_Click(object sender, RoutedEventArgs e)
        {
            SetInputsInactive();
        }

        public void SetInputsActive()
        {
            foreach (object field in PersonalDetails.Children)
                if (field is TextBox textBox)
                    textBox.IsEnabled = true;
                else if (field is ComboBox comboBox)
                    comboBox.IsEnabled = true;
                else if (field is Button button)
                    button.IsEnabled = true;

            foreach (object field in StudentInformation.Children)
                if (field is TextBox textBox)
                    textBox.IsEnabled = true;
                else if (field is ComboBox comboBox)
                    comboBox.IsEnabled = true;
                else if (field is Button button)
                    button.IsEnabled = true;
        }

        private void SetActive_Click(object sender, RoutedEventArgs e)
        {
            SetInputsActive();
        }

        private void login_logout_Click(object sender, RoutedEventArgs e)
        {
            if (isLoggedIn)
            {
                ClearAllInputs();
                login_logout.Content = "Log in";
                isLoggedIn = false;
            }
            else
            {
                LoadStudent(StudentData.TestStudents.OrderBy(student => student.FacultyNum).First());
                login_logout.Content = "Log out";
                isLoggedIn = true;
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

        private void AddStudentGrade(int FacNum, string className, int gradeNum)
        {
            StudentInfoContext context = new StudentInfoContext();

            Student student = context.Students.Where(st => st.FacultyNum == FacNum).First();

            if (student != null)
            {
                context.Grades.Add(new Grade(student, className, gradeNum));
                context.SaveChanges();
            }
        }

        private void SubmitGrade_Click(object sender, RoutedEventArgs e)
        {
            int facNum, gradeNum;
            if (!int.TryParse(GradeNum.Text, out gradeNum))
                return;

            if (int.TryParse(FacultyNum.Text, out facNum))
            {
                AddStudentGrade(facNum, SubjectName.Text, gradeNum);
            }
        }
    }
}