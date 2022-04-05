using Sat.Recruitment.Api.Domain.Model;
using System;

namespace Sat.Recruitment.Api.Domain.IHelpers
{
    public interface IUserHelper : IDisposable
    {
        IUser CreateUser(string name, string email, string address, string phone, string userType, decimal money);
        bool IsDuplicated(IUser user);
    }
}