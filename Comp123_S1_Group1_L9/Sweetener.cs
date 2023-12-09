using Comp123_S1_Group1_L6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L9
{
    internal class Sweetener : MenuItemAddition
    {
        /**
         * HongChitC_301366112
         */
        public Sweetener(IMenuItem menuItem) : base(menuItem) 
        {
            Description = "Sweetener";
            BaseCost = 0.06M;
        }
    }
}
