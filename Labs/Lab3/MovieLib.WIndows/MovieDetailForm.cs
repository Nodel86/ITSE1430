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
    public partial class MovieDetailForm : Form
    {
        public MovieDetailForm ()
        {
            InitializeComponent();
        }

        public Movie Movie { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //Load the data
            if (Movie != null)
            {
                _txtTitle.Text = Movie.Title;
                _txtDescription.Text = Movie.Description;
                _txtLength.Text = Movie.Length.ToString();

                _cbIsOwned.Checked = Movie.IsOwned;
            };
        }

        #region Event Handlers

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave ( object sender, EventArgs e )
        {
            var newMovie = ValidateMovie();
            if (newMovie == null)
                return;

            //Save the data
            if (Movie != null)
            {
                Movie.Title = newMovie.Title;
                Movie.Description = newMovie.Description;
                Movie.Length = newMovie.Length;
                Movie.IsOwned = newMovie.IsOwned;
            } else
                Movie = newMovie;

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Private Members

        private Movie ValidateMovie ( )
        {
            var movie = new Movie()
            {
                Title = _txtTitle.Text,
                Description = _txtDescription.Text,
                IsOwned = _cbIsOwned.Checked
            };

            //Validate title
            if (movie.Title.Length == 0)
            {
                MessageBox.Show(this, "Title is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            };

            //Validate length
            var length = 0;
            if (_txtLength.Text.Length > 0)
            {
                if (!Int32.TryParse(_txtLength.Text, out length) || length < 0)
                {
                    MessageBox.Show(this, "Length must be >= 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                };

                movie.Length = length;
            };

            return movie;
        }
        #endregion
    }
}
