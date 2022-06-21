using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswordStorage
{
    internal class User
    {
        private string username;
        private string password;
        private byte[] salt;
        private bool locked;
        private int attempts;

        public string Username { get { return username; } } 
        public string Password { get { return password; } set { password = value; } }
        public byte[] Salt { get { return salt; } set { salt = value; } }
        public bool Locked { get { return locked; } set { locked = value; } }
        public int Attempts { get { return attempts; } set { attempts = value; } }

        public User(string username, string password, byte[] salt)
        {
            this.username = username;
            this.password = password;
            this.salt = salt;
            this.locked = false;
            this.attempts = 5;
        }
    }
}
