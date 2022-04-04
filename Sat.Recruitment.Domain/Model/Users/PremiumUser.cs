using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Api.Domain.Model
{
    public class PremiumUser : User
    {
        decimal _money = 0;

        public override string UserType { get => "Premium";}

        public override decimal Money
        { 
            get => (_money > 100 ? _money * (decimal)2 : _money); 
            set => _money = value;
        }
    }
}
