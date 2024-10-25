namespace SdetBootcampDay2.TestObjects.Examples.SRP_After
{
    public class Invoice
    {
        public int _numberOfItems { get; init; }
        public double _pricePerItem { get; init; }
        public double _tax { get; init; }

        public Invoice(int numberOfItems, double pricePerItem, double tax)
        {
            _numberOfItems = numberOfItems;
            _pricePerItem = pricePerItem;
            _tax = tax;
        }

        public double CalculateTotal()
        {
            return _numberOfItems * _pricePerItem + _tax;
        }
    }
}
