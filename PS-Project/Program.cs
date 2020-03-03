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

            Console.WriteLine(UserData.TestUsers[2].Role);
            ChooseOption(user);
            Console.WriteLine(UserData.TestUsers[2].Role);

            Console.Read(); // for pause
        }

        private static void ChooseOption(User loggedInUser)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("0: Log out");
                if (loggedInUser.Role == 1)
                {
                    Console.WriteLine("1: Change user role");
                    Console.WriteLine("2: Change user active date");
                }
                
                string username;
                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye");
                        exit = true;
                        break;
                    case 1:
                        if (loggedInUser.Role == 1)
                        {
                            Console.Write(" Enter username: ");
                            username = Console.ReadLine();
                            Console.Write(" Enter role: ");
                            UserRole role = (UserRole) int.Parse(Console.ReadLine());
                            UserData.AssignUserRole(username, role);
                        }
                       
                        break;
                    case 2:
                        if (loggedInUser.Role == 1)
                        {
                            Console.Write(" Enter username: ");
                            username = Console.ReadLine();
                            Console.Write(" Enter new active date: ");
                            DateTime newDate = DateTime.Parse(Console.ReadLine());
                            UserData.SetUserActiveTo(username, newDate);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public static void PrintTheGivenMessage(string msg)
        {
            Console.WriteLine("!!!" + msg + "!!!");
        }
    }
}
