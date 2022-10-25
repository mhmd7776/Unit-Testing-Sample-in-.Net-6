using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateLayer
{
    public class UserManager
    {
        public int UserDiscount { get; set; } = 10;

        public int UserScore { get; set; } = 0;

        public string GetFullName(string name, string family)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required");
            }

            return $"{name} {family}";
        }

        public void UpdateUserDiscount(int value)
        {
            UserDiscount = value;
        }

        public string SayHello(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return $"Hello, {name}";
        }

        public User CheckUserType()
        {
            if (UserScore >= 100) return new VipUser();

            return new NormalUser();
        }
    }

    public class User
    {

    }

    public class NormalUser : User
    {

    }

    public class VipUser : User
    {

    }
}
