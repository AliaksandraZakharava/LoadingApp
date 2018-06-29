using LoadingApp.Data;

namespace LoadingApp.MathLib.Logic.Models
{
    public class BoxQuantityPair
    {
        public Box Box { get; set; }

        public int Quantity { get; set; }

        public BoxQuantityPair(Box box = null, int quantity = 0)
        {
            Box = box ?? new Box();
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Box quantity pair '{Box}': {Quantity}";
        }
    }
}
