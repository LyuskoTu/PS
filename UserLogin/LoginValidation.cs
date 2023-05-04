using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        private string userName { get; }
        public static string CurrentUserUserName { get; set; }
        private int password;

        private string errorMessage { get; set; }

        public delegate void ActionOnError(string errorMsg);

        private ActionOnError action;

        public LoginValidation(string userName, int password, ActionOnError a)
        {
            this.userName = userName;
            this.password = password;
            this.action = a;
        }

        static public UserRoles currentUserRole { get; set; }

        public bool validateUserInput(User user)
        {
            bool isValidName = validUserName(user.userName);
            // if(isValidName){
            //     return false;
            // }
            //
            bool isValidPass = validUserPassword(user.password);
            // if(isValidPass){
            //    return false;
            // }
            if (!isValidName || !isValidPass) return false;
            var u = UserData.IsUserPassCorrect(user.userName, user.userName);
            CurrentUserUserName = user.userName;
            switch (u.role)
            {
                case 1:
                    currentUserRole = UserRoles.ADMIN;
                    u.UserRole = UserRoles.ADMIN;
                    break;
                case 2:
                    currentUserRole = UserRoles.PROFESSOR;
                    u.UserRole = UserRoles.PROFESSOR;
                    break;
                case 3:
                    currentUserRole = UserRoles.INSPECTOR;
                    u.UserRole = UserRoles.INSPECTOR;
                    break;
                case 4:
                    currentUserRole = UserRoles.STUDENT;
                    u.UserRole = UserRoles.STUDENT;
                    break;
                case 5:
                    currentUserRole = UserRoles.ANONYMOUS;
                    u.UserRole = UserRoles.ANONYMOUS;
                    break;
            }

            Logger.LogActivity("Successfully LogIn");
            return true;

        }

        public bool validUserName(string userName)
        {
            
            if (userName.Length <= 5)
            {
                ActionOnError actionOnError = new ActionOnError(ErrorFunc);
                Console.WriteLine(actionOnError);
                Console.WriteLine("UserName shoud be more than 5 symbols");
                return false;
            }

            return true;
        }

        public bool validUserPassword(int password)
        {
            if (password < 5)
            {
                Console.WriteLine("Password shoud be more than 5 symbols");
                return false;
            }
            
            return true;


        }

        static public void ErrorFunc(string s)
        {
            Console.WriteLine("Error occured while trying to log in");
        }

        private void SetErrorMessage(string error)
        {
            errorMessage = error;
        }
    }
}