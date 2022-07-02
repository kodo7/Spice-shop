using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursadarbslpd
{
    public partial class Form2 : Form
    {
        BindingSource bsCustomer;
        BindingSource bsDelivery;
        BindingSource bsSpiceorders;
        BindingSource bsOrders;
        List<Label> newAmountLabels = new List<Label>();
        List<Label> newSpicenameLabels = new List<Label>();
        List<TextBox> newAmountTextboxes = new List<TextBox>();
        List<ComboBox> newComboboxes = new List<ComboBox>();
        List<BindingSource> newBinds = new List<BindingSource>();
        DataSet ds = new DataSet();
        DataGridView customersdgv = new DataGridView();
        NpgsqlDataAdapter customerAdapter = new NpgsqlDataAdapter();
        DataGridView deliveryaddressdgv = new DataGridView();
        NpgsqlDataAdapter deliveryAdapter = new NpgsqlDataAdapter();
        NpgsqlDataAdapter ordersAdapter = new NpgsqlDataAdapter();
        DataGridView ordersdgv = new DataGridView();
        NpgsqlDataAdapter orderspicesAdapter = new NpgsqlDataAdapter();
        DataGridView orderspicesdgv = new DataGridView();
        NpgsqlDataAdapter spicesAdapter = new NpgsqlDataAdapter();
        DataGridView spicesdgv = new DataGridView();
        int i = 0;
        public Form2(DataTable delivery, DataTable orders, DataTable orderspices, DataTable customer, DataSet ds, NpgsqlDataAdapter customerAdapter, DataGridView customersdgv, NpgsqlDataAdapter deliveryAdapter, DataGridView deliveryaddressdgv, NpgsqlDataAdapter ordersAdapter, DataGridView ordersdgv, NpgsqlDataAdapter orderspicesAdapter, DataGridView orderspicesdgv,NpgsqlDataAdapter spicesAdapter, DataGridView spicesdgv)
        {
            this.spicesdgv = spicesdgv;
            this.spicesAdapter = spicesAdapter;
            this.orderspicesAdapter = orderspicesAdapter;
            this.orderspicesdgv = orderspicesdgv;
            this.ordersAdapter = ordersAdapter;
            this.ordersdgv = ordersdgv;
            this.deliveryAdapter = deliveryAdapter;
            this.deliveryaddressdgv = deliveryaddressdgv;
            this.customerAdapter = customerAdapter;
            this.customersdgv = customersdgv;
            this.ds = ds;
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(CloseFormEvent);
            //Bind customer table
            bsCustomer = new BindingSource();
            bsCustomer.DataSource = ds.Tables["customer"];
            bsCustomer.AddNew();
            tbName.DataBindings.Add(new Binding("Text",bsCustomer,"name"));
            tbSurname.DataBindings.Add(new Binding("Text", bsCustomer, "surname"));
            tbPhone.DataBindings.Add(new Binding("Text", bsCustomer, "phone"));
            tbEmail.DataBindings.Add(new Binding("Text", bsCustomer, "email"));
            //Bind delivery_address table
            bsDelivery = new BindingSource();
            bsDelivery.DataSource = ds.Tables["delivery"];
            bsDelivery.AddNew();
            tbCountry.DataBindings.Add(new Binding("Text", bsDelivery, "country"));
            tbStreet.DataBindings.Add(new Binding("Text", bsDelivery, "street"));
            tbCity.DataBindings.Add(new Binding("Text", bsDelivery, "city"));
            //Bind orders table
            bsOrders = new BindingSource();
            bsOrders.DataSource = ds.Tables["orders"];
            bsOrders.AddNew();
            dateOrder.DataBindings.Add(new Binding("Text",bsOrders,"order_date"));
            //Bind orderspices table
            bsSpiceorders = new BindingSource();
            bsSpiceorders.DataSource = ds.Tables["orderspices"];
            bsSpiceorders.AddNew();
            tbAmount.DataBindings.Add(new Binding("Text", bsSpiceorders, "ammount_kg"));
            cbSpicename.DataSource = ds.Tables["spices"];
            cbSpicename.DisplayMember = "name";
            cbSpicename.ValueMember = "id_spice";
            cbSpicename.DataBindings.Add(new Binding("SelectedValue", bsSpiceorders, "id_spices"));
            //Add existing controls to lists
            newAmountLabels.Add(lblAmount);
            newAmountTextboxes.Add(tbAmount);
            newSpicenameLabels.Add(lblSpicename);
            newComboboxes.Add(cbSpicename);


        }

        private void btnAddSpice_Click(object sender, EventArgs e)
        {
            DataTable test = new DataTable();
            test = ds.Tables["spices"].Clone();
            spicesAdapter.Fill(test);
            Label a = new Label();
            a.Text = lblAmount.Text;
            a.Location = new Point(newAmountLabels[i].Location.X, newAmountLabels[i].Location.Y + 30);
            newAmountLabels.Add(a);
            TextBox b = new TextBox();
            newAmountTextboxes.Add(b);
            b.Location = new Point(newAmountTextboxes[i].Location.X, newAmountTextboxes[i].Location.Y + 30);
            Label c = new Label();
            c.Text = lblSpicename.Text;
            c.Location = new Point(newSpicenameLabels[i].Location.X, newSpicenameLabels[i].Location.Y + 30);
            newSpicenameLabels.Add(c);
            ComboBox d = new ComboBox();
            d.Location = new Point(newComboboxes[i].Location.X, newComboboxes[i].Location.Y + 30);
            BindingSource g = new BindingSource();
            g.DataSource = ds.Tables["orderspices"];
            g.AddNew();
            b.DataBindings.Add(new Binding("Text", g, "ammount_kg"));
            d.DataSource = test;
            d.DisplayMember = "name";
            d.ValueMember = "id_spice";
            d.DataBindings.Add(new Binding("SelectedValue", g, "id_spices"));

            newComboboxes.Add(d);

            i++;
            this.Height = Height + 30;
            btnAddCustomer.Location = new Point(btnAddCustomer.Location.X,btnAddCustomer.Location.Y+30);
            tabPage2.Controls.Add(b);
            tabPage2.Controls.Add(a);
            tabPage2.Controls.Add(d);
            tabPage2.Controls.Add(c);
        }

        private void btnAddCustomer_Click_1(object sender, EventArgs e)
        {
            bsCustomer.AddNew();
            customerAdapter.Update((DataTable)customersdgv.DataSource);
            bsDelivery.AddNew();
            deliveryAdapter.Update((DataTable)deliveryaddressdgv.DataSource);
            //BindingSource customerid = new BindingSource();
            //BindingSource deliveryid = new BindingSource();
            // MessageBox.Show(Convert.ToString(ordersdgv.Rows[ordersdgv.RowCount - 1].Cells[1].Value));
            //MessageBox.Show(Convert.ToString(ordersdgv.Rows[ordersdgv.RowCount - 1].Cells[3].Value));
            bsOrders.AddNew();
            ordersdgv.Rows[ordersdgv.RowCount-1].Cells["id_customer"].Value = ds.Tables["customer"].Rows[ds.Tables["customer"].Rows.Count - 1]["id_customer"];
            ordersdgv.Rows[ordersdgv.RowCount-1].Cells["id_delivery_address"].Value = ds.Tables["delivery"].Rows[ds.Tables["delivery"].Rows.Count - 1]["id_delivery_address"];
            foreach (DataGridViewRow row in ordersdgv.Rows)
            {
                if (row.Cells["id_customer"].Value == null || row.Cells["id_customer"].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells["id_customer"].Value.ToString()))
                {
                    row.Cells["id_customer"].Value = ds.Tables["customer"].Rows[ds.Tables["customer"].Rows.Count - 1]["id_customer"];
                }
                if (row.Cells["id_delivery_address"].Value == null || row.Cells["id_delivery_address"].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells["id_delivery_address"].Value.ToString()))
                {
                    row.Cells["id_delivery_address"].Value = ds.Tables["delivery"].Rows[ds.Tables["delivery"].Rows.Count - 1]["id_delivery_address"];
                }
            }
            ordersAdapter.Update((DataTable)ordersdgv.DataSource);
            bsSpiceorders.AddNew();
            foreach (DataGridViewRow row in orderspicesdgv.Rows)
            {
                if (row.Cells["id_order"].Value == null || row.Cells["id_order"].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells["id_order"].Value.ToString()))
                {
                    row.Cells["id_order"].Value = ds.Tables["orders"].Rows[ds.Tables["orders"].Rows.Count - 1]["id_order"];
                }
            }
            orderspicesAdapter.Update((DataTable)orderspicesdgv.DataSource);
            Close();
        }
        private void CloseFormEvent(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
