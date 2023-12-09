using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L6
{
    public class CustomerRepository : RepositoryBase
    {
        public override List<Customer> Customers { get; set; }

        public CustomerRepository() {
            Customers = new List<Customer>();
        }

        public void Add(Customer customer)
        {
            this.Customers.Add(customer);
        }

    }
}
