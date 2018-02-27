using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nile.Data.Memory;

namespace Nile.Windows

{

    public partial class MainForm : Form

    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            RefreshUI();

        }

        #region Event Handlers

        private void RefreshUI()
        {
            //Get products
            var products = _database.GetAll();

            //Bind to grid
            _
        }
        //Just a method to play around with members of our Product class
        private void PlayingWithProductMembers()
        {
            //Create a new product
            var product = new Product();

            //Cannot use properties as out parameters
            Decimal.TryParse("123", out var price);
            product.Price = price;

            //Get the property Name, no need for a function
            var name = product.Name;
            //var name = product.GetName();

            //Set the property Name, Price and IsDiscontinued
            product.Name = "Product A";
            product.Price = 50;
            product.IsDiscontinued = true;

            //ActualPrice is calculated so you cannot set it

            //product.ActualPrice = 10;
            var price2 = product.ActualPrice;

            //product.SetName("Product A");
            //product.Description = "None";
            //Validate the product
            var error = product.Validate();

            //Convert anything to a string
            var str = product.ToString();

            //Create another product
            var productB = new Product();
            //productB.Name = "Product B";
            //productB.SetName("Product B");
            //productB.Description = product.Description;            
            //Validate the new product
            error = productB.Validate();

        }

     
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var button = sender as ToolStripMenuItem;
            var form = new ProductDetailForm("Add Product");

            //Show form modally
            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            //Add to database
            _database.Add(form.Product, out var message);
            if (!String.IsNullOrEmpty(message))
                MessageBox.Show(message);


            //Find empty array element
            // var index = FindEmptyProductIndex();
            //if (index >= 0)
            //  _products[index] = form.Product;
        }
        private int FindEmptyProductIndex()
        {
            for (var index = 0; index < _products.Length; ++index)
            {
                if (_products[index] == null)
                    return index;
            };
            return -1;

        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            //Get the first product
            var products = _database.GetAll();
            var prodcut = (products.Length > 0) ? products[0] : null;
            if (product == null)
                return;

           // var index = FindEmptyProductIndex() - 1;
            //if (index < 0)
             //   return;

            // if (_product == null)
            //  return;

            var form = new ProductDetailForm(products);

            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            //"Editing" the product
            _database.Edit(form.Product, out var message);
            if (!String.IsNullOrEmpty(message))
                MessageBox.Show(message);

            // _products[index] = form.Product;
        }

        private void OnProductRemove( object sender, EventArgs e )
        {
            //var index = FindEmptyProductIndex() - 1;
            // if (index < 0)
            // return;

            //Get the first product
            var products = _database.GetAll();
            var prodcut = (products.Length > 0) ? products[0] : null;
            if (product == null)
                return;

            if (!ShowConfirmation("Are you sure?", "Remove Product"))
                //  return;
                //Remove product
                _database.Remove(product.Id);
            //_products[index] = null;
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            MessageBox.Show(this, "Not implemented", "Help About", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        #endregion
        private bool ShowConfirmation( string message, string title )
        {
            return MessageBox.Show(this, message, title
           , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
           == DialogResult.Yes;
        }
        private MemoryProductDatabase _database = new MemoryProductDatabase();

    }

}