namespace SdetBootcampDay2.TestObjects.Examples.SRP_After
{
    public class InvoicePersister
    {
        private readonly Invoice _invoice;

        public InvoicePersister(Invoice invoice)
        {
            _invoice = invoice;
        }

        public void SaveInvoice()
        {
            // Some logic here that saves the invoice to a store (file, database, whatever)
        }
    }
}
