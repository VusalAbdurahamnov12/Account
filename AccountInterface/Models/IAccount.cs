using System;
using System.Collections.Generic;
using System.Text;

namespace AccountInterface.Models
{
    interface  IAccount
    {
        bool PasswordChecker(string password);
        void ShowInfo();
    }
}
