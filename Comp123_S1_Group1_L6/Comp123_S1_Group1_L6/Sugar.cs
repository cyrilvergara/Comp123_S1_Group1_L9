using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L6
{
    public class Sugar : MenuItemAddition
    {
        public Sugar(IMenuItem menuItem) : base(menuItem)
        {
            Description = "Sugar";
            BaseCost = 0.05M;
        }
    }
}
