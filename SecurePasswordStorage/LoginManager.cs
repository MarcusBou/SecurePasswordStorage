using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePasswordStorage
{
    internal class LoginManager
    {
        private MockData mock;
        private Hash hash;
        public LoginManager()
        {
            mock = new MockData();
            hash = new Hash();
        }

        public string Login(string username, string password)
        {
            User existinguser = null;

            foreach (User user in mock.Users)
            {
                if (user.Username == username)
                {
                    existinguser = user;
                }
            }
            if (existinguser != null)
            {
                if (existinguser.Locked == false && existinguser.Attempts > 0)
                {
                    string hashedPass = Convert.ToBase64String(hash.HashPassword(Encoding.UTF8.GetBytes(password), existinguser.Salt, 1000));
                    string hashedPass1 = Convert.ToBase64String(hash.HashPassword(Encoding.UTF8.GetBytes(password), existinguser.Salt, 1000));
                    if (existinguser.Password == hashedPass)
                    {
                        return $"Logged in Succesfull as {existinguser.Username}";
                        existinguser.Attempts = 5;
                    }
                    else
                    {
                        if (existinguser.Attempts == 1)
                        {
                            existinguser.Attempts--;
                            existinguser.Locked = true;
                            return $"Wrong Password, user {existinguser.Username} is being locked";
                            
                        }
                        else
                        {
                            Console.WriteLine(existinguser.Password);
                            Console.WriteLine(hashedPass);
                            Console.WriteLine(hashedPass1);
                            existinguser.Attempts--;
                            return $"Wrong Password, you have {existinguser.Attempts} attempts left";
                        }
                    }
                }
                else
                {
                    return $"User {existinguser.Username} has been locked";
                }
            }
            else
            {
                return $"User {username} not found";
            }

        }
        

    }
}
