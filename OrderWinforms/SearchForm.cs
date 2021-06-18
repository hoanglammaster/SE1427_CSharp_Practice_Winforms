using OrderWinforms.BLL;
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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }
        private void SearchForm_Load(object sender, EventArgs e)
        {
            OrderBLL orderBLL = new OrderBLL();
            List<Order> listOrder = orderBLL.getListAllOrder();
            List<string> listCustomer = new List<string>();
            listCustomer.Add("All Customer");
            foreach (Order order in listOrder)
            {
                listCustomer.Add(order.Customer);
            }

            List<string> listEmployee = new List<string>();
            listEmployee.Add("All Employee");
            foreach (Order order in listOrder)
            {
                listEmployee.Add(order.Employee);
            }

            comboBox1.DataSource = listCustomer;
            comboBox1.SelectedItem = listCustomer[0];
            comboBox2.DataSource = listEmployee;
            comboBox2.SelectedItem = listEmployee[0];
            dataGridView1.DataSource = listOrder;
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kiểm tra combo box 2 null vì lúc program load lần đầu, lúc comboBox1 add item
            //sẽ đồng thời gọi hàm comboBox1_SelectedIndexChanged làm cho comboBox2 lúc này còn null
            // cũng được gọi ra => error
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                reloadData();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kiểm tra combo box 2 null vì lúc program load lần đầu, lúc comboBox1 add item
            //sẽ đồng thời gọi hàm comboBox1_SelectedIndexChanged làm cho comboBox2 lúc này còn null
            // cũng được gọi ra => error
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                reloadData();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            reloadData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            reloadData();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            reloadData();
        }

        public void reloadData()
        {
            OrderBLL orderBLL = new OrderBLL();
            List<Order> listOrder = orderBLL.getListOrderWithConditions(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, checkBox1.Checked);
            dataGridView1.DataSource = listOrder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateForm createForm = new CreateForm();
            createForm.Show();
        }

    }
}
