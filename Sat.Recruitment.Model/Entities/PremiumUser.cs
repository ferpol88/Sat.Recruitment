using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sat.Recruitment.Model.DTO;

namespace Sat.Recruitment.Model
{
    public class PremiumUser : User
    {
        public PremiumUser(UserDTO user)
        {
            Name = user.Name;
            Email = user.Email;
            Address = user.Address;
            Phone = user.Phone;
            Money = user.Money;
            UserType = user.UserType;
            CalculateMoney();
        }

        public override void CalculateMoney()
        {
            if (Money > 100) Money += Money * 2;
        }

    }
}
