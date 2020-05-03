using UserLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        private LoginValidation _validator;

        public LoginForm()
        {
            InitializeComponent();

            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();

            UserLoginContext usersContext = new UserLoginContext();
            foreach (User user in UserData.TestUsers)
            {
                usersContext.Users.Add(user);
            }
            usersContext.SaveChanges();
        }

        public void Login(object sender, RoutedEventArgs e)
        {
            User user = new User();

            _validator = new LoginValidation(UsernameInput.Text, PasswordInput.Text, PrintError);
            _validator.ValidateUserInput(ref user);

            if (user == null)
            {
                MessageBox.Show("Грешка");
            }
            else
            {
                MainForm next = new MainForm();
                next.Show();
                this.Close();
            }

        }

        private void PrintError(string msg)
        {
            MessageBox.Show(msg);
        }

    }
}
