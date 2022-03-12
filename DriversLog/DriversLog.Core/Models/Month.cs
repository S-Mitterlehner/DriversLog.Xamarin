namespace DriversLog.Core.Models
{
    public class Month
    {
        public int Number { get; }
        public string Name { get; }

        public Month(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public static bool operator ==(Month left, Month right) => left.Number == right.Number;
        public static bool operator ==(int left, Month right) => left == right.Number;
        public static bool operator ==(Month left, int right) => left.Number == right;

        public static bool operator !=(Month left, Month right) => left.Number != right.Number;
        public static bool operator !=(int left, Month right) => left != right.Number;
        public static bool operator !=(Month left, int right) => left.Number != right;
    }
}