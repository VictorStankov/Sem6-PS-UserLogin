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

namespace StudentInfoName
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
            Status.Text = student.Status.ToString();
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
    }
}
