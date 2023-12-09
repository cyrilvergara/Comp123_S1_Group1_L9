using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L6
{
    internal static class IdGenerator
    {
        private static ulong customerId = 0;
        private static uint orderId = 0;

        internal static ulong GetNextCustomerId()
        {
            return ++customerId;
        }

        internal static uint GetNextOrderId()
        {
            return ++orderId;
        }
    }
}
