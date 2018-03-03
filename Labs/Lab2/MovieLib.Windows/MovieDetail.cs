/*

 * ITSE 1430

 * Lab 2
 * Ashton Harris

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
    public partial class MovieDetail : Form
    {
        public MovieDetail()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter( object sender, EventArgs e )
        {
            //Validate

            var message = title.Validate();

            if (!String.IsNullOrEmpty(message))

            {
               DisplayError(message);
                return;
             };

            //Return from form
          Title = title;
          DialogResult = DialogResult.OK;
          Close();

        }

#endregion

        private void OnSave( object sender, EventArgs e )

        {

            //Force validation of child controls

            if (!ValidateChildren())

                return;



            // Create Title

            var title = new Title();

            title.Name = _txttitle.Text;

            title.Description = _txtDescription.Text;

           private void DisplayError( string message )

        {

            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK,

                            MessageBoxIcon.Error);


        }

    }
}
 

