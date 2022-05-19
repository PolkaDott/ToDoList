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
        }

        public string Size
        {
            get => TaskList.Count.ToString();
        }
    }
}