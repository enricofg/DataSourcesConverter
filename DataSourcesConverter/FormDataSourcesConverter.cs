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
        private string[] validInputs = { "Excel File", "XML File", "RESTful API", "Broker" };
        private string[] validOutputs = { "HTML Page", "RESTful API" };        

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
                    string inputOption = row.Cells["Input"].Value.ToString();
                    string inputPath = row.Cells["PathInput"].Value.ToString();
                    string outputOption = row.Cells["Output"].Value.ToString();
                    string outputPath = row.Cells["PathOutput"].Value.ToString();

                    MessageBox.Show(
                        "Row #" + (row.Index + 1) + ":\n" +
                        "Chosen input is: " + inputOption + "\n" +
                        "Chosen input path is: " + inputPath + "\n" +
                        "Chosen output is: " + outputOption + "\n" +
                        "Chosen output path is: " + outputPath + "\n"
                        );

                    runFlowRowItemOptions(inputOption, inputPath, outputOption, outputPath);
                }
            }
        }

        private static void runFlowRowItemOptions(string inputOption, string inputPath, string outputOption, string outputPath)
        {
            if (inputOption == "Excel File")
            {
                try
                {
                    string readExcel = Excel_Lib.ExcelHandler.ReadFromExcelFile(inputPath);
                    if (outputOption == "HTML Page")
                    {
                        MessageBox.Show("The define output path is " + outputPath + " and the read excel message is: " + readExcel);

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("File at path \"" + inputPath + "\" not found!");
                }
            }
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {            
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            /* disable clicking of the remove button from other cells 
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if(!item.IsNewRow)
                {
                    item.DefaultCellStyle.BackColor = Color.LightGray; 
                }
            }*/

            DataGridViewCell inputCell = row.Cells["Input"];
            DataGridViewCell inputPathCell = row.Cells["PathInput"];
            DataGridViewCell outputCell = row.Cells["Output"];
            DataGridViewCell outputPathCell = row.Cells["PathOutput"];
            e.Cancel = validateCells(inputCell, inputPathCell, outputCell, outputPathCell);
        }

        private Boolean validateCells(DataGridViewCell inputCell, DataGridViewCell inputPathCell, DataGridViewCell outputCell, DataGridViewCell outputPathCell)
        {           
            if (validInputs.Contains(inputCell.Value) && validOutputs.Contains(outputCell.Value) && inputPathCell.Value != null && outputPathCell.Value != null)
            {
                return false;
            }

            return true;
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Data source configuration added!");
            /*DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            row.Cells["ButtonAddConfig"].Value="Remove";*/
            /*foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                item.DefaultCellStyle.BackColor = Color.White;                
            }*/
        }
    }
}
