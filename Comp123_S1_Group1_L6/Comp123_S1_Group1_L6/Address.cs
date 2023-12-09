using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L6
{
    public struct Address
    {
        // Word: "2King St., Toronto, ON, M1M 1M1"
        // Output: "1 King St, Toronto, ON M1M 1M1"
        public static Address SHOP_ADDRESS = new Address("1 King St", "Toronto", "ON", "M1M 1M1");

        public string City;
        public string PostalCode;
        public string Province;
        public string Street;

        public Address(string street, string city, string province, string postalCode)
        {
            this.Street = street;
            this.City = city;
            this.Province = province;
            this.PostalCode = postalCode;     
        }

        public override string ToString()
        {
            return $"Address: {Street}, {City}, {Province} {PostalCode}";
        }
    }
}
