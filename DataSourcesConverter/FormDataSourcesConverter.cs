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

        //Remove row button
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            DataGridView dg = dataGridView1;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && 
                dg.Rows[e.RowIndex].IsNewRow == false)
            {
                //TODO - Button Clicked - Execute Code Here                              
                dg.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void buttonRunFlow_Click(object sender, EventArgs e)
        {
            DataGridView dg = dataGridView1;

            foreach (DataGridViewRow row in dg.Rows)
            {
                if (row.IsNewRow == false)
                {
                    MessageBox.Show(row.Cells["PathInput"].Value.ToString());
                }                
            }
        }
    }
}
