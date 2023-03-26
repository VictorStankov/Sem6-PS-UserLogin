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
            foreach (var field in MainGrid.Children)
                if (field is TextBox)
                    ((TextBox)field).Clear();
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
            foreach (var field in MainGrid.Children)
                if (field is TextBox box)
                    box.IsEnabled = false;
        }

        private void SetInactive_Click(object sender, RoutedEventArgs e)
        {
            SetInputsInactive();
        }

        public void SetInputsActive()
        {
            foreach (var field in MainGrid.Children)
                if (field is TextBox box)
                    box.IsEnabled = true;
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

    }
}