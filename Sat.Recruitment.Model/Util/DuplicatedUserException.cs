using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Model.Util
{
    public class DuplicatedUserException : Exception
    {
        private const string Error = "The user is duplicated";
        public override string ToString()
        {
            return Error;
        }
    }

}