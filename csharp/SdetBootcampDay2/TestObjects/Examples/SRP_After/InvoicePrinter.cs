namespace SdetBootcampDay2.TestObjects.Examples.SRP_After
{
    public class InvoicePrinter
    {
        private readonly Invoice _invoice;

        public InvoicePrinter(Invoice invoice)
        {
            _invoice = invoice;
        }

        public void Print()
        {
            Console.WriteLine($"Number of items : {_invoice._numberOfItems}");
            Console.WriteLine($"Price per item  : {_invoice._pricePerItem}");
            Console.WriteLine($"Total before tax: {_invoice._pricePerItem * _invoice._pricePerItem}");
            Console.WriteLine($"Tax             : {_invoice._pricePerItem}");
            Console.WriteLine($"Total after tax : {_invoice.CalculateTotal()}");
        }
    }
}
