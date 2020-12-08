using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models
{
    public class CompanyField: BaseField
    {
        public CompanyField(string title, int rentCost, int cost, int rentIncome)
            : base(title, rentCost, cost, rentIncome)
        {
        }

        public override bool SetOwner(Player player)
        {
            if (Owner == null)
            {
                Owner = player;
                return true;
            }

            return false;
        }
    }
}
