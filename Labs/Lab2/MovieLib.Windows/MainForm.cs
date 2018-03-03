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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void TitleAdd( object sender, EventArgs e )
        {
            var button = sender as ToolStripMenuItem;



            var form = new MovieDetailForm("Add Title");



            //Show form modally

            var result = form.ShowDialog(this);

            if (result != DialogResult.OK)

                return;
        }

        private void OnTitleEdit( object sender, EventArgs e )

        {

            //Get selected Title

            var _title = GetSeletedTitle();

            if (_title == null)

                return;

            var form = new MovieDetailForm(_title);

            var result = form.ShowDialog(this);

            if (result != DialogResult.OK)

                return;

            private void OnTitleRemove( object sender, EventArgs e )

            {
                var product = GetSelectedTitle();

                if (product == null)

                    return;

                if (!ShowConfirmation("Are you sure?", "Remove Title"))

                    return;
            }

            private void OnHelpAbout( object sender, ToolStripItemClickedEventArgs e )
            {
                MessageBox.Show(this, "Not implemented", "Help About", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
           #endregion

            public Title GetSelectedTitle()

            {

                //Get the first selected row in the grid, if any

                if (groupBox1_Enter.SelectedRows.Count > 0)

                    return groupBox1_Enter.SelectedRows[0].DataBoundItem as Title;



                return null;
            }

            private bool ShowConfirmation( string message, string Title )

            {

                return MessageBox.Show(this, message, _title

                                 , MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                               == DialogResult.Yes;

            }

        }

        private void MainForm_Load( object sender, EventArgs e )
        {

        }

        private void toolStrip1_ItemClicked( object sender, ToolStripItemClickedEventArgs e )
        {

        }

        private void toolStripButton1_Click( object sender, EventArgs e )
        {

        }
    }
}

