using Xamarin.Forms;

namespace ToDoList.Model
{
    public class Task : BindableObject
    {
        public Task(string title)
        {
            _title = title;
            _isDone = false;
        }
        public Task(string title, bool isDone)
        {
            _title = title;
            _isDone = isDone;
        }

        private string _title;
        public string Title
        {
            get => _title;
            set 
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private bool _isDone;
        public bool IsDone
        {
            get => _isDone;
            set
            {
                _isDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }
    }
}
