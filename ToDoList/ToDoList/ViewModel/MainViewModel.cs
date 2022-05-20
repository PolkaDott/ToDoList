using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDoList.Model;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace ToDoList.ViewModel
{
    public class MainViewModel : BindableObject
    {
        public ObservableCollection<Task> TaskList { get; set; }
        public MainViewModel()
        {
            GetTasksFromStorage();
            //TaskList.Add(new Task("Initial Task 1"));
            //TaskList.Add(new Task("Initial Task 2"));
        }

        private string _inputField;
        public string InputField
        {
            get => _inputField;
            set
            {
                if (_inputField != value)
                {
                    _inputField = value;
                    OnPropertyChanged(nameof(InputField));
                }
            }
        }

        public Command AddTask => new Command(() =>
        {
            if (string.IsNullOrWhiteSpace(InputField) == false)
            {
                TaskList.Insert(0, new Task(InputField));
                InputField = "";
                SaveTasksToStorage();
            }
        });

        public Command<Task> RemoveTask => new Command<Task>((task) =>
        {
            TaskList.Remove(task);
            SaveTasksToStorage();
        });

        public void SaveTasksToStorage()
        {
            List<(string, bool)> tasks = new List<(string, bool)>(); // этот костыль пришлось сделать из-за того, что Task наследует BindableObject и у него есть поля, которые невозможно десеарилизовать, из-за чего возникало исключение в строке 62 при десеарилизации
            foreach (Task task in TaskList)
                tasks.Add((task.Title, task.IsDone));
            string items = JsonConvert.SerializeObject(tasks);
            Preferences.Set("tasks",items);
        }

        public void GetTasksFromStorage()
        {
            string items = Preferences.Get("tasks", "[]");
            List<(string, bool)> tasks = JsonConvert.DeserializeObject<List<(string, bool)>>(items);
            TaskList = new ObservableCollection<Task>();
            foreach ((string, bool) task in tasks)
                TaskList.Add(new Task(task.Item1, task.Item2));
            OnPropertyChanged(nameof(TaskList));
        }
    }
}