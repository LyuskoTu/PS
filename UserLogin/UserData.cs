using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin

{
    public static class UserData
    {
        static public List<User> testUsers;

        static private List<User> _testUsers
            = new List<User>();

        static public void resetTestUserData()
        {
            _testUsers.Add(new User());
            // _testUsers.Add(new User());
            // _testUsers.Add(new User());
            // _testUsers.Add(new User());
            foreach (var user in _testUsers)
            {
                if (user == null)
                {
                    user.userName = "Toniiii";
                    user.password = 1234;
                    user.facultyNumber = 12345678;
                    user.role = 1;
                    user.createDate = DateTime.Today;
                    user.expireDate = DateTime.MaxValue;
                }
            }
        }

        static public User IsUserPassCorrect(string name, string pass)
        {
            User u = (from user in _testUsers
                where user.userName.Equals(name) && user.password.Equals(pass)
                select user).First();

            return u;
        }

        static public void SetUserActiveTo(string userName, DateTime expiringDate)
        {
            foreach (var user in _testUsers)
            {
                if (user.userName == userName && user.role == 1)
                {
                    user.expireDate = expiringDate;
                    Logger.LogActivity("Successfully Changed Activity");
                }
            }
        }

        public static void SetUserRoleTo(string userName, UserRoles newRole)
        {
            foreach (var user in _testUsers)
            {
                if (user.userName == userName && user.role == 1)
                {
                    user.UserRole = newRole;
                    Logger.LogActivity("Successfully Changed Role");
                }
            }
        }

        public static void ShowAllUsers()
        {
            foreach (var user in _testUsers)
            {
                Console.WriteLine(user.userName);
                Console.WriteLine(user.UserRole);
                Console.WriteLine(user.createDate);
            }
        }
    }
}