using System.Collections.Generic;
using System.Xml.Linq;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Users
{
    [AutoRegister]
    public class UpdateUserService : IUpdateUserService
    {

        private readonly IUserRepository _userRepository;
        public UpdateUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public void Update(User user, string name, string email, UserTypes type, decimal? annualSalary, IEnumerable<string> tags, int? age)
        {
            user.SetEmail(email);
            user.SetName(name);
            user.SetType(type);
            if (annualSalary.HasValue)
            {
                user.SetMonthlySalary(annualSalary.Value / 12);
            }
            else
            {
                user.SetMonthlySalary(null);
            }

            user.SetTags(tags);
            user.SetAge(age);
          
        }



    }
}