using Comp123_S1_Group1_L6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L9
{
    internal class Mayo : MenuItemAddition
    {
        /**
         * HongChitC_301366112
         */
        public Mayo(IMenuItem menuItem) : base(menuItem)
        {
            Description = "Mayo";
            BaseCost = 0.00M;
        }
    }
}
