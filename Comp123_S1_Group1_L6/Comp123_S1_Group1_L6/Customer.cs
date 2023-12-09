using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp123_S1_Group1_L6
{
    public class Customer
    {
        private Address address;
        private ulong idNumber;
        private string name;
        private List<Order> orders;
        private uint phone;

        public Customer()
        {
            this.orders = new List<Order>();
            this.idNumber = IdGenerator.GetNextCustomerId();
        }
        public Customer(string name, uint phoneNumber, Address address) : this()
        {
            Name = name;
            Phone = phoneNumber;
            Address = address;
        }

        public Address Address { 
            get { return address; }
            set { this.address = value; }
        }

        public ulong IdNumber { 
            get { return idNumber; }
            set { idNumber = value; }
        }

        public string Name { 
            get { return name; }
            set {
                if (value != null && value != "")
                {
                    this.name = value;
                } else
                {
                    throw new ArgumentException("Name cannot be empty");
                }
            }
        }

        public List<Order> Orders { 
            get { return orders; }
            set
            {
                if (value != null)
                {
                    this.orders = value;
                }
                else
                {
                    throw new ArgumentNullException("Orders cannot be null");
                }
            }
        }

        public uint Phone { 
            get { return phone; }
            set { this.phone = value; }
        }

        // Create a new order for this customer
        public Order AddOrder(Order order)
        {
            order.Customer = this;
            this.orders.Add(order);
            return order;
        }

        public Order CreatePhoneOrder(Address deliveryAddress)
        {
            Order order = new Order(this, OrderType.PhoneOrder, deliveryAddress);
            this.orders.Add(order);
            return order;
        }

        public override string ToString()
        {
            string _items = String.Empty;
            foreach(Order order in this.orders)
            {
                _items = $"{_items}\t{order}\n";
            }
            return $"Customer: Id:{IdNumber},  Name:{Name},\n\tAddress: {Address}, Phone: {Phone}\n\tOrders: \n{_items}";
        }
    }
}
