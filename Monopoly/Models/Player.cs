namespace Monopoly.Models
{
    public class Player : System.IEquatable<Player>
    {
        public string Name { get; }
        public int Money { get; private set; }

        public Player(string name, int startMoney)
        {
            Name = name;
            Money = startMoney;
        }

        public void ChangeMoney(int money)
        {
            Money += money;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Player);
        }

        public bool Equals(Player other)
        {
            return other != null && other.Money == this.Money && other.Name == this.Name;
        }
    }
}
