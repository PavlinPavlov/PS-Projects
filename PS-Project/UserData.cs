using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Project
{
    static public class UserData
    {

        private static List<User> _testUsers;

        public static List<User> TestUsers
        {
            get {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            User result = null;

            foreach (User item in TestUsers)
            {
                if (item.Name.Equals(username) && item.Password.Equals(password))
                {
                    result = item;
                    break;
                }
            }

            return result;
        }

        public static void SetUserActiveTo(string username, DateTime activeTo)
        {
            if (null == _testUsers)
            {
                ResetTestUserData();
            }

            foreach (User item in _testUsers)
            {
                if (item.Name.Equals(username))
                {
                    item.ActiveDate = activeTo;
                    Logger.LogActivity("Changed active status of " + username);
                }
            }
        }

        public static void AssignUserRole(string username, UserRole newRole)
        {
            if (null == _testUsers)
            {
                ResetTestUserData();
            }

            foreach (User item in _testUsers)
            {
                if (item.Name.Equals(username))
                {
                    item.Role = (int) newRole;
                    Logger.LogActivity("Assigned new role to " + username);
                }
            }
        }

        public static void ResetTestUserData()
        {
            if (null == _testUsers)
            {
                _testUsers = new List<User>(3);

                User user1 = new User();
                user1.Name = "Stamat1";
                user1.Password = "shhht123";
                user1.FacultyNumber = "121217000";
                user1.Role = 1;
                user1.CreatedDate = DateTime.Now;
                user1.ActiveDate = DateTime.MaxValue;
                _testUsers.Add(user1);

                User user2 = new User();
                user2.Name = "Stamat2";
                user2.Password = "shhht123";
                user2.FacultyNumber = "121217001";
                user2.Role = 4;
                user2.CreatedDate = DateTime.Now;
                user2.ActiveDate = DateTime.MaxValue;
                _testUsers.Add(user2);

                User user3 = new User();
                user3.Name = "Stamat3";
                user3.Password = "shhht123";
                user3.FacultyNumber = "121217002";
                user3.Role = 4;
                user3.CreatedDate = DateTime.Now;
                user3.ActiveDate = DateTime.MaxValue;
                _testUsers.Add(user3);
            }
        }
    }
}
