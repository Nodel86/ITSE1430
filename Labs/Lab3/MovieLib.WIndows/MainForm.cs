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
using MovieLib.Data.Memory;

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

        //Called when a cell is double clicked

        private void OnCellDoubleClick( object sender, DataGridViewCellEventArgs e )

        {

            var movie = GetSelectedMovie();

            if (movie == null)

                return;



            EditMovie(movie);

        }



        //Called when a key is pressed while in a cell

        private void OnCellKeyDown( object sender, KeyEventArgs e )

        {

            var movie = GetSelectedMovie();

            if (movie == null)

                return;



            if (e.KeyCode == Keys.Delete)

            {

                e.Handled = true;

                DeleteMovie(movie);

            } else if (e.KeyCode == Keys.Enter)

            {

                e.Handled = true;

                EditMovie(movie);

            };

        }

        private void OnFileExit ( object sende, EventArgs e )
        {
            Close();
        }

        private void OnMovieAdd ( object sende, EventArgs e )
        {
            var button = sender as ToolStripMenuItem;

            var form = new MovieDetailForm("Add Movie");

            var result = form.ShowDialog(this);
            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            //Add to database

            _database.Add(form.Movie, out var message);

            if (!String.IsNullOrEmpty(message))

                MessageBox.Show(message);



            RefreshUI();

        }

        private void OnMovieEdit ( object sende, EventArgs e )
        {
            //Get selected product

            var movie = GetSelectedMovie();

            if (movie == null)

            {

                MessageBox.Show(this, "No movie selected", "Error",

                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            };



            EditMovie(movie);

        }

        private void OnMovieDelete ( object sende, EventArgs e )
        {
            //Get selected product

            var movie = GetSelectedMovie();

            if (movie == null)

            {

                MessageBox.Show(this, "No movie selected", "Error",

                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            };



            DeleteMovie(movie);
        }

        private void OnHelpAbout ( object sende, EventArgs e )
        {
            MessageBox.Show(this, "Not implemented", "Help About", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion

        #region Private Members

        //Helper method to handle deleting movies

        private void DeleteMovie( Movie movie )

        {

            if (!ShowConfirmation("Are you sure?", "Remove Movie"))

                return;

            //Remove movie

            _database.Remove(movie.Id);

            RefreshUI();

        }

        //Helper method to handle editing movie

        private void EditMovie( Movie movie )

        {

            var form = new MovieDetailForm(movie);

            var result = form.ShowDialog(this);

            if (result != DialogResult.OK)

                return;



            //Update the movie

            form.Movie.Id = movie.Id;

            _database.Update(form.Movie, out var message);

            if (!String.IsNullOrEmpty(message))

                MessageBox.Show(message);



            RefreshUI();

        }

        private Movie GetSelectedMovie()

        {

            //TODO: Use the binding source

            //Get the first selected row in the grid, if any

            if (dataGridView1.SelectedRows.Count > 0)

                return dataGridView1.SelectedRows[0].DataBoundItem as Movie;



            return null;

        }

        private void RefreshUI()

        {
            var movies = _database.GetAll();
            movieBindingSource.DataSource = movies.ToList();

         }

        private bool ShowConfirmation( string message, string title )

        {

            return MessageBox.Show(this, message, title

                             , MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                           == DialogResult.Yes;

        }

        private Data.IMovieDatabase _database = new MemoryMovieDatabase();
        private ToolStripMenuItem sender;

        public object movieBindingSource { get; private set; }
        public object dataGridView1 { get; private set; }

        #endregion
    }
}
