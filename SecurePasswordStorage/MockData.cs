using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswordStorage
{
    internal class MockData
    {
        private List<User> users = new List<User>();
        private Hash hash = new Hash();

        public List<User> Users { get { return users; } }

        public MockData()
        {
            int iteration = 1000;
            byte[] salt = hash.GenerateSalt();
            users.Add(new User("Kris", Convert.ToBase64String(hash.HashPassword(Encoding.UTF8.GetBytes("Kris1234"),salt,iteration)),salt));
            salt = hash.GenerateSalt();
            users.Add(new User("Camilla", Convert.ToBase64String(hash.HashPassword(Encoding.UTF8.GetBytes("Camilla1234"), salt, iteration)), salt));
            salt = hash.GenerateSalt();
            users.Add(new User("Mikkel", Convert.ToBase64String(hash.HashPassword(Encoding.UTF8.GetBytes("Mikkel1234"), salt, iteration)), salt));
            salt = hash.GenerateSalt();
            users.Add(new User("Christian", Convert.ToBase64String(hash.HashPassword(Encoding.UTF8.GetBytes("Christian1234"), salt, iteration)), salt));
        }
    }
}
