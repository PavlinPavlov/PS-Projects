using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            LoginValidation validation = new LoginValidation(username, password, PrintTheGivenMessage);

            User user = new User();
            validation.ValidateUserInput(ref user);
            Console.WriteLine(user.FacultyNumber);

            switch (LoginValidation.CurrentUserRole)
            {
                case UserRole.ADMIN:
                    Console.WriteLine("Role: Admin");
                    break;
                case UserRole.ANONYMOUS:
                    Console.WriteLine("Role: Anonymous");
                    break;
                case UserRole.INSPECTOR:
                    Console.WriteLine("Role: Inspector");
                    break;
                case UserRole.PROFESSOR:
                    Console.WriteLine("Role: Professor");
                    break;
                case UserRole.STUDENT:
                    Console.WriteLine("Role: Student");
                    break;
                default:
                    Console.WriteLine("Role: None");
                    break;
            }


            Console.Read(); // for pause
        }

        public static void PrintTheGivenMessage(string msg)
        {
            Console.WriteLine("!!!" + msg + "!!!");
        }
    }
}
