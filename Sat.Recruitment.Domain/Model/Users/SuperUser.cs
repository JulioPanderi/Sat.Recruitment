using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Api.Domain.Model
{
    public class SuperUser : User
    {
        const decimal percentage = (decimal)0.20;
        decimal _money = 0;

        public override string UserType { get => "SuperUser"; }
        public override decimal Money
        { 
            get => (_money > 100 ? _money * (1 + percentage): _money);  
            set => _money = value;
        }
    }
}
