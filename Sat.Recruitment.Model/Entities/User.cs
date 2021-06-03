using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Model
{
    public abstract class User
    {
             public string Name { get; protected set; }
             public string Email { get; protected set; }
             public string Address { get; protected set; }
             public string Phone { get; protected set; }
             public string UserType { get; protected set; }
             public decimal Money { get; protected set; }

        public abstract void CalculateMoney();
    }
}
