using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace DataSourcesConverter
{
    public partial class FormDataSourcesConverter : Form
    {
        private const string C_EXCEL_FILE = "Excel File";
        private const string C_XML_FILE = "XML File";
        private const string C_RESTFUL_API = "RESTful API";
        private const string C_HTML_PAGE = "HTML Page";
        private string[] validInputs = { C_EXCEL_FILE, C_XML_FILE, C_RESTFUL_API };
        private string[] validOutputs = { C_HTML_PAGE, C_RESTFUL_API };
        private DataGridView dg = new DataGridView();

        public FormDataSourcesConverter()
        {
            InitializeComponent();
        }

        //Remove row button
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            dg = dataGridView;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && 
                dg.Rows[e.RowIndex].IsNewRow == false)
            {
                //confirm deletion?
                /*var result = MessageBox.Show("Are you sure you want to delete the row?", "Are you sure?", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK) { }*/
                dg.Rows.RemoveAt(e.RowIndex);
            }
        }


        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            dg = dataGridView;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn &&
                (e.ColumnIndex == 1 || e.ColumnIndex == 3)) //&& dg.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode == true
            {
                string filepath;

                openFileDialog1.InitialDirectory = Application.StartupPath;
                openFileDialog1.Filter = "xml files (*.xml)|*.xml";

                //se o utilizador selecionou o botão "OK"
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filepath = openFileDialog1.FileName;
                }
                else
                {
                    return;
                }

                dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = filepath;
            }
        }

        private void buttonRunFlow_Click(object sender, EventArgs e)
        {
            dg = dataGridView;

            foreach (DataGridViewRow row in dg.Rows)
            {
                if (row.IsNewRow == false && row.Cells[0].Value != null)
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

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {            
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            DataGridViewCell inputCell = row.Cells["Input"];
            DataGridViewCell inputPathCell = row.Cells["PathInput"];
            DataGridViewCell outputCell = row.Cells["Output"];
            DataGridViewCell outputPathCell = row.Cells["PathOutput"];
            
            e.Cancel = ValidateCells(inputCell, inputPathCell, outputCell, outputPathCell);
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Add();
        }

        //save flow in .xml and validate with .xsd
        #region Flow Configuration Controls
        private void buttonSaveFlow_Click(object sender, EventArgs e)
        {
            dg = dataGridView;
            string file;

            saveFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";

            if(dg.Rows.Count == 0)
            {
                MessageBox.Show("Cannot save empty flow configuration.");
                return;
            }

            //se o utilizador selecionou o botão "OK"
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file = saveFileDialog1.FileName;
            }
            else
            {
                return;
            }

            try
            {  
                DataTable dt = GetDataTableFromDGV(dg);
                DataSet ds = new DataSet();
                ds.DataSetName = "flow";
                ds.Tables.Add(dt);
                ds.WriteXml(file);

                MessageBox.Show("Flow configuration saved!");
            }
            catch (Exception)
            {
                MessageBox.Show("Error saving flow configuration!");
            }
        }

        private void buttonLoadFlow_Click(object sender, EventArgs e)
        {
            dg = dataGridView; 
            string file;

            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";

            //se o utilizador selecionou o botão "OK"
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file = openFileDialog1.FileName;
            }
            else
            {
                return;
            }

            try
            {
                ResetDataGridView();

                XMLHandler XMLHandler = new XMLHandler(file);
                if(XMLHandler.ValidateXML() == false)
                {
                    MessageBox.Show(XMLHandler.ValidationMessage);
                    return;
                }

                DataSet ds = new DataSet();
                ds.ReadXml(file);
                DataTable dt = ds.Tables[0];
                int i = 0;

                foreach (DataRow flowRow in dt.Rows)
                {
                    dg.Rows.Add();
                    dg.Rows[i].Cells[0].Value = flowRow.ItemArray[0].ToString();
                    dg.Rows[i].Cells[1].Value = flowRow.ItemArray[1].ToString();
                    dg.Rows[i].Cells[2].Value = flowRow.ItemArray[2].ToString();
                    dg.Rows[i].Cells[3].Value = flowRow.ItemArray[3].ToString();
                    i++;
                }

                MessageBox.Show("Data flow configuration loaded!");
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading flow configuration!");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ResetDataGridView();
        }
        #endregion

        private bool ValidateCells(DataGridViewCell inputCell, DataGridViewCell inputPathCell, DataGridViewCell outputCell, DataGridViewCell outputPathCell)
        {
            if (validInputs.Contains(inputCell.Value) && validOutputs.Contains(outputCell.Value) && inputPathCell.Value != null && outputPathCell.Value != null)
            {
                return false;
            }

            return true;
        }

        private void ResetDataGridView()
        {
            while (dataGridView.Rows.Count != 0) 
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {                   
                    dataGridView.Rows.Remove(row);
                }
            }            
            dataGridView.DataSource = null;            
            dataGridView.Refresh();            
        }

        private static void RunFlowRowItemOptions(string inputOption, string inputPath, string outputOption, string outputPath)
        {
            if (inputOption == C_EXCEL_FILE)
            {
                try
                {
                    string readExcel = Excel_Lib.ExcelHandler.ReadFromExcelFile(inputPath);
                    //MessageBox.Show("The define output path is " + outputPath + " and the read excel message is:\n" + readExcel);
                    WriteHTMLOutput(outputPath, readExcel);
                }
                catch (Exception)
                {
                    MessageBox.Show("File at path \"" + inputPath + "\" not found!");
                }
            }
            else if (inputOption == C_XML_FILE)
            {
                try
                {
                    XMLHandler XMLHandler = new XMLHandler(inputPath);
                    if (outputOption == C_HTML_PAGE)
                    {
                        string htmlFromXML = XMLHandler.GetXMLString();

                        WriteHTMLOutput(outputPath, XMLHandler.ConvertXmlToHtmlTable(htmlFromXML));
                    }
                    else
                    {
                        //REST
                        MessageBox.Show(XMLHandler.XMLToJson());
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("File at path \"" + inputPath + "\" not found!");
                }
               
            } else if (inputOption == C_RESTFUL_API)
            {
                try
                {
                    var client = new RestSharp.RestClient(inputPath);
                    var request = new RestSharp.RestRequest(inputPath, RestSharp.Method.GET);

                    var response = client.Execute(request).Content;
                    MessageBox.Show("The REST request was made to: \n"+ inputPath+"\nThe response is:\n"+ response);
                    WriteHTMLOutput(outputPath, response);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error requesting: "+inputPath);
                }              

            } 
        }

        private static void WriteHTMLOutput(string outputPath, string readInfo)
        {
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(outputPath + ".html");
                //Write a line of text
                sw.WriteLine(readInfo);
                //Close the file
                MessageBox.Show("HTML File " + outputPath + ".html created!");
                sw.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Write error - Exception: " + e.Message);
            }
        }

        //source: https://social.msdn.microsoft.com/Forums/vstudio/en-US/e7c7c46d-344f-4265-837b-e68eea0ecce0/export-datagridview-to-xml-file-without-any-dataset-or-datatable-?forum=csharpgeneral
        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            dt.TableName = "flowRow";
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    dt.Columns.Add();
                }
            }

            dt.Columns[0].ColumnName = "inputType";
            dt.Columns[1].ColumnName = "inputLocation";
            dt.Columns[2].ColumnName = "outputType";
            dt.Columns[3].ColumnName = "outputLocation";

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }
    }

}
