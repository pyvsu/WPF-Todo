using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace app
{
    public interface ITaskManager
    {
        void AddTask(string taskName);
        void EditTask(int index, string taskName);
        void DeleteTask(int index);
    }

    public partial class MainWindow : Window, ITaskManager
    {
        private ObservableCollection<TaskItem> Tasks { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Tasks = new ObservableCollection<TaskItem>();
            taskList.ItemsSource = Tasks;


        }
        public void RefreshListView()
        {
            var itemsSource = taskList.ItemsSource;
            taskList.ItemsSource = null;
            taskList.ItemsSource = itemsSource;
        }


        public void AddTask(string taskName)
        {
            Tasks.Add(new TaskItem(taskName));
        }

        public void EditTask(int index, string taskName)
        {
            Tasks[index].UpdateTaskName(taskName);
            RefreshListView();
        }

        public void DeleteTask(int index)
        {
            Tasks.RemoveAt(index);
        }

        public class TaskItem
        {
            public string TaskName { get; set; }

            public TaskItem(string taskName)
            {
                TaskName = taskName;
            }

            public virtual string DisplayTask()
            {
                return TaskName;
            }

            public void UpdateTaskName(string newTaskName)
            {
                TaskName = newTaskName;
            }
        }



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

        private void DeleteTask(object sender, RoutedEventArgs e)
        {
            if (taskList.SelectedItem != null)
            {
                DeleteTask(taskList.SelectedIndex);
            }
        }

        private int selectedIndex = -1;
        private bool isEditing = false;
    }
}
