using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClothingSystem.Common;
using ClothingSystem.DataLogic;

namespace ClothingSystem.GUI
{
    public partial class Form1 : Form
    {
        private DbDataService repo = new DbDataService();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var item = new ClothingItem
            {
                CustomerName = txtName.Text,
                Type = txtType.Text,
                Size = txtSize.Text,
                Color = txtColor.Text,
                Price = decimal.Parse(txtPrice.Text)
            };

            if (!repo.Exists(item.CustomerName))
            {
                repo.AddItem(item);
                MessageBox.Show("Item added.");
            }
            else
            {
                MessageBox.Show("Customer already exists.");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            lstItems.Items.Clear();
            var items = repo.GetAllItems();
            foreach (var item in items)
            {
                lstItems.Items.Add($"{item.CustomerName} - {item.Type} - {item.Size} - {item.Color} - {item.Price}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (repo.RemoveItem(txtName.Text))
                MessageBox.Show("Item deleted.");
            else
                MessageBox.Show("Item not found.");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstItems.Items.Clear();
            var results = repo.SearchByType(txtType.Text);
            foreach (var item in results)
            {
                lstItems.Items.Add($"{item.CustomerName} - {item.Type} - {item.Size} - {item.Color} - {item.Price}");
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblColor_Click(object sender, EventArgs e)
        {

        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
