namespace _014_Events
{
    // Event enable a class or object to notify other classes or objects when something of interest occurs

    internal class Program // subscriber
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Event!");
            var stock = new Stock("Mhd");
            stock.Price = 100;
            stock.OnPriceHander += Stock_OnPriceHander;

            //Console.WriteLine("Before:" + stock.Price);
            //Console.WriteLine("After:" + stock.Price);

            stock.ChangePrice(100);
            stock.OnPriceHander -= Stock_OnPriceHander; // unsubscribe

            stock.ChangePrice(-100);
            Console.ReadKey();
        }

        private static void Stock_OnPriceHander(Stock stock, decimal oldPrice)
        {
            if (stock.Price > oldPrice)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (stock.Price < oldPrice)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }


            Console.WriteLine("Stock_OnPriceHander  : " + stock.Price);


        }
    }
    public delegate void ChangeStockPriceHandler(Stock stock, decimal price);
    public class Stock // publisher 
    {
        private string name;
        private decimal price;

        public event ChangeStockPriceHandler OnPriceHander;

        public string Name => this.name;
        public decimal Price { get => this.price; set => this.price = value; }

        public Stock(string stockName)
        {
            this.name = stockName;
        }

        public void ChangePrice(decimal price)
        {
            decimal oldPrice = this.price;
            this.price += price;
            if (OnPriceHander != null) // make sure if has subscriber 
            {
                OnPriceHander(this, oldPrice);
            }
        }

    }
}