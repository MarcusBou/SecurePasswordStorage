// See https://aka.ms/new-console-template for more information
using SecurePasswordStorage;
LoginManager lm = new LoginManager();
while(true)
{
    Console.Clear();
    Console.Write("Username: ");
    string username = Console.ReadLine();
    Console.Write("Password: ");
    string password = Console.ReadLine();
    Console.Clear();
    Console.WriteLine(lm.Login(username, password));
    Console.ReadKey();
}

