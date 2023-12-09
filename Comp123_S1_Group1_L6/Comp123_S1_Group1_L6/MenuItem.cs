using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Comp123_S1_Group1_L6
{
    public abstract class MenuItem : IMenuItem
    {
        [JsonProperty]
        protected string description;

        [JsonProperty]
        protected decimal baseCost;

        public MenuItem() { }

        public MenuItem(string description, decimal baseCost)
        {
            this.BaseCost = baseCost;
            this.Description = description;
        }

        public virtual string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public virtual decimal BaseCost
        {
            get { return baseCost; }
            set { baseCost = value; }
        }

        public override string ToString()
        {
            // To adapt to the formatting in the output
            string _baseCost = (this is MenuItemAddition) ? $"{BaseCost:0.00}" : $"{BaseCost:0.##}";
            return $"Menu item: Description: {Description}\n\tBase cost: {_baseCost}";
        }
    }
}
