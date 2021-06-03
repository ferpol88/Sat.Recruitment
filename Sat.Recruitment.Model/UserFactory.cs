using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sat.Recruitment.Model.DTO;

namespace Sat.Recruitment.Model
{
    public class UserFactory : IUserFactory
    {
        private readonly Dictionary<String, Func<UserDTO ,User>> users;
        public UserFactory() {
            users = new Dictionary<String, Func<UserDTO, User>>();

        }
        public User createUser(UserDTO user) => users[user.UserType](user);
        

        private void registerUser(String userType, Func<UserDTO, User> factoryMethod) {
            if (String.IsNullOrEmpty(userType)) return;
            if (factoryMethod is null) return;

            users[userType] = factoryMethod;

        }
        public String[] RegisteredTypes => users.Keys.ToArray();

        public void Initialize()
        {
            registerUser("super", (user) => new SuperUser(user));
            registerUser("normal", (user) => new NormalUser(user));
            registerUser("premium", (user) => new PremiumUser(user));
        }
    }
}
