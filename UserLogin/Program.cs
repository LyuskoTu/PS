using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string passw = Console.ReadLine();
            int password = int.Parse(passw);

            LoginValidation.ActionOnError error = new LoginValidation.ActionOnError(LoginValidation.ErrorFunc);


            LoginValidation validation = new LoginValidation(username, password, error);
            validation.validUserName(username);
            validation.validUserPassword(password);
            User u = new User(username, password);
            u.role = 1;
            UserData.resetTestUserData();

            bool isFinished = true;
            while (isFinished && u.role == 1)
            {
                Console.WriteLine("Choose option:");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Change User Role");
                Console.WriteLine("2: Change User Activity");
                Console.WriteLine("3: Show All Users");
                Console.WriteLine("4: Show Activity Log");
                Console.WriteLine("5: Show Current Activity");
                string input =
                    Console.ReadLine();
                int realInput = int.Parse(input);
                if (realInput == 0)
                {
                    isFinished = false;
                    break;
                }
                else if (realInput == 1)
                {
                    Console.WriteLine("Choose new role");
                    Console.WriteLine("1: ADMIN");
                    Console.WriteLine("2: INSPECTOR");
                    Console.WriteLine("3: PROFESSOR");
                    Console.WriteLine("4: STUDENT");
                    string chosen = Console.ReadLine();
                    int chosenInNum = int.Parse(chosen);
                    if (chosenInNum == 1)
                    {
                        UserData.SetUserRoleTo(u.userName, UserRoles.ADMIN);
                    }

                    if (chosenInNum == 2)
                    {
                        UserData.SetUserRoleTo(u.userName, UserRoles.INSPECTOR);
                    }

                    if (chosenInNum == 3)
                    {
                        UserData.SetUserRoleTo(u.userName, UserRoles.PROFESSOR);
                    }

                    if (chosenInNum == 4)
                    {
                        UserData.SetUserRoleTo(u.userName, UserRoles.STUDENT);
                    }
                }
                else if (realInput == 2)
                {
                    UserData.SetUserActiveTo(u.userName, DateTime.Today);
                }
                else if (realInput == 3)
                {
                    UserData.ShowAllUsers();
                }
                else if (realInput == 4)
                {
                    Console.WriteLine("add filter data:");
                    string filter = Console.ReadLine();
                    IEnumerable<string> currentActs = Logger.GetSessionActivities(filter);
                    foreach (var line in currentActs)
                    {
                       Console.WriteLine(line);
                    }
                    // Logger.ShowLogActivity();
                }
                else if (realInput == 5)
                {
                    StringBuilder builder = new StringBuilder();
                    IEnumerable<string> currentActs = Logger.GetCurrentSessionActivities();
                    foreach (var line in currentActs)
                    {
                        builder.Append(line);
                    }
                    Console.WriteLine(builder.ToString());
                    //Logger.ShowCurrentActivity();
                }
            }
        }
    }
}