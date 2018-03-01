﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nile.Windows
{
    public /*abstract*/ partial class ProductDetailForm : Form
    {
        #region Construction 


        public ProductDetailForm()
        {

            InitializeComponent();
        }

        public ProductDetailForm( string title ) : this() //:base()
        {

            // InitializeComponent();

            Text = title;
        }

        public ProductDetailForm( Product product ) : this("Edit Product")
        {

            //InitializeComponent();
            //Text = "Edit Product";

            Product = product;
        }

        #endregion

        /// <summary>Gets or sets the product being edited.</summary> 
        public Product Product { get; set; }

        //public abstract DialogResult ShowDialogEx();


        // public virtual DialogResult ShowDialog()
        //   {
        //   return ShowDialog();
        //    }

        protected override void OnLoad( EventArgs e )
        {
            //Call base type
            //OnLoad(e);
            base.OnLoad(e);

            //Load product
            if (this.Product != null)
            {
                _txtName.Text = Product.Name;
                _txtDescription.Text = Product.Description;
                _txtPrice.Text = Product.Price.ToString();
                _chkIsDiscontinued.Checked = Product.IsDiscontinued;

            };

            ValidateChildren();
        }

      
        #region Event Handlers
        
         private void OnCancel( object sender, EventArgs e )
        {

            //Don't need this method as DialogResult set on button 

        }

        private void OnSave( object sender, EventArgs e )
        {
            //Force validation of child controls
            if (!ValidateChildren())
                return;

            // Create product 
            var product = new Product();
            product.Name = _txtName.Text;
            product.Description = _txtDescription.Text;
            product.Price = ConvertToPrice(_txtPrice);
            product.IsDiscontinued = _chkIsDiscontinued.Checked;

            //Validate
            var message = product.Validate();
            if (!String.IsNullOrEmpty(message))
            {
                
                DisplayError(message);
                return;
            }




            //Return from form 
            Product = product;
            DialogResult = DialogResult.OK;
            //DialogResult = DialogResult.None; 
            Close();
        }

        private void DisplayError( string message )
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
        }
        #endregion
        private decimal ConvertToPrice( TextBox control )
        {
            if (Decimal.TryParse(control.Text, out var price))
                return price;

            return -1;
        }

        private void _txtName_Validating( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var textbox = sender as TextBox;

            if (String.IsNullOrEmpty(textbox.Text))
            {
                _errorProvider.SetError(textbox, "Name is required");
                e.Cancel = true;
            } else

                _errorProvider.SetError(textbox, "");
        }
        private void _txtPrice_Validating( object sender, System.ComponentModel.CancelEventArgs e )
        {
            var textbox = sender as TextBox;

            var price = ConvertToPrice(textbox);
            if (price < 0)
            { 
                _errorProvider.SetError(textbox, "Price must be >=0");
            e.Cancel = true;
        } else

                _errorProvider.SetError(textbox, "");
        }
    }
}