using Comp123_S1_Group1_L6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L9
{
    /*
     * MaxmillianA_301325202
     */
    public class CustomerUpdatedEventArgs
    {
        /*
         * MaxmillianA_301325202
         */
        public Customer UpdatedCustomer { get; }

        /*
         * MaxmillianA_301325202
         */
        public CustomerUpdatedEventArgs(Customer updatedCustomer)
        {
            UpdatedCustomer = updatedCustomer;
        }
    }
}
