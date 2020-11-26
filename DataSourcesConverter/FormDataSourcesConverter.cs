using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourcesConverter
{
    public partial class FormDataSourcesConverter : Form
    {

        public FormDataSourcesConverter()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            DataGridView dg = dataGridView1;

            ButtonAddConfig.Visible = true;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex > 0)
            {
                //TODO - Button Clicked - Execute Code Here
                //MessageBox.Show("Test"+e.RowIndex);
                dg.Rows.RemoveAt(e.RowIndex);

            }
            else
            {

            }
        }
    }
}
