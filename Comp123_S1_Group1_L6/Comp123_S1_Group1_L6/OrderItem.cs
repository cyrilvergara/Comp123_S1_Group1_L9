using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L6
{
    public class OrderItem
    {
        private IMenuItem item;

        public decimal Cost { get; set; }
        public IMenuItem Item { 
            get { return item; }
            set { item = value; }
        }

        public OrderItem() { }
        public OrderItem(IMenuItem item)
        {
            Item = item;
            Cost = item.BaseCost;
        }

        public override string ToString()
        {
            return $"{Item.Description} - {Cost.ToString("C2")}";
        }
    }
}
