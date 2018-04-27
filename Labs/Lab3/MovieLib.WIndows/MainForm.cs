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
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )

        {

            base.OnLoad(e);



            RefreshUI();

        }

        #region Event Handlers

        private void OnFileExit ( object sende, EventArgs e )
        {
            Close();
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var button = sender as ToolStripMenuItem;

            var form = new MovieDetailForm("Add Movie");

            var result = form.ShowDialog(this);
            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            //Add the movie
            _movie = form.Movie;
        }

        private void OnMovieEdit ( object sende, EventArgs e )
        {
            //Check for no movie
            if (!CheckForMovie())
                return;

            var form = new MovieDetailForm();
            form.Movie = CopyMovie(_movie);

            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            //Update the movie
            _movie = form.Movie;
        }

        private void OnMovieDelete ( object sende, EventArgs e )
        {
            //Check for no movie
            if (!CheckForMovie())
                return;

            //Display a confirmation
            if (MessageBox.Show(this, $"Are you sure you want to delete\r\n{_movie.Title}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //Delete the movie
            _movie = null;
        }

        }
        private void OnHelpAbout ( object sender, EventArgs e )
        {
            MessageBox.Show(this, "Not implemented", "Help About", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion

        private Movie GetSelectedMovie()

        private bool CheckForMovie ()
        {
            //Check for no movie
            if (_movie != null)
                return true;

            MessageBox.Show(this, "No movie defined.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private Movie CopyMovie ( Movie movie )
        {

            return MessageBox.Show(this, message, title

                             , MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                           == DialogResult.Yes;

        }
        
        private Movie _movie;
        #endregion
    }
}
