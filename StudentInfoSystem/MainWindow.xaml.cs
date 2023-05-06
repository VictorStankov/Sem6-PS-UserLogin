using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace StudentInfoSystem
{
    public partial class MainWindow : Window
    {
        private bool _isLoggedIn = false;
        private int tabNum;  // Used for when the "Grades" tab is open right after logging in

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
                _isLoggedIn = SaveButton.IsEnabled = false;
            }
            else
            {
                var loginScreen = new LoginScreen(this);
                loginScreen.ShowDialog();
                
                if (string.IsNullOrEmpty(FacultyNum.Text))
                    return;
                
                LoginLogout.Content = "Log out";
                _isLoggedIn = SaveButton.IsEnabled = true;
                
                if (tabNum == 1)
                    LoadStudentGrades();
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

        private void LoadStudentGrades()
        {
            GradeGrid.ItemsSource = null;
            GradeGrid.Items.Clear();
                
            if (!_isLoggedIn)
                return;
                
            var grades = GetUserGrades(int.Parse(FacultyNum.Text));
            GradeGrid.ItemsSource = grades;
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tabNum = TabControl.SelectedIndex;
            if (tabNum == 1)
            {
                LoadStudentGrades();
            }
        }

        private List<GradeShort> GetUserGrades(int facNum)
        {
            List<GradeShort> result = new List<GradeShort>();
            using (var context = new StudentInfoContext())
            {
                Student student = context.Students.First(st => st.FacultyNum == facNum);

                if (student != null)
                {
                    var a = context.Grades.Where(grade => grade.Student.StudentId == student.StudentId).Select(grade => new {grade.GradeNum, grade.ClassName}).ToList();
                    result.AddRange(a.Select(grade => new GradeShort(grade.GradeNum, grade.ClassName)));
                }
            }

            return result;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new Microsoft.Win32.SaveFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt",
                Title = "Save Student Information"
            };

            var result = fileDialog.ShowDialog();

            if (result != true)
                return;
            
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Лична Информация:\nИме:\t\t{FirstName.Text}\nПрезиме:\t{MiddleName.Text}\n" +
                                 $"Фамилия:\t{LastName.Text}\n\nСтудентска Информация:\nФакултет:\t\t{Faculty.Text}\n" +
                                 $"Специалност:\t{Specialty.Text}\nОКС:\t\t\t{Degree.Text}\nСтатус:\t\t{Status.Text}\n" +
                                 $"Факултетен номер:\t{FacultyNum.Text}\nКурс:\t\t\t{Year.Text}\nПоток:\t\t{Stream.Text}\n" +
                                 $"Група:\t\t{Group.Text}\n\nОценки:\n");

            foreach (GradeShort grade in GetUserGrades(int.Parse(FacultyNum.Text)))
                stringBuilder.Append(grade + "\n");

            File.WriteAllText(fileDialog.FileName, stringBuilder.ToString());
        }
    }
}
