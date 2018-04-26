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
using MovieLib.Data;
using MovieLib.Data.Memory;

namespace MovieLib.Windows
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }

        #region Event Handlers



        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var form = new MovieDetailForm();

            if (form.ShowDialog(this) != DialogResult.OK)
                return;

            //Add to Database
            _database.Add(form.Movie, out var message);

            if (!String.IsNullOrEmpty(message))

                MessageBox.Show(message);

            RefreshUI();


        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            //Get selected product

            var movie = GetSelectedMovie();

            if (movie == null)

            {

                MessageBox.Show(this, "No product selected", "Error",

                                MessageBoxButtons.OK, MessageBoxIcon.Error);

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



            //Update the product

            form.Movie.Id = movie.Id;

            _database.Update(form.Movie, out var message);

            if (!String.IsNullOrEmpty(message))

                MessageBox.Show(message);



            RefreshUI();

        }

        private void RefreshUI()

        {

            //Get products

            var movies = _database.GetAll();

            //products[0].Name = "Product A";



            //Bind to grid

            //productBindingSource.DataSource = new List<Product>(products);

            //productBindingSource.DataSource = Enumerable.ToList(products);

            movieBindingSource.DataSource = movies.ToList();

            //dataGridView1.DataSource 

        }

        private void OnMovieRemove ( object sender, EventArgs e )
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

        private void DeleteMovie( Movie movie )

        {

            if (!ShowConfirmation("Are you sure?", "Remove Product"))

                return;



            //Remove product

            _database.Remove(movie.Id);



            RefreshUI();

        }
        private void OnHelpAbout ( object sender, EventArgs e )
        {
            new AboutForm().ShowDialog(this);
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

        #region Private Members

       
        private bool ShowConfirmation( string message, string title )

        {

            return MessageBox.Show(this, message, title

                             , MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                           == DialogResult.Yes;

        }

        private IMovieDatabase _database = new MemoryMovieDatabase();
        #endregion
    }
}
