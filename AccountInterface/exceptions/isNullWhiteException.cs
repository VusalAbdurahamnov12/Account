using System;
using System.Collections.Generic;
using System.Text;

namespace AccountInterface.exceptions
{
    public class isNullWhiteException:Exception
    {
        public isNullWhiteException(string msg) : base(msg) { }
    }
}
