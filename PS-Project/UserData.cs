using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Project
{
    static class UserData
    {

        private static User[] _testUsers;

        public static User[] TestUsers
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
                }
            }
        }

        public static void ResetTestUserData()
        {
            if (null == _testUsers)
            {
                _testUsers = new User[3];

                _testUsers[0] = new User();
                _testUsers[0].Name = "Stamat1";
                _testUsers[0].Password = "shhht123";
                _testUsers[0].FacultyNumber = "121217000";
                _testUsers[0].Role = 1;
                _testUsers[0].CreatedDate = DateTime.Now;
                _testUsers[0].ActiveDate = DateTime.MaxValue;

                _testUsers[1] = new User();
                _testUsers[1].Name = "Stamat2";
                _testUsers[1].Password = "shhht123";
                _testUsers[1].FacultyNumber = "121217001";
                _testUsers[1].Role = 4;
                _testUsers[1].CreatedDate = DateTime.Now;
                _testUsers[1].ActiveDate = DateTime.MaxValue;

                _testUsers[2] = new User();
                _testUsers[2].Name = "Stamat3";
                _testUsers[2].Password = "shhht123";
                _testUsers[2].FacultyNumber = "121217002";
                _testUsers[2].Role = 4;
                _testUsers[2].CreatedDate = DateTime.Now;
                _testUsers[2].ActiveDate = DateTime.MaxValue;
            }
        }
    }
}
