using AccountInterface.exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AccountInterface.Models
{
    internal class User : IAccount
    {
        private static int _id;
        private string _password;
        private string _fullName;
        private string _email;
        public int Id { get; }


        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (!String.IsNullOrEmpty(value)==true)_fullName = value;
            }

        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (EmailChecker(value)) _email = value;
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (PasswordChecker(value)==true) _password = value;
            }
        }


        public bool PasswordChecker(string password)
        {
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            Match match = regex.Match(password);
            if (match.Success)return true;
            else return false;
        }
        public User(string email, string password, string fullName) : this(email, password)
        {
            FullName = fullName;
        }

        public User(string email, string password)
        {
            Email = email;
            this.Password = password;
        }

        public static bool EmailChecker(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success) return true;
            else return false;
        }
        public static bool CheckFullName(ref string fullName)
        {
            if (String.IsNullOrEmpty(fullName)) throw new isNullWhiteException("You must enter fullname");
            else return true;
        }

        public static bool CheckFullnameCompitable(ref string fullName)
        {

            Regex regex = new Regex(@"(^[A-Za-z]{3,16})([ ]{0,1})([A-Za-z]{3,16})?([ ]{0,1})?([A-Za-z]{3,16})?([ ]{0,1})?([A-Za-z]{3,16})");
            Match match = regex.Match(fullName);
            if (match.Success)
            {
                ++_id;
                //Id = _id; duzeltmek lazim!!!
                return true;
            }
            else return false ;
            throw new isNullWhiteException("You must enter fullname");
        }
        public bool FullNameChecker(string email)
        {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"User Id - {Id}\nName Surname- {FullName}\nEmail - {Email}");
        }
    }
}
