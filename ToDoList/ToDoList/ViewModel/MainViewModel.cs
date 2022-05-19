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
            TaskList.Add(new Task("Initial Task"));
            OnPropertyChanged(nameof(TaskList));
        }

        public string InputField
        {
            get => InputField;
            set
            {
                if (InputField != value)
                {
                    InputField = value;
                    OnPropertyChanged(nameof(InputField));
                }
            }
        }

        public int Size
        {
            get => TaskList.Count;
        }

        public Command AddTask => new Command(() =>
        {
            InputField = "";
            if (string.IsNullOrWhiteSpace(InputField) == false)
            {
                TaskList.Add(new Task(InputField));
                InputField = "";
            }
        });
    }
}