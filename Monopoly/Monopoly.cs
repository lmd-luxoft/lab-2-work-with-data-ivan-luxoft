using Monopoly.Models;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Monopoly
    {
        private List<Player> players = new List<Player>();
        private List<BaseField> fields = new List<BaseField>();

        private const int startCash = 6000;

        public Monopoly(string[] p, int v)
        {
            for (int i = 0; i < v; i++)
            {
                players.Add(new Player(p[i], startCash));
            }

            fields.Add(new CompanyField("Ford", 250, 500, 250));
            fields.Add(new CompanyField("MCDonald", 250, 250, 250));
            fields.Add(new CompanyField("Lamoda", 100, 100, 1000));
            fields.Add(new CompanyField("Air Baltic", 300, 700, 300));
            fields.Add(new CompanyField("Nordavia", 300, 700, 300));
            fields.Add(new SpecialField("Prison", 1000));
            fields.Add(new CompanyField("MCDonald", 250, 250, 250));
            fields.Add(new CompanyField("TESLA", 250, 500, 250));
        }

        internal IReadOnlyCollection<Player> GetPlayersList()
        {
            return players.AsReadOnly();
        }

        internal IReadOnlyCollection<BaseField> GetFieldsList()
        {
            return fields.AsReadOnly();
        }

        internal BaseField GetFieldByName(string v)
        {
            return (from p in fields where p.Title == v select p).FirstOrDefault();
        }

        internal bool Buy(Player player, BaseField field)
        {
            if (field.SetOwner(player))
            {
                player.ChangeMoney(field.Cost);
                return true;
            }

            return false;
        }

        internal Player GetPlayerInfo(int v)
        {
            return players[v - 1];
        }

        internal bool Renta(Player player, BaseField field)
        {
            if (field.ShouldPayRentCost)
            {
                player.ChangeMoney(field.RentCost);

                if (field.Owner != null)
                {
                    field.Owner.ChangeMoney(field.RentIncome);
                }

                return true;
            }

            return false;
        }
    }
}
