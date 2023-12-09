using Comp123_S1_Group1_L6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L9
{
    /*
     * CyHong_301324609
     */
    public class CustomerAddedEventArgs
    {

        /*
         * CyHong_301324609
         */
        public Customer NewCustomer { get; }

        /*
         * CyHong_301324609
         */
        public CustomerAddedEventArgs(Customer newCustomer)
        {
            NewCustomer = newCustomer;
        }
    }
}
