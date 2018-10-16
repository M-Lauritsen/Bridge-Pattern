using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_Pattern
{
    class Program
    {
        public interface IOrderingSystem
        {
            void Place(string order);
        }

        public abstract class SendOrder
        {
            public IOrderingSystem _restaurant;

            public abstract void Send();
        }

        public class SendDairyFreeOrder : SendOrder
        {
            public override void Send()
            {
                _restaurant.Place("Dairy-Free Order");
            }
        }

        public class SendGlutenFreeOrder : SendOrder
        {
            public override void Send()
            {
                _restaurant.Place("Gluten-Free Order");
            }
        }

        public class DinerOrders : IOrderingSystem
        {
            public void Place(string order)
            {
                Console.WriteLine("Placing order for " + order + " at the Diner.");
            }
        }

        public class FancyRestaurantOrders : IOrderingSystem
        {
            public void Place (string order)
            {
                Console.WriteLine("Placing order for " + order + " at the Fancy Restaurant.");
            }
        }

        static void Main(string[] args)
        {
            SendOrder _sendOrder = new SendDairyFreeOrder();
            _sendOrder._restaurant = new DinerOrders();
            _sendOrder.Send();

            _sendOrder._restaurant = new FancyRestaurantOrders();
            _sendOrder.Send();

            _sendOrder = new SendGlutenFreeOrder();
            _sendOrder._restaurant = new DinerOrders();
            _sendOrder.Send();

            _sendOrder._restaurant = new FancyRestaurantOrders();
            _sendOrder.Send();

            Console.ReadKey();
        }
    }
}
