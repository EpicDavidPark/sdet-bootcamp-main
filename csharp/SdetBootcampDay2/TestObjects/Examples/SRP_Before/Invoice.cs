namespace SdetBootcampDay2.TestObjects.Examples.SRP_Before
{
    public class Invoice
    {
        private readonly int _numberOfItems;
        private readonly double _pricePerItem;
        private readonly double _tax;

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

        public void PrintInvoice()
        {
            Console.WriteLine($"Number of items : {_numberOfItems}");
            Console.WriteLine($"Price per item  : {_pricePerItem}");
            Console.WriteLine($"Total before tax: {_numberOfItems * _pricePerItem}");
            Console.WriteLine($"Tax             : {_tax}");
            Console.WriteLine($"Total after tax : {CalculateTotal()}");
        }

        public void SaveInvoice()
        {
            // Some logic here that saves the invoice to a store (file, database, whatever)
        }
    }
}
