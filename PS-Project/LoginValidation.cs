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

        public static string Username { get; set; }
        public static string Password { get; set; }

        private string ErrorMessage { get; set; }
        private ActionOnError ErrorAction { get; set; }

        public static UserRole CurrentUserRole { private set; get; }
          

        public LoginValidation(string username, string password, ActionOnError errorDelegateFunction)
        {
            Username = username;
            Password = password;
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
            Logger.LogActivity("Logged in successful as " + CurrentUserRole);

            return true;
        }
    }
}
