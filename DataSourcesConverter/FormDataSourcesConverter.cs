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
                    MessageBox.Show(
                        "Row #"+(row.Index+1)+":\n" +
                        "Chosen input is: " + row.Cells["Input"].Value.ToString()+"\n"+
                        "Chosen input path is: " + row.Cells["PathInput"].Value.ToString() + "\n" +
                        "Chosen output is: " + row.Cells["Output"].Value.ToString() + "\n" +
                        "Chosen output path is: " + row.Cells["PathOutput"].Value.ToString() + "\n" 
                        );
                }                
            }
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            DataGridViewCell inputCell = row.Cells["Input"];
            DataGridViewCell inputPathCell = row.Cells["PathInput"];
            DataGridViewCell outputCell = row.Cells["Output"];
            DataGridViewCell outputPathCell = row.Cells["PathOutput"];
            e.Cancel = validateCells(inputCell, inputPathCell, outputCell, outputPathCell);
        }

        private Boolean validateCells(DataGridViewCell inputCell, DataGridViewCell inputPathCell, DataGridViewCell outputCell, DataGridViewCell outputPathCell)
        {
            if (inputCell.Value != null && inputPathCell.Value != null && outputCell.Value != null && outputPathCell.Value != null)
            {
                return false;
            }

            return true;
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Data source configuration added!");
        }
    }
}
