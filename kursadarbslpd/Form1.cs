using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace kursadarbslpd
{
    public partial class Form1 : Form
    {
        public NpgsqlConnection conn;
        //Adapters
        public NpgsqlDataAdapter customerAdapter = new NpgsqlDataAdapter();
        public NpgsqlDataAdapter deliveryAdapter = new NpgsqlDataAdapter();
        public NpgsqlDataAdapter empAdapter = new NpgsqlDataAdapter();
        public NpgsqlDataAdapter orderspicesAdapter = new NpgsqlDataAdapter();
        public NpgsqlDataAdapter ordersAdapter = new NpgsqlDataAdapter();
        public NpgsqlDataAdapter shopAdapter = new NpgsqlDataAdapter();
        public NpgsqlDataAdapter spicecategoriesAdapter = new NpgsqlDataAdapter();
        public NpgsqlDataAdapter spicesAdapter = new NpgsqlDataAdapter();
        public NpgsqlDataAdapter supplyAdapter = new NpgsqlDataAdapter();
        //DataTables
        public DataTable customer = new DataTable();
        public DataTable delivery = new DataTable();
        public DataTable emp = new DataTable();
        public DataTable orderspices = new DataTable();
        public DataTable orders = new DataTable();
        public DataTable shop = new DataTable();
        public DataTable spicecategories = new DataTable();
        public DataTable spices = new DataTable();
        public DataTable supply = new DataTable();

        public Form1()
        {
            InitializeComponent();
            conn = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;Password=postgres;Database=spiceshop;");
            //SELECT commands for adapters
            NpgsqlCommand selCustomerCmd = new NpgsqlCommand("SELECT * from customer", conn);
            NpgsqlCommand selDeliveryCmd = new NpgsqlCommand("SELECT * from delivery_address", conn);
            NpgsqlCommand selEmpCmd = new NpgsqlCommand("SELECT * from employees", conn);
            NpgsqlCommand selOrderspicesCmd = new NpgsqlCommand("SELECT * from order_spices", conn);
            NpgsqlCommand selOrdersCmd = new NpgsqlCommand("SELECT * from orders", conn);
            NpgsqlCommand selShopCmd = new NpgsqlCommand("SELECT * from shop", conn);
            NpgsqlCommand selSpicecategoriesCmd = new NpgsqlCommand("SELECT * from spice_categories", conn);
            NpgsqlCommand selSpicesCmd = new NpgsqlCommand("SELECT * from spices", conn);
            NpgsqlCommand selSupplyCmd = new NpgsqlCommand("SELECT * from supply", conn);
            //Assigned SELECT commands to adapters
            customerAdapter.SelectCommand = selCustomerCmd;
            deliveryAdapter.SelectCommand = selDeliveryCmd;
            empAdapter.SelectCommand = selEmpCmd;
            orderspicesAdapter.SelectCommand = selOrderspicesCmd;
            ordersAdapter.SelectCommand = selOrdersCmd;
            shopAdapter.SelectCommand = selShopCmd;
            spicecategoriesAdapter.SelectCommand = selSpicecategoriesCmd;
            spicesAdapter.SelectCommand = selSpicesCmd;
            supplyAdapter.SelectCommand = selSupplyCmd;
            //Filled tables using adapters
            customerAdapter.Fill(customer);
            deliveryAdapter.Fill(delivery);
            orderspicesAdapter.Fill(orderspices);
            ordersAdapter.Fill(orders);
            shopAdapter.Fill(shop);
            spicecategoriesAdapter.Fill(spicecategories);
            spicesAdapter.Fill(spices);
            supplyAdapter.Fill(supply);
            //Assign DataTables to DataGridViews
            employeesdgv.DataSource = emp;
            customersdgv.DataSource = customer;
            deliveryaddressdgv.DataSource = delivery;
            orderspicesdgv.DataSource = orderspices;
            ordersdgv.DataSource = orders;
            shopdgv.DataSource = shop;
            categoriesdgv.DataSource = spicecategories;
            spicesdgv.DataSource = spices;
            supplydgv.DataSource = supply;
        }
        void HideAllDGV()
        {
            employeesdgv.Hide();
            deliveryaddressdgv.Hide();
            customersdgv.Hide();
            ordersdgv.Hide();
            orderspicesdgv.Hide();
            shopdgv.Hide();
            categoriesdgv.Hide();
            spicesdgv.Hide();
            supplydgv.Hide();
        }
        private void employeesbtn_Click(object sender, EventArgs e)
        {
            emp.Clear();
            empAdapter.Fill(emp);
            HideAllDGV();
            employeesdgv.Show();
            //Update
            NpgsqlCommand upEmployeesCmd = new NpgsqlCommand("UPDATE EMPLOYEES SET name = @name, surname = @surname , hire_date = @hire_date , salary_euro = @salary_euro, id_shop = @id_shop, phone = @phone, id_manager = @id_manager WHERE id_emp = @id_emp", conn);
            upEmployeesCmd.Parameters.Add(new NpgsqlParameter("@name", DbType.String, 50, "name"));
            upEmployeesCmd.Parameters.Add(new NpgsqlParameter("@surname", DbType.String, 50, "surname"));
            upEmployeesCmd.Parameters.Add(new NpgsqlParameter("@hire_date", DbType.Date, 0, "hire_date"));
            upEmployeesCmd.Parameters.Add(new NpgsqlParameter("@salary_euro", DbType.Decimal, sizeof(double), "salary_euro"));
            upEmployeesCmd.Parameters.Add(new NpgsqlParameter("@id_shop", DbType.Int32, sizeof(int), "id_shop"));
            upEmployeesCmd.Parameters.Add(new NpgsqlParameter("@phone", DbType.Int32, sizeof(int), "phone"));
            upEmployeesCmd.Parameters.Add(new NpgsqlParameter("@id_manager", DbType.Int32, sizeof(int), "id_manager"));
            upEmployeesCmd.Parameters.Add(new NpgsqlParameter("@id_emp", DbType.Int32, sizeof(int), "id_emp"));
            empAdapter.UpdateCommand = upEmployeesCmd;
        }

        private void customerbtn_Click(object sender, EventArgs e)
        {
            customer.Clear();
            customerAdapter.Fill(customer);
            HideAllDGV();
            customersdgv.Show();
        }

        private void deliveryaddressbtn_Click(object sender, EventArgs e)
        {
            delivery.Clear();
            deliveryAdapter.Fill(delivery);
            HideAllDGV();
            deliveryaddressdgv.Show();
        }

        private void shopbtn_Click(object sender, EventArgs e)
        {
            shop.Clear();
            shopAdapter.Fill(shop);
            HideAllDGV();
            shopdgv.Show();
        }

        private void spicesbtn_Click(object sender, EventArgs e)
        {
            spices.Clear();
            spicesAdapter.Fill(spices);
            HideAllDGV();
            spicesdgv.Show();
        }

        private void supplybtn_Click(object sender, EventArgs e)
        {
            supply.Clear();
            supplyAdapter.Fill(supply);
            HideAllDGV();
            supplydgv.Show();
        }

        private void ordersbtn_Click(object sender, EventArgs e)
        {
            orders.Clear();
            ordersAdapter.Fill(orders);
            HideAllDGV();
            ordersdgv.Show();
        }

        private void spicecategoriesbtn_Click(object sender, EventArgs e)
        {
            spicecategories.Clear();
            spicecategoriesAdapter.Fill(spicecategories);
            HideAllDGV();
            categoriesdgv.Show();
        }

        private void orderspicesbtn_Click(object sender, EventArgs e)
        {
            spicecategories.Clear();
            spicecategoriesAdapter.Fill(spicecategories);
            HideAllDGV();
            orderspicesdgv.Show();
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            empAdapter.Update((DataTable)employeesdgv.DataSource);
        }
    }
}
