using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L6
{
    public abstract class MenuItemAddition : MenuItem, IMenuItem
    {
        
        private IMenuItem menuItem;

        public MenuItemAddition(IMenuItem menuItem)
        {
            this.menuItem = menuItem;
        }

        public override string Description
        {
            get {
                if (menuItem == null)
                {
                    return base.Description;
                }
                else
                {
                    return $"{menuItem.Description}, {base.Description}";
                }

            }
            set { base.Description = value; }
        }

        public override decimal BaseCost
        {
            get {
                if (menuItem == null)
                {
                    return base.BaseCost;
                }
                else
                {
                    return base.BaseCost + menuItem.BaseCost;
                }
            }
            set { base.BaseCost = value; }
        }

    }
}
