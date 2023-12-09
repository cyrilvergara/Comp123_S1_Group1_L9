using Comp123_S1_Group1_L6;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MenuItem = Comp123_S1_Group1_L6.MenuItem;

namespace Comp123_S1_Group1_L9 //CyrilV_301324609_A9 Group1
{
    /**
     * HongChitC_301366112
     */
    enum MenuType
    {
        Beverage,
        Food
    }


    /**
     * HongChitC_301366112
     */
    public partial class OrderForm : Form
    {
        public Order Order;

        private Customer customer;
        private OrderType orderType;
        private List<IMenuItem> menuItems;
        private Dictionary<IMenuItem, MenuType> menuItemType;
        private Dictionary<MenuType, List<MenuItemAddition>> menuAdditions;
        private List<ComboBox> comboBoxes;

        /**
         * HongChitC_301366112
         */
        public OrderForm(Customer customer, OrderType orderType)
        {
            this.customer = customer;
            this.orderType = orderType;
            InitializeComponent();
            if (orderType == OrderType.RestaurantOrder)
            {
                Order = new Order();
                Order.Customer = customer;
            }
            else
            {
                Order = new Order(customer, orderType, customer.Address);
            }
            this.Text = $"Add Order for {customer.Name}";
        }

        /**
         * HongChitC_301366112
         */
        private void btnOk_Click(object sender, EventArgs e)
        {
            customer.AddOrder(Order);
            DialogResult = DialogResult.OK;
            Close();
        }

        /**
         * HongChitC_301366112
         */
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Order = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /**
         * HongChitC_301366112
         */
        private void InitMenu()
        {
            comboBoxes = new List<ComboBox>();
            comboBoxes.Add(cbxAddition1);
            comboBoxes.Add(cbxAddition2);
            comboBoxes.Add(cbxAddition3);
            comboBoxes.Add(cbxAddition4);

            menuItemType = new Dictionary<IMenuItem, MenuType>();
            menuItemType.Add(new CoffeeDarkRoast(), MenuType.Beverage);
            menuItemType.Add(new Tea(), MenuType.Beverage);
            menuItemType.Add(new SandwichWithBacon(), MenuType.Food);
            menuItemType.Add(new SandwichWithRoastedBeef(), MenuType.Food);
            menuItemType.Add(new SandwichWithEggSalad(), MenuType.Food);

            menuItems = new List<IMenuItem>();
            foreach (IMenuItem item in menuItemType.Keys)
            {
                menuItems.Add(item);
            }

            menuAdditions = new Dictionary<MenuType, List<MenuItemAddition>>();
            List<MenuItemAddition> beverages = new List<MenuItemAddition>();
            beverages.Add(new Milk(null));
            beverages.Add(new Sugar(null));
            beverages.Add(new Sweetener(null));
            menuAdditions.Add(MenuType.Beverage, beverages);
            List<MenuItemAddition> food = new List<MenuItemAddition>();
            food.Add(new Lettuce(null));
            food.Add(new Tomato(null));
            food.Add(new Chees(null));
            food.Add(new Mayo(null));
            menuAdditions.Add(MenuType.Food, food);

            cbxMenuItem.Items.Add("-- Select Item --");
            foreach (IMenuItem item in menuItems)
            {
                cbxMenuItem.Items.Add(FormatComboBoxMenuItem(item));
            }
            cbxMenuItem.SelectedIndex = 0;
        }

        /**
         * HongChitC_301366112
         */
        private String FormatComboBoxMenuItem(IMenuItem item, int qty = 1)
        {
            string _qty = (qty > 1) ? $" x{qty}" : "";
            decimal cost = item.BaseCost * qty;
            return $"{item.Description}{_qty} - ${cost:0.##}";
        }

        /**
         * HongChitC_301366112
         */
        private void HideAdditionMenu()
        {
            lblAddition.Visible = false;
            foreach (ComboBox cbx in comboBoxes)
            {
                cbx.Visible = false;
            }
            btnAddItem.Enabled = false;
        }

