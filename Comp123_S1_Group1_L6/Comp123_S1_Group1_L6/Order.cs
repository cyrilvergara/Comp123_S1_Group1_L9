using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L6
{
    public enum OrderType
    {
        PhoneOrder,
        RestaurantOrder
    }
    public class Order
    {
        private decimal cost;
        private Customer customer;
        private bool delivered;
        private Address deliveryAddress;
        private DateTime deliveryTime;
        private List<OrderItem> items;
        private uint orderId;
        private DateTime orderTime;
        private OrderType orderType;

        public decimal Cost { 
            get { return cost; } 
            set { cost = value; } 
        }

        [JsonIgnore]
        public Customer Customer { 
            get { return customer; }
            set { 
                if (customer == null)
                {
                    customer = value;
                } else if (customer != value)
                {
                    // throw new ArgumentException("Something went wrong! Customer cannot be changed once assigned");
                    Console.WriteLine("Something went wrong! Customer cannot be changed once assigned");
                }
            }
        }
        public bool Delivered { 
            get { return delivered; }
            set { 
                if (value)
                {
                    DeliveryTime = DateTime.Now;
                } else
                {
                    DeliveryTime = DateTime.MinValue;
                }
                delivered = value;
            }
        }
        public Address DeliveryAddress { 
            get { return deliveryAddress; }
            set { deliveryAddress = value; }
        }
        public DateTime DeliveryTime { 
            get { return deliveryTime; }
            set { deliveryTime = value; }
        }
        public List<OrderItem> Items { 
            get { return items; }
            set { items = value; }
        }
        public uint OrderId { 
            get { return orderId; }
            set { orderId = value; }
        }
        public DateTime OrderTime { 
            get { return orderTime; } 
            set { orderTime = value; }
        }
        public OrderType OrderType { 
            get { return orderType; } 
            set { orderType = value; }
        }

        public Order()
        {
            this.items = new List<OrderItem>();
            this.orderId = IdGenerator.GetNextOrderId();
            OrderType = OrderType.RestaurantOrder;
            Delivered = true;
            // Word: "1King St., Toronto, ON, M1M 1M1"
            // Output: "1 King St, Toronto, ON M1M 1M1"
            DeliveryAddress = new Address("1 King St", "Toronto", "ON", "M1M 1M1");
            this.OrderTime = DateTime.Now;
        }

        public Order(Customer customer, OrderType orderType, Address deliveryAddress)
        {
            this.items = new List<OrderItem>();
            this.orderId = IdGenerator.GetNextOrderId();
            Customer = customer;
            OrderType = orderType;
            DeliveryAddress = deliveryAddress;
            if (orderType == OrderType.PhoneOrder)
            {
                Delivered = false;
            }
            this.OrderTime = DateTime.Now;
        }

        public void AddOrderItem(IMenuItem menuItem)
        {
            OrderItem orderitem = new OrderItem(menuItem);
            this.items.Add(orderitem);
            Cost += orderitem.Cost;
        }

        public void Deliver()
        {
            DeliveryTime = DateTime.Now;
            Delivered = true;
        }

        public override string ToString()
        {
            string _items = String.Empty;
            foreach (OrderItem item in this.items)
            {
                _items = $"{_items}\t\t{item}\n";
            }
            string _customerName = String.Empty;
            if (Customer != null) { _customerName = Customer.Name; }
            return $"Order: Id:{OrderId}\n\tCustomer name: {_customerName}\n\tOrder time: {OrderTime.ToString("t")}\n\tCost: {Cost.ToString("C2")}\n\tDelivery address: {DeliveryAddress}\n\t{_items}";
        }
    }
}
