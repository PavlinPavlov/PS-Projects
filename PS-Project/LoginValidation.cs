using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Project
{
    class LoginValidation
    {
        public delegate void ActionOnError(string errorMsg);

        private string Username { get; set; }
        private string Password { get; set; }
        private string ErrorMessage { get; set; }
        private ActionOnError ErrorAction { get; set; }

        public static UserRole CurrentUserRole { private set; get; }

        

        public LoginValidation(string username, string password, ActionOnError errorDelegateFunction)
        {
            this.Username = username;
            this.Password = password;
            ErrorAction = new ActionOnError(errorDelegateFunction);
        }

        public bool ValidateUserInput(ref User user) 
        {
            if (Username.Length < 5)
            {
                ErrorMessage = "Username too short";
                ErrorAction(ErrorMessage);
                return false;
            }

            if (Password.Length < 5)
            {
                ErrorMessage = "Password too short";
                ErrorAction(ErrorMessage);
                return false;
            }

            user = UserData.IsUserPassCorrect(Username, Password);

            if (null == user)
            {
                ErrorMessage = "No such user found";
                CurrentUserRole = UserRole.ANONYMOUS;
                ErrorAction(ErrorMessage);
                return false;
            }

            CurrentUserRole = (UserRole) user.Role;
            Console.WriteLine(user.Role);
            return true;
        }
    }
}
