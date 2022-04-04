using System;
using System.Collections.Generic;
using System.Linq;

using Sat.Recruitment.Api.Domain.Model;
using Sat.Recruitment.Api.Repository;

namespace Sat.Recruitment.Api.Domain.Helpers
{
    public class UserHelper
    {
        List<IUser> _users;

        public UserHelper()
        {
            UserRepository repo = new UserRepository();
            var _users = repo.GetUsersFromFile();
            this._users = (from u in _users
                           select CreateUser(
                                        u.Name,
                                        u.Email,
                                        u.Address,
                                        u.Phone,
                                        u.UserType,
                                        u.Money))
                          .ToList();
        }

        /// <summary>
        /// Verify if user already exists
        /// </summary>
        /// <param name="user">User to verify</param>
        /// <returns></returns>
        public bool IsDuplicated(IUser user)
        {
            var auxUser = (from User u in _users
                           where (u.Email == user.Email || u.Phone == user.Phone)
                                  || (u.Name == user.Name && u.Address == user.Address)
                           select u).FirstOrDefault();
            
            return (auxUser != null);
        }
        
        /// <summary>
        /// Creates the user type
        /// </summary>
        /// <param name="name">User name</param>
        /// <param name="email">User email</param>
        /// <param name="address">User address</param>
        /// <param name="phone">User phone</param>
        /// <param name="userType">User type: Normal, SuperUser, Premium</param>
        /// <param name="money">User money</param>
        /// <returns></returns>
        public IUser CreateUser(string name, string email, string address, string phone, string userType, decimal money)
        {
            IUser user = null;
            switch (userType.ToLower())
            {
                case "normal":
                    user = new NormalUser();
                    break;

                case "superuser":
                    user = new SuperUser();
                    break;

                case "premium":
                    user = new PremiumUser();
                    break;

                default:
                    user = new NormalUser();
                    break;
            }
            user.Name = name;
            user.Email = email; 
            user.Address = address;
            user.Phone = phone;
            user.Money = money;
            
            return user;
        }
    }
}
