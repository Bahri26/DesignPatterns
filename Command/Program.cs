using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        //Bir komutu nesne olarak tanımlanır.
        //İstek nesnesi
        //Yöntemi çağıran ve yöntemi yürüten nesneler ayrılıyor.
        //Genişletilebilir
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);

            StockController stockController = new StockController();
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            stockController.TakeOrder(buyStock);

            stockController.PlayOrders();
            Console.ReadLine();
        }
    }

    class StockManager
    {
        private string _name = "Laptop";
        private int _quatity=10;

        public void Buy()
        {
            Console.WriteLine("Stock : {0},{1} bought", _name, _quatity);
        }

        public void Sell()
        {
            Console.WriteLine("Stock : {0},{1} bought", _name, _quatity);
        }

    }

    interface IOrder
    {
        void Execute();
    }

    class BuyStock : IOrder
    {
        private StockManager _stockManager;

        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
            _stockManager.Buy();
        }
    }

    class SellStock : IOrder
    {
        private StockManager _stockManager;

        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }
        public void Execute()
        {
            _stockManager.Sell();
        }
    }

    class StockController
    {
        List<IOrder> _orders = new List<IOrder>();
        
        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void PlayOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }

            _orders.Clear();
        }
    }
}
