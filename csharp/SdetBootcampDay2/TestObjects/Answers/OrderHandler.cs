namespace SdetBootcampDay2.TestObjects.Answers
{
    public class OrderHandler
    {
        private IDictionary<OrderItem, int>? stock = new Dictionary<OrderItem, int>();
        private readonly PaymentProcessor paymentProcessor;

        /**
         * TODO: can you apply Dependency Inversion here to make this code more flexible,
         * allowing users to inject the stock, and thereby make the code easier to test?
         * Do the same for the PaymentProcessor. You do not need to create interfaces as
         * was shown in the example (although if you want to, be my guest!)
         * After you have done that, update the existing tests and add the tests that were
         * not possible before.
         */
        public OrderHandler(Dictionary<OrderItem, int> stock, PaymentProcessor paymentProcessor)
        {
            this.stock = stock;
            this.paymentProcessor = paymentProcessor;
        }

        /**
         * TODO: this method clearly violates the Single Responsibility Principle
         * Can you refactor the code to resolve that? Don't forget to also update the tests.
         */
        public void Order(OrderItem item, int quantity)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            if (this.stock[item] < quantity)
            {
                throw new ArgumentException($"Insufficient stock for item {item}");
            }

            this.stock[item] -= quantity;
        }

        public bool PayFor(OrderItem item, int quantity)
        {
            return this.paymentProcessor.PayFor(item, quantity);
        }

        public void AddStock(OrderItem item, int quantity)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            this.stock[item] += quantity;
        }

        public int GetStockFor(OrderItem item)
        {
            if (!this.stock!.TryGetValue(item, out int result))
            {
                throw new ArgumentException($"Unknown item {item}");
            }

            return this.stock[item]; 
        }
    }
}
