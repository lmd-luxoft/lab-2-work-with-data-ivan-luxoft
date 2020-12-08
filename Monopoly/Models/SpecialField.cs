using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models
{
    public class SpecialField : BaseField
    {
        public override bool ShouldPayRentCost => true;

        public SpecialField(string title, int rent)
            : base(title, rent, 0, 0)
        {
        }

        public override bool SetOwner(Player player)
        {
            return false;
        }
    }
}
