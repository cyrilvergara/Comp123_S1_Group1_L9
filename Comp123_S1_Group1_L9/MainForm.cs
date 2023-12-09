using Comp123_S1_Group1_L6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comp123_S1_Group1_L9 //CyrilV_301324609_A9 Group1
{
    public partial class MainForm : Form
    {
        private const string FILE_NAME = "..\\..\\..\\RestaurantData.json";
        private readonly Customer restaurant = new Customer("Restaurant", 0, Address.SHOP_ADDRESS);

        /*
         * CyrilV_301324609
         */
        // Use the same instance of CustomerRepository throughout
        private readonly CustomerRepository customerRepository = new CustomerRepository();

        /*
         * CyrilV_301324609
         */
        // Property to hold CustomerRepository
        public CustomerRepository CustomerRepository
        {
            get { return customerRepository; }
        }

        /*
         * MaxmillianA_301325202
         */
        private Customer selectedCustomer;

        /*
         * CyrilV_301324609
         */
        public MainForm()
        {
            InitializeComponent();


            InitData();

            UpdateCustomerList();
        }

        /**
         * HongChitC_301366112
         */
        private void InitData()
        {
            try
            {
                customerRepository.Load(FILE_NAME);
            } 
            catch (IOException e)
            {
                MessageBox.Show("Data file not found.", "Information", MessageBoxButtons.OK);
            }

            if (customerRepository.Customers.Count == 0) {
                // Adding sample customers to the repository
                Customer johnSmith = new Customer("John Smith", 4161234567, new Address("35 Elm St", "Toronto", "ON", "M2M 2K5"));
                Customer annBrown = new Customer("Ann Brown", 4169876543, new Address("35 Queen St", "Toronto", "ON", "M2T 1M1"));
                Customer johnDow = new Customer("John Dow", 0, new Address("", "Toronto", "ON", ""));

                //customerRepository.Add(restaurant);
                customerRepository.Add(johnSmith);
                customerRepository.Add(annBrown);
                customerRepository.Add(johnDow);
            }

            if (!isRestaurant(customerRepository.Customers[0]))
            {
                customerRepository.Customers.Insert(0, restaurant);
            }
            btnEditCustomer.Enabled = false;
            btnAddOrder.Enabled = false;
            this.Text = restaurant.Name;
        }

        /**
         * HongChitC_301366112
         */
        private bool isRestaurant(Customer customer)
        {
            return restaurant.Name.Equals(customer.Name);
        }

        /**
         * HongChitC_301366112
         */
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                customerRepository.Save(FILE_NAME);
                MessageBox.Show("Data saved to file successfully.", "Information", MessageBoxButtons.OK);
            }
            catch (IOException ioe)
            {
                MessageBox.Show("Failed to save data.", "Error", MessageBoxButtons.OK);
            }
        }

        /*
         * Donalda 301367408
         */
        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            //int customerIndex = lbx_AllCustomers.SelectedIndex;

            //if (customerIndex == -1)
            //{
            //    MessageBox.Show("Course must be selected", "Error", MessageBoxButtons.OK);
            //    return;
            //}

            OrderType orderType = (isRestaurant(selectedCustomer))? OrderType.RestaurantOrder : OrderType.PhoneOrder;
            OrderForm orderForm = new OrderForm(selectedCustomer, orderType);
            DialogResult result = orderForm.ShowDialog();

            // OrderForm.order 

            // Order order = OrderForm.Order;

            if (result == DialogResult.OK)
            {
                DisplayCustomerDetails(selectedCustomer);
                //MessageBox.Show("Order successfully submitted.", "Order Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show("Cannot submit an empty order.", "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * CyrilV_301324609
         */
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            using (var customerForm = new CustomerForm(CustomerRepository))
            {
                // Subscribe to the CustomerAdded event
                customerForm.CustomerAdded += CustomerForm_CustomerAdded;
                customerForm.Text = "Add Customer";

                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    // Customer was added successfully, update the list
                    UpdateCustomerList();
                }
            }

        }

        /*
         * CyrilV_301324609
         */
        // Event handler for the CustomerAdded event
        private void CustomerForm_CustomerAdded(object sender, CustomerAddedEventArgs e)
        {
            // Update the ListBox with the new customer
            UpdateCustomerList();
        }

        /*
         * CyrilV_301324609
         */
        public void UpdateCustomerList()
        {
            lsbAllCustomers.Items.Clear();
            foreach (Customer customer in customerRepository.Customers)
            {
                lsbAllCustomers.Items.Add(customer.Name);
            }
        }

        /*
         * CyrilV_301324609
         * MaxmillianA_301325202
         */
        private void lsbAddedCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the selection change here
            if (lsbAllCustomers.SelectedIndex != -1)
            {
                string selectedCustomerName = lsbAllCustomers.SelectedItem.ToString();

                selectedCustomer = customerRepository.Customers[lsbAllCustomers.SelectedIndex];
                if (selectedCustomer != null)
                {
                    // lblResult.Text = $"{selectedCustomer}";
                    DisplayCustomerDetails(selectedCustomer);

                    btnEditCustomer.Enabled = !isRestaurant(selectedCustomer);
                    btnAddOrder.Enabled = true;
                }
                else
                {
                    btnEditCustomer.Enabled = false;
                }
            }
            else
            {
                btnEditCustomer.Enabled = false;
            }
        }

        /*
         * MaxmillianA_301325202
         */
        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (lsbAllCustomers.SelectedIndex != -1)
            {
                // Open the EditCustomerForm
                CustomerForm customerForm = new CustomerForm(customerRepository, selectedCustomer);

                // Subscribe to the CustomerUpdated event
                customerForm.CustomerUpdated += EditForm_CustomerUpdated;
                customerForm.Text = $"Update Customer: {selectedCustomer.Name}";

                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    // Update the ListBox
                    UpdateCustomerList();
                }

                // Unsubscribe from the event to avoid memory leaks
                customerForm.CustomerUpdated -= EditForm_CustomerUpdated;
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * MaxmillianA_301325202
         */
        private void EditForm_CustomerUpdated(object sender, CustomerUpdatedEventArgs e)
        {
            // Update the customer list with the edited information
            int index = customerRepository.Customers.IndexOf(selectedCustomer);
            if (index != -1)
            {
                customerRepository.Customers[index] = e.UpdatedCustomer;

                // Update the ListBox
                UpdateCustomerList();

                // Display updated customer details
                DisplayCustomerDetails(e.UpdatedCustomer);
            }
        }

        /*
         * Donalda 301367408
         * MaxmillianA_301325202
         */
        private void DisplayCustomerDetails(Customer customer)
        {

            if (customer != null)
            {
                string details = "";

                // Display customer information
                details += $"[{customer.IdNumber}] {customer.Name}\n";
                details += $"{customer.Address}\n";
                details += $"Phone: {customer.Phone}\n";

                // Display order information
                Order lastOrder = customer.Orders.LastOrDefault();
                if (lastOrder != null)
                {
                    details += $"\nOrder ID: {lastOrder.OrderId}\n";
                    details += $"Order Type: {lastOrder.OrderType}\n";
                    details += $"Order Time: {lastOrder.OrderTime.ToString("h:mm tt")}\n";
                    details += $"Cost: {lastOrder.Cost:C}\n";
                    details += $"Delivery {customer.Address}\n";
                    // Display delivery information
                    details += $"Delivery Time: {lastOrder.DeliveryTime.ToString("h:mm tt")}\n";
                    string delivery = lastOrder.Delivered ? "Delivered" : "Not Delivered";
                    details += $"Delivery Status: {delivery}\n";

                    // Display order items
                    details += "Order Items:\n";
                    foreach (OrderItem orderItem in lastOrder.Items)
                    {
                        details += $"\t - {orderItem.Item.Description} - {orderItem.Cost:C}\n";
                    }
                }

                // Set the text of the TextBox
                lblResult.Text = details;
            }
            else
            {
                // Clear the TextBox if no customer is selected
                lblResult.Text = "";
            }

        }
    }

}
