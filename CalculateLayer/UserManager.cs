using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateLayer
{
    public class UserManager
    {
        public string GetFullName(string name, string family)
        {
            return $"{name} {family}";
        }
    }
}
