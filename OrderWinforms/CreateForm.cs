using OrderWinforms.BLL;
using OrderWinforms.DAL;
using OrderWinforms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrderWinforms
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            CustomerBLL customerBLL = new CustomerBLL();
            EmployeeBLL employeeBLL = new EmployeeBLL();
            ProductBLL productBLL = new ProductBLL();
            ShipperBLL shipperBLL = new ShipperBLL();
            comboBox1.DataSource = customerBLL.getListAllCustomer();
            comboBox1.DisplayMember = "CompanyName";
            comboBox1.ValueMember = "CustomerID";
            comboBox2.DataSource = employeeBLL.getListAllEmployee();
            comboBox2.DisplayMember = "EmployeeName";
            comboBox2.ValueMember = "EmployeeID";
            comboBox3.DataSource = shipperBLL.getListAllShipper();
            comboBox3.DisplayMember = "CompanyName";
            comboBox3.ValueMember = "ShipperID";
            listBox1.DataSource = productBLL.getListAllProduct();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Product> listSelected = new List<Product>();
            foreach (int index in listBox1.SelectedIndices)
            {
                listSelected.Add((Product)listBox1.Items[index]);
            }
            dataGridView1.DataSource = listSelected;
            dataGridView1.Columns["ProductID"].Visible = false;
            dataGridView1.Columns["ProductName"].ReadOnly = true;
            dataGridView1.Columns["ProductName"].DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.Columns["QuantityPerUnit"].ReadOnly = true;
            dataGridView1.Columns["QuantityPerUnit"].DefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.Columns["UnitsInStock"].ReadOnly = true;
            dataGridView1.Columns["UnitsInStock"].DefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //check Quantity < UnitsPerStock
            if(e.ColumnIndex == 5)
            {
                int quantity = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                int unitInStock = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                if (quantity > unitInStock)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = unitInStock;
                }
            }
            if(e.ColumnIndex == 6)
            {
                int discount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                if(discount > 100)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 100;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.DataSource != null)
            {
                OrderBLL orderBLL = new OrderBLL();
                List<Product> products = (List<Product>)dataGridView1.DataSource;
                orderBLL.insertOrderToDB(comboBox1.SelectedValue.ToString(),Int32.Parse(comboBox2.SelectedValue.ToString()),dateTimePicker1.Value,Int32.Parse(comboBox3.SelectedValue.ToString()),Double.Parse(textBox1.Text),products);
                reloadAfterCreate();
            }
        }
        private void reloadAfterCreate()
        {
            ProductBLL productBLL = new ProductBLL();
            listBox1.DataSource = productBLL.getListAllProduct();
            dataGridView1.DataSource = null;
            textBox1.Text = "";
            Program.searchForm.reloadData();
        }
    }
}
