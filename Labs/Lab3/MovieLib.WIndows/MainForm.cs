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

        private void RefreshUI()

        {
            var movies = _database.GetAll();
            movieBindingSource.DataSource = movies.ToList();
        }

        #region Event Handlers

        private void OnMovieAdd( object sender, EventArgs e )
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

        private void OnMovieRemove( object sender, EventArgs e )

        {
            //Get selected movie

            var movie = GetSelectedMovie();

            if (movie == null)

            {
               MessageBox.Show( "No Movie selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            };

            DeleteMovie(movie);

        }

        //Helper method to handle deleting movies

        private void DeleteMovie( Movie movie )

        {

            if (!ShowConfirmation("Are you sure?", "Remove Movie"))

                return;
             //Remove product

            _database.Remove(movie.Id);

              RefreshUI();

        }

        private void OnMovieEdit( object sender, EventArgs e )
        {
            //Get selected movie
            var movie = GetSelectedMovie();
            if (movie == null)

            {

            MessageBox.Show( "No movie selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            };
            EditMovie(movie);

        }

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


    }
       private void OnFileExit ( object sende, EventArgs e )
        {
            Close();
        }

   }
    private void OnHelpAbout ( object sender, EventArgs e )
        {

    var form = new OnHelpAboutForm();

    var result = form.ShowDialog(this);
    if (result != DialogResult.OK)
        return;

        }
        #endregion

        private Movie GetSelectedMovie()
   {

    //TODO: Use the binding source

    //Get the first selected row in the grid, if any

    if (dataGridView1.SelectedRows.Count > 0)

        return dataGridView1.SelectedRows[0].DataBoundItem as Movie;
        return null;
}

private bool ShowConfirmation( string message, string title )

{

    return MessageBox.Show(this, message, title

                     , MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                   == DialogResult.Yes;

}

private IMovietDatabase _database = new MemoryMovieDatabase();

//Called when a cell is double clicked

private void OnCellDoubleClick( object sender, DataGridViewCellEventArgs e )

{

    var movie = GetSelectedMovie();

    if (movie == null)

        return;

 EditMovie(movie);

}

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


        
       
       
    


