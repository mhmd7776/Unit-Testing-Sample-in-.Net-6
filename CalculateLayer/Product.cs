using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateLayer
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public double Price { get; set; }

        public string GetProductPrice(UserManager userManager)
        {
            if (userManager.UserDiscount > 0)
            {
                return (Price * (100 - userManager.UserDiscount) / 100).ToString("C");
            }

            return Price.ToString("C");
        }
    }
}
