using Sat.Recruitment.Infrastructure.Model;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.IRepository
{
    public interface IUserRepository
    {
        List<User> GetUsersFromFile();
    }
}