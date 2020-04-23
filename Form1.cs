using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecapProject1.entities;

namespace RecapProject1
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           ListProducts();
         ListCategory();
          
        }

        private void ListProducts()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                dataGridView1.DataSource = context.Products.ToList();
            }
        }

        private void ListCategory()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
               txtCategory.DataSource= context.Categories.ToList();
               txtCategory.DisplayMember = "CategoryName";
               txtCategory.ValueMember = "CategoryId";
            }
        }
        public List<Product> ListByProductName(string key)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                return context.Products.Where(p => p.ProductName.Contains(key)).ToList();
            }
        }

        public void ListProductsByCategoryName(int categoryId)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                dataGridView1.DataSource=  context.Products.Where(p => p.CategoryId ==categoryId).ToList();
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = ListByProductName(textBox1.Text);
        }

        private void txtCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            NorthWindContext context = new NorthWindContext();
           ListProductsByCategoryName(txtCategory.SelectedIndex);



        }
    }
}
