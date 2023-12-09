using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L6
{
    public class Milk : MenuItemAddition
    {
        public Milk(IMenuItem menuItem) : base(menuItem)
        {
            Description = "Milk";
            BaseCost = 0.10M;
        }
    }
}
