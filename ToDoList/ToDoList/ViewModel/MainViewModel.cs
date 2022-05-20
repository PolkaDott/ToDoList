using System;
using System.Collections.ObjectModel;
using ToDoList.Model;
using Xamarin.Forms;

namespace ToDoList.ViewModel
{
    public class MainViewModel : BindableObject
    {
        public ObservableCollection<Task> TaskList { get; set; }
        public MainViewModel()
        {
            TaskList = new ObservableCollection<Task>();
            TaskList.Add(new Task("Initial Task 1"));
            TaskList.Add(new Task("Initial Task 2"));
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
            }
        });

        public Command<Task> RemoveTask => new Command<Task>((task) =>
        {
            TaskList.Remove(task);
        });
    }
}