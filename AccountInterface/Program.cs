using System;
using AccountInterface.exceptions;
using AccountInterface.Models;

namespace AccountInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string fullName = "";
            string email = "";
            string password = "";
            bool resultFullname;
            bool resultFullnameCompitable;
            bool resultPassword;
            bool resultEmail;
            User[] users = new User[0];
            int choice = 0;
            

            do
            {
            Start:
                try
                {
                    Console.WriteLine($"[0] - Stop Program\n[1] - Create account\n[2] - Information");
                    Console.Write("Select: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Only Numbers Allowed");
                    goto Start;
                }
                switch (choice)
                
                {
                    case 0:
                        Console.WriteLine("Program Stopped");
                        break;
                    case 1:
                        fullName:
                        try 
                        {
                            SetFullNameInput(ref fullName);
                            resultFullname = User.CheckFullName(ref fullName);
                            if (resultFullname==false)
                                goto fullName;
                            resultFullnameCompitable = User.CheckFullnameCompitable(ref fullName);
                            if (resultFullnameCompitable == false)
                                goto fullName;
                        }
                        catch (Exception ex) { Console.WriteLine($"Unexpected error: {ex.Message}"); goto fullName; }

                    SetEmail:
                        try
                        {
                            SetEmailInput(ref email);
                            resultEmail = User.EmailChecker(email);
                            if (resultEmail==false)
                                goto SetEmail;
                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Unexpected error: {ex.Message}");
                            goto SetEmail;
                        }
                    Password:
                        try
                        {
                            SetPasswordInput(ref password);
                            User user = new User(email, password, fullName);
                            resultPassword = user.PasswordChecker(password);
                            if (resultPassword==false)
                                goto Password;
                            Array.Resize(ref users, users.Length + 1);
                            users[users.Length - 1] = user;
                            Console.WriteLine("Accoun Created");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Unexpected error: {ex.Message}");
                            goto Password;
                        }
                        break;
                    case 2:
                        foreach (User us in users)
                        {
                            us.ShowInfo();
                        }
                        Console.WriteLine($"-----------------------------------\n----------------------------------");
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
            } while (choice != 0);
        }
        static void SetFullNameInput(ref string fullname)
        {
            Console.Write("Enter Name and Surname:");
            fullname = Console.ReadLine().Trim();
        }
        static void SetEmailInput(ref string email)
        {

            Console.Write("Enter email: ");
            email = Console.ReadLine().Trim();
        }
        static void SetPasswordInput(ref string password)
        {
            Console.Write("Enter password: ");
            password = Console.ReadLine();
        }
        static void CheckPasswordResult(bool result)
        {
            if (result==false)
                Console.WriteLine($"- Password minimum must be 8 character\nPassword must be contain minimum 1 upper character\nPassword must be conatin minumum 1 lower character\nPasswor must be contain minumum 1 number\n1Special character");
        }
        static void CheckEmailResult(bool result)
        {
            if (result == false)
                Console.WriteLine("Wrong email format.");
        }

    }
}
