using System;
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
        });

        public void SaveTasksToStorage()
        {
            Preferences.Set("tasks", JsonConvert.SerializeObject(TaskList));
        }

        public void GetTasksFromStorage()
        {
            string items = Preferences.Get("tasks", "[]");
            TaskList = new ObservableCollection<Task>( JsonConvert.DeserializeObject<ObservableCollection<Task>>(items));
            OnPropertyChanged(nameof(TaskList));
        }
    }
}