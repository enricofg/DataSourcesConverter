using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DataSourcesConverter
{
    public partial class FormDataSourcesConverter : Form
    {
        private const string C_EXCEL_FILE = "Excel File";
        private const string C_XML_FILE = "XML File";
        private const string C_RESTFUL_API = "RESTful API";
        private const string C_BROKER = "Broker";
        private const string C_HTML_PAGE = "HTML Page";
        private string[] validInputs = { C_EXCEL_FILE, C_XML_FILE, C_RESTFUL_API, C_BROKER };
        private string[] validOutputs = { C_HTML_PAGE, C_RESTFUL_API };

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

                    RunFlowRowItemOptions(inputOption, inputPath, outputOption, outputPath);
                }
            }
        }

        private static void RunFlowRowItemOptions(string inputOption, string inputPath, string outputOption, string outputPath)
        {
            if (inputOption == C_EXCEL_FILE)
            {
                try
                {
                    string readExcel = Excel_Lib.ExcelHandler.ReadFromExcelFile(inputPath);

                    MessageBox.Show("The define output path is " + outputPath + " and the read excel message is:\n" + readExcel);
                    WriteOutput(outputOption, outputPath, readExcel);                    
                }
                catch (Exception)
                {
                    MessageBox.Show("File at path \"" + inputPath + "\" not found!");
                }
            } else if(inputOption == C_XML_FILE)
            {
                try
                {
                    XMLHandler XMLHandler = new XMLHandler(inputPath);
                    List<string> infoXML = XMLHandler.GetXMLInfo();
                    string outputXML = "";

                    foreach(string item in infoXML)
                    {
                        outputXML += item;
                    }

                    WriteOutput(outputOption, outputPath, outputXML);
                }
                catch (Exception)
                {
                    MessageBox.Show("File at path \"" + inputPath + "\" not found!");
                }
            }
        }

        private static void WriteOutput(string outputOption, string outputPath, string readInfo)
        {
            try
            {
                if(outputOption == C_HTML_PAGE)
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw = new StreamWriter(outputPath + ".html");
                    //Write a line of text
                    sw.WriteLine(readInfo);
                    //Close the file
                    MessageBox.Show("HTML File "+ outputPath + ".html created!");
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Write error - Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {            
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            /*disable clicking of the remove button from other cells 
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
            e.Cancel = ValidateCells(inputCell, inputPathCell, outputCell, outputPathCell);
        }

        private Boolean ValidateCells(DataGridViewCell inputCell, DataGridViewCell inputPathCell, DataGridViewCell outputCell, DataGridViewCell outputPathCell)
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
