using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L6
{
    public interface IMenuItem
    {
        string Description { get; set; }
        decimal BaseCost { get; set; }
    }
}