        /**
         * HongChitC_301366112
         */
        private void UpdateAdditionMenu(MenuType menuType)
        {
            List<MenuItemAddition> menuItemAdditions = menuAdditions[menuType];
            if (menuItemAdditions == null) 
                MessageBox.Show($"Unsupported menuType: {menuType}", "Error", MessageBoxButtons.OK);

            if (comboBoxes.Count < menuItemAdditions.Count) 
                MessageBox.Show("Too many menuItemAdditions to show", "Error", MessageBoxButtons.OK);

            lblAddition.Visible = true;
            for (int i = 0; i < comboBoxes.Count; i++)
            {
                ComboBox cbx = comboBoxes[i];
                cbx.Items.Clear();
                if (i >= menuItemAdditions.Count)
                {
                    cbx.Visible = false;
                }
                else
                {
                    cbx.Visible = true;
                    MenuItemAddition menuItemAddition = menuItemAdditions[i];
                    cbx.Items.Add($"-- No {menuItemAddition.Description} --");
                    cbx.Items.Add(FormatComboBoxMenuItem(menuItemAddition));
                    cbx.Items.Add(FormatComboBoxMenuItem(menuItemAddition, 2));
                    cbx.SelectedIndex = 0;
                }

            }
            btnAddItem.Enabled = true;
        }

        /**
         * HongChitC_301366112
         */
        private void ShowCustomer()
        {
            lblCustomerDetails.Text = $"Name:{customer.Name}\n{customer.Address}\nPhone: {customer.Phone}";
        }

        /**
         * HongChitC_301366112
         */
        private void UpdateOrderItems()
        {
            decimal total = 0M;
            lbxOrderItems.Items.Clear();
            List<OrderItem> items = Order.Items;

            foreach (OrderItem item in items)
            {
                // TODO
                lbxOrderItems.Items.Add(item);
                total += item.Cost;
            }
            lblTotal.Text = $"Total: ${total:0.##}";
            btnOk.Enabled = (items.Count > 0);
            btnRemoveItem.Enabled = false;
        }

        /**
         * HongChitC_301366112
         */
        private void OrderForm_Load(object sender, EventArgs e)
        {
            InitMenu();
            ShowCustomer();
            btnRemoveItem.Enabled = false;
            btnOk.Enabled = false;
        }

        /**
         * HongChitC_301366112
         */
        private void cbxMenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int menuIndex = cbxMenuItem.SelectedIndex;
            if (menuIndex <= 0)
            {
                HideAdditionMenu();
            }
            else
            {
                IMenuItem menuItem = menuItems[menuIndex - 1];
                MenuType menuType = menuItemType[menuItem];
                UpdateAdditionMenu(menuType);
            }
        }

        /**
         * HongChitC_301366112
         */
        private IMenuItem CascadeMenuItemAddition(IMenuItem menuItem, MenuItemAddition addition)
        {
            switch (addition) {
                case Milk milk: return new Milk(menuItem);
                case Sugar sugar: return new Sugar(menuItem);
                case Sweetener sweetener: return new Sweetener(menuItem);
                case Lettuce lettuce: return new Lettuce(menuItem);
                case Tomato tomato: return new Tomato(menuItem);
                case Chees chees: return new Chees(menuItem);
                case Mayo mayo: return new Mayo(menuItem);
                default:
                    {
                        MessageBox.Show($"Not implemented for {addition}", "Error", MessageBoxButtons.OK);
                        return menuItem;
                    }
            }
        }

        /**
         * HongChitC_301366112
         */
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            int menuIndex = cbxMenuItem.SelectedIndex;
            if (menuIndex <= 0) return;

            IMenuItem menuItem = menuItems[menuIndex - 1];
            MenuType menuType = menuItemType[menuItem];

            int additionIndex;
            ComboBox cbx;
            List<MenuItemAddition> additions = menuAdditions[menuType];
            for (int i = 0; i < comboBoxes.Count; i++)
            {
                cbx = comboBoxes[i];
                if (cbx.Visible)
                {
                    additionIndex = cbx.SelectedIndex;
                    if (additionIndex > 0)
                    {
                        MenuItemAddition addition = additions[i];
                        for (int j = 0; j < additionIndex; j++)
                        {
                            menuItem = CascadeMenuItemAddition(menuItem, addition);
                        }
                    }
                }
            }

            Order.AddOrderItem(menuItem);
            UpdateOrderItems();
            cbxMenuItem.SelectedIndex = 0;
        }

        /**
         * HongChitC_301366112
         */
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            int itemIndex = lbxOrderItems.SelectedIndex;
            if (itemIndex == -1) return;

            Order.Items.RemoveAt(itemIndex);
            UpdateOrderItems();
        }

        /**
         * HongChitC_301366112
         */
        private void lbxOrderItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemIndex = lbxOrderItems.SelectedIndex;
            if (itemIndex == -1)
            {
                btnRemoveItem.Enabled = false;
                return;
            }
            else
            {
                btnRemoveItem.Enabled = true;
            }
        }
    }
}
