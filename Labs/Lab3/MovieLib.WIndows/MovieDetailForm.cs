/*
 * ITSE 1430
 * Ashton Harris
 * Lab3
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLib.Windows
{
    /// <summary>Provides a form for adding/editing <see cref="Product"/>.</summary>

    public partial class MovieDetailForm : Form

    {
        public MovieDetailForm ()
        {

            InitializeComponent();

        }



        public MovieDetailForm( string title ) : this()

        {

            Text = title;

        }



        public MovieDetailForm( Movie movie ) : this("Edit Movie")

        {

            Movie = movie;

        }

        #endregion



        /// <summary>Gets or sets the product being edited.</summary>

        public Movie Product { get; set; }



        protected override void OnLoad( EventArgs e )

        {

            base.OnLoad(e);



            //Load product

            if (Movie != null)

            {

                _txtTitle.Text = Product.Title;

                _txtDescription.Text = Product.Description;

                _txtLength.Text = Movie.Length.ToString();

                _chkIsOwned.Checked = Movie.IsOwned;

            };



            ValidateChildren();

        }



        #region Event Handlers



        private void OnCancel( object sender, EventArgs e )

        {

        }



        private void OnSave( object sender, EventArgs e )

        {

            //Force validation of child controls

            if (!ValidateChildren())

                return;



            // Create product - using object initializer syntax

            var movie = new Movie() {

                Title = _txtTitle.Text,

                Description = _txtDescription.Text,

                Length = ConvertToLength(_txtLength),

                IsOwned = _chkIsOwned.Checked,

            };



            //Validate product using IValidatableObject

            var errors = ObjectValidator.Validate(movie);

            if (errors.Count() > 0)

            {

                //Get first error

                DisplayError(errors.ElementAt(0).ErrorMessage);

                return;

            };



            //Return from form

            Movie = movie;

            DialogResult = DialogResult.OK;



            Close();

        }

        #endregion



        private void DisplayError( string message )

        {

            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK,

                            MessageBoxIcon.Error);

        }

        private decimal ConvertToLength( TextBox control )

        {

            if (Decimal.TryParse(control.Text, out var length))

                return length;



            return 0;

        }



        private void _txtTitle_Validating( object sender, System.ComponentModel.CancelEventArgs e )

        {

            var textbox = sender as TextBox;



            if (String.IsNullOrEmpty(textbox.Text))

            {



                _errorProvider.SetError(textbox, "Title is required");

                e.Cancel = true;

            } else

                _errorProvider.SetError(textbox, "");

        }



        private void _txtLength_Validating( object sender, System.ComponentModel.CancelEventArgs e )

        {

            var textbox = sender as TextBox;



            var length = ConvertToLength(textbox);

            if (length < 0)

            {

                _errorProvider.SetError(textbox, "Length must be >= 0");

                e.Cancel = true;

            } else

                _errorProvider.SetError(textbox, "");

        }

    }

}