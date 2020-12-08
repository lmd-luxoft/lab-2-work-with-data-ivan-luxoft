using System;

namespace Monopoly.Models
{
    public abstract class BaseField : IEquatable<BaseField>
    {
        public string Title { get; }
        public Player Owner { get; protected set; }
        public virtual bool ShouldPayRentCost => Owner != null;
        public int RentCost { get; private set; }
        public int RentIncome { get; private set; }
        public int Cost { get; private set; }

        public BaseField(string title, int rentCost, int cost, int rentIncome)
        {
            Title = title;
            RentCost = -1 * rentCost;
            Cost = -1 * cost;
            RentIncome = rentIncome;
        }

        public abstract bool SetOwner(Player player);

        public override bool Equals(object obj)
        {
            return this.Equals(obj as BaseField);
        }

        public bool Equals(BaseField other)
        {
            return other != null
                && this.Cost == other.Cost
                && this.Owner == other.Owner
                && this.RentCost == other.RentCost
                && this.RentIncome == other.RentIncome
                && this.Title == other.Title;
        }
    }
}
