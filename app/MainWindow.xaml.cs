using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace app
{
    
    // Abstraction
    // Interface defining the basic operations for managing tasks
    public interface ITaskManager
    {
        void AddTask(string taskName);
        void EditTask(int index, string taskName);
        void DeleteTask(int index);
    }

   
    // MainWindow class that serves as the application's main window and implements ITaskManager interface
    public partial class MainWindow : Window, ITaskManager
    {
        // Collection to hold TaskItem objects
        private ObservableCollection<TaskItem> Tasks { get; set; }


        // Encapsulation
        // Constructor initializing the window components and Tasks collection
        public MainWindow()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<TaskItem>();
            taskList.ItemsSource = Tasks;
        }

        // Method to refresh the ListView
        public void RefreshListView()
        {
            var itemsSource = taskList.ItemsSource;
            taskList.ItemsSource = null;
            taskList.ItemsSource = itemsSource;
        }

        // Implementation of AddTask method from ITaskManager interface
        public void AddTask(string taskName)
        {
            Tasks.Add(new TaskItem(taskName));
        }

        // Implementation of EditTask method from ITaskManager interface
        public void EditTask(int index, string taskName)
        {
            Tasks[index].UpdateTaskName(taskName);
            RefreshListView();
        }

        // Implementation of DeleteTask method from ITaskManager interface
        public void DeleteTask(int index)
        {
            Tasks.RemoveAt(index);
        }

        // Encapsulation
        // TaskItem class representing a task
        public class TaskItem
        {
            public string TaskName { get; set; }

            // Constructor initializing TaskName
            public TaskItem(string taskName)
            {
                TaskName = taskName;
            }

            // Polymorphism
            // Virtual method to display the task, can be overridden in derived classes
            public virtual string DisplayTask()
            {
                return TaskName;
            }

            // Method to update the task name
            public void UpdateTaskName(string newTaskName)
            {
                TaskName = newTaskName;
            }
        }

        // Event handler for saving or editing a task
        private void SaveTask(object sender, RoutedEventArgs e)
        {
            if (isEditing)
            {
                EditTask(selectedIndex, taskInput.Text);
            }
            else
            {
                AddTask(taskInput.Text);
            }

            isEditing = false;
            taskInput.Clear();
        }

        // Event handler for initiating task editing
        private void EditTask(object sender, RoutedEventArgs e)
        {
            if (taskList.SelectedItem != null)
            {
                isEditing = true;
                taskInput.Text = taskList.SelectedItem.ToString();
                taskInput.Focus();
                selectedIndex = taskList.SelectedIndex;
            }
        }

        // Event handler for deleting a task
        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            if (taskList.SelectedItem != null)
            {
                DeleteTask(taskList.SelectedIndex);
            }
        }

        // Fields to keep track of the selected index and editing state
        private int selectedIndex = -1;
        private bool isEditing = false;
    }
}