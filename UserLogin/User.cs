using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public int UserId { get; set; }
        private string _userName;

        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private int _password;

        public int password
        {
            get { return _password; }
            set { _password = value; }
        }

        private int _facultyNumber;

        public int facultyNumber
        {
            get { return _facultyNumber; }
            set { _facultyNumber = value; }
        }

        private int _role;

        public int role
        {
            get { return _role; }
            set { _role = value; }
        }

        public DateTime createDate { get; set; }

        public DateTime expireDate { get; set; }

        public UserRoles UserRole { get; set; }

        public User()
        {
        }

        public User(string userName, int password)
        {
            _userName = userName;
            _password = password;
        }
    }
}