using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TaskItem> Tasks { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Tasks = new ObservableCollection<TaskItem>
        {
            
        };

            // Set the ItemsSource of the DataGrid to the list of tasks
            taskList.ItemsSource = Tasks;
        }
        public class TaskItem
        {
            public string TaskName { get; set; }

            public TaskItem(string taskName)
            {
                TaskName = taskName;
            }

            public override string ToString()
            {
                return TaskName;
            }
        }


        // CRUD Operations
        private void SaveTask(object sender, RoutedEventArgs e)
        {
            if (isEditing)
            {
                // implement logic for editing item
                Tasks[selectedIndex] = new TaskItem(taskInput.Text);
            }
            else
            {
                string newTask = taskInput.Text;
                Tasks.Add(new TaskItem(newTask));
            }

            isEditing = false;
            taskInput.Clear();
        }


        private void EditTask(object sender, RoutedEventArgs e)
        {
            if (taskList.SelectedItem != null)
            {
                isEditing = true;
                taskInput.Text = taskList.SelectedItem.ToString();
                taskInput.Focus(); // Set the focus to the taskInput TextBox
                selectedIndex = taskList.SelectedIndex;
            }
        }
        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            if (taskList.SelectedItem != null)
            {
                Tasks.RemoveAt(taskList.SelectedIndex);
            }
        }

        private void addTaskHere(object sender, TextChangedEventArgs e)
        {

        }

        private int selectedIndex = -1;
        private bool isEditing = false;
    }
}
