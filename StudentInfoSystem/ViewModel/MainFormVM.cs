using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentInfoSystem.ViewModel
{
    class MainFormVM : INotifyPropertyChanged
    {
        private readonly Student _studentProp;
        public Student StudentProp { get { Student s = new Student(); s.Degree = "Test"; return s;  } set { } }
        public bool IsEnabled { get; set; }

        // from INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand EnableCommand
        {
            get { return new BasicCommand(SwapIsEnabled); }
        }

        private void SwapIsEnabled()
        {
            IsEnabled = !IsEnabled;
            PropertyChanged(this, new PropertyChangedEventArgs("IsEnabled"));
        }

    }

}
