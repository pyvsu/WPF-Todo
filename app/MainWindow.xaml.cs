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
        public MainWindow()
        {
            InitializeComponent();

            List<TaskItem> tasks = new()
            {
                new TaskItem("Code"),
                new TaskItem("Eat")
            };

            // Set the ItemsSource of the DataGrid to the list of people
            
    }

    class TaskItem
        {
            public string Task { get; set; }

            public TaskItem(string task)
            {
                Task = task;
            }

            
        }

        bool isEditing = false;

        // CRUD Operations
        private void SaveTask(object sender, RoutedEventArgs e)
        {
            if (isEditing) 
            {
                // implement logic for editing item
            }
            else
            {
                string newTask = taskInput.Text;
                taskList.Items.Add(newTask);
                
            }

            isEditing = false;
            taskInput.Clear();
        }

        private void EditTask(object sender, RoutedEventArgs e)
        {
            isEditing = true;
            taskInput.Text = taskList.SelectedItem.ToString();
        }

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            // implement logic for deleting item
        }

        private void addTaskHere(object sender, TextChangedEventArgs e)
        {

        }
    }
}
