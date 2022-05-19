using Xamarin.Forms;

namespace ToDoList.Model
{
    public class Task : BindableObject
    {
        public Task(string title)
        {
            Title = title;
            IsDone = true;
        }
        public string Title
        {
            get => Title;
            set 
            {
                Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public bool IsDone
        {
            get => IsDone;
            set
            {
                IsDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }
    }
}
