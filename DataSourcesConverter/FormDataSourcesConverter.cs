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
        private string[] validRESTTypes = { "GET", "POST", "PUT", "DELETE" };

        public FormDataSourcesConverter()
        {
            InitializeComponent();
        }

        //Remove row button
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            DataGridView dg = dataGridView;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && 
                dg.Rows[e.RowIndex].IsNewRow == false)
            {
                //TODO - Button Clicked - Execute Code Here                              
                dg.Rows.RemoveAt(e.RowIndex);
            }
        }


        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            DataGridView dg = dataGridView;

            if(senderGrid.Rows.Count > 0)
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn &&
                e.ColumnIndex == 0)
                {
                    DataGridViewCell dgRestTypeCell = dg.Rows[e.RowIndex].Cells["RESTtype"];
                    DataGridViewCell dgRestResourcePathCell = dg.Rows[e.RowIndex].Cells["ResourcePath"];

                    if (dg.Rows[e.RowIndex].Cells["Input"].Value.ToString() == C_RESTFUL_API)
                    {
                        ChangeCellStyle(dgRestTypeCell, false, Color.White, Color.Black); //enable
                        ChangeCellStyle(dgRestResourcePathCell, false, Color.White, Color.Black); //enable
                    }
                    else
                    {
                        dgRestTypeCell.Value = null; //disable selectedIndex value
                        ChangeCellStyle(dgRestTypeCell, true, Color.FromKnownColor(KnownColor.ControlLight), Color.FromKnownColor(KnownColor.ControlLight)); //disable
                        ChangeCellStyle(dgRestResourcePathCell, true, Color.FromKnownColor(KnownColor.ControlLight), Color.FromKnownColor(KnownColor.ControlLight)); //disable
                    }
                }
            }            
        }

        private void buttonRunFlow_Click(object sender, EventArgs e)
        {
            DataGridView dg = dataGridView;

            foreach (DataGridViewRow row in dg.Rows)
            {
                if (row.IsNewRow == false && row.Cells[0].Value != null)
                {
                    string inputOption = row.Cells["Input"].Value.ToString();
                    string restType = "";
                    string inputPath = row.Cells["PathInput"].Value.ToString();
                    string resourcePath = "";
                    string outputOption = row.Cells["Output"].Value.ToString();
                    string outputPath = row.Cells["PathOutput"].Value.ToString();

                    if(row.Cells["Input"].Value.ToString() == C_RESTFUL_API)
                    {
                        restType = row.Cells["RESTtype"].Value.ToString();
                        resourcePath = row.Cells["ResourcePath"].Value.ToString();
                    }

                    MessageBox.Show(
                        "Row #" + (row.Index + 1) + ":\n" +
                        "Chosen input is: " + inputOption + "\n" +
                        "Chosen input path is: " + inputPath + "\n" +
                        "Chosen output is: " + outputOption + "\n" +
                        "Chosen output path is: " + outputPath + "\n"
                        );

                    RunFlowRowItemOptions(inputOption, restType, inputPath, resourcePath, outputOption, outputPath);
                }
            }
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {            
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            DataGridViewCell inputCell = row.Cells["Input"];
            DataGridViewCell restTypeCell = row.Cells["RESTtype"];
            DataGridViewCell inputPathCell = row.Cells["PathInput"];
            DataGridViewCell resourcePathCell = row.Cells["ResourcePath"];
            DataGridViewCell outputCell = row.Cells["Output"];
            DataGridViewCell outputPathCell = row.Cells["PathOutput"];
            
            e.Cancel = ValidateCells(inputCell, restTypeCell, inputPathCell, resourcePathCell, outputCell, outputPathCell);
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Add();
        }

        #region Flow Configuration Controls
        private void buttonSaveFlow_Click(object sender, EventArgs e)
        {
            DataGridView dg = dataGridView;
            string file = "";

            saveFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.Filter = "xml files (*.bin)|*.bin";

            //se o utilizador selecionou o botão "OK"
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file = saveFileDialog1.FileName;
            }
            
            if (dataGridView.Rows.Count != 0 && file != "")
            {
                try
                {
                    //source: https://stackoverflow.com/questions/2952161/c-sharp-saving-a-datagridview-to-file-and-loading
                    using (BinaryWriter bw = new BinaryWriter(File.Open(file, FileMode.Create)))
                    {
                        bw.Write(dg.Columns.Count);
                        bw.Write(dg.Rows.Count);
                        foreach (DataGridViewRow row in dg.Rows)
                        {
                            if (row.IsNewRow == false) ///TODO: only save valid cells
                            {
                                for (int j = 0; j < dg.Columns.Count; ++j)
                                {
                                    object val = row.Cells[j].Value;
                                    if (val == null)
                                    {
                                        bw.Write(false);
                                        bw.Write(false);
                                    }
                                    else
                                    {
                                        bw.Write(true);
                                        bw.Write(val.ToString());
                                    }
                                }
                            }
                        }
                    }

                    MessageBox.Show("Flow configuration saved!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error saving flow configuration!");
                }
            }
            else
            {
                MessageBox.Show("Cannot save configuration! \nThe file must have a name and the data flow must not be empty.");
            }
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            if(dataGridView.DataSource != null)
            {
                dataGridView.DataSource = null;
                dataGridView.Rows.Clear();
                dataGridView.Refresh();
            }
        }

        private void buttonLoadFlow_Click(object sender, EventArgs e)
        {
            DataGridView dg = dataGridView; 
            string file = "";

            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "xml files (*.bin)|*.bin";

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
                dg.Rows.Clear();

                using (BinaryReader bw = new BinaryReader(File.Open(file, FileMode.Open)))
                {
                    int n = bw.ReadInt32();
                    int m = bw.ReadInt32();
                    for (int i = 0; i < m; ++i)
                    {
                        dg.Rows.Add();
                        for (int j = 0; j < n; ++j)
                        {
                            if (bw.ReadBoolean())
                            {
                                dg.Rows[i].Cells[j].Value = bw.ReadString();
                            }
                            else bw.ReadBoolean();
                        }
                    }
                }

                MessageBox.Show("Data flow configuration loaded!");
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading flow configuration!");
            }
        }
        #endregion

        private Boolean ValidateCells(DataGridViewCell inputCell, DataGridViewCell restTypeCell, DataGridViewCell inputPathCell, 
                                      DataGridViewCell resourcePathCell, DataGridViewCell outputCell, DataGridViewCell outputPathCell)
        {
            if (validInputs.Contains(inputCell.Value) && validOutputs.Contains(outputCell.Value) && inputPathCell.Value != null && outputPathCell.Value != null)
            {
                if (inputCell.Value.ToString() == C_RESTFUL_API && (!validRESTTypes.Contains(restTypeCell.Value) || resourcePathCell.Value == null))                  
                {
                    return true;
                }

                return false;
            }

            return true;
        }

        //"Disable" a cell, source: https://stackoverflow.com/questions/629107/enabling-and-disabling-a-cell-in-a-datagridview/5291514
        private static void ChangeCellStyle(DataGridViewCell dataGridViewCell, Boolean option, Color backColor, Color foreColor)
        {
            dataGridViewCell.ReadOnly = option;
            dataGridViewCell.Style.BackColor = backColor;
            dataGridViewCell.Style.ForeColor = foreColor;
        }

        private static void RunFlowRowItemOptions(string inputOption, string restType, string inputPath, string resourcePath, string outputOption, string outputPath)
        {
            if (inputOption == C_EXCEL_FILE)
            {
                try
                {
                    string readExcel = Excel_Lib.ExcelHandler.ReadFromExcelFile(inputPath);
                    //MessageBox.Show("The define output path is " + outputPath + " and the read excel message is:\n" + readExcel);
                    WriteOutput(outputOption, outputPath, readExcel);
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
                    List<string> infoXML = XMLHandler.GetXMLInfo();
                    string outputXML = "";

                    foreach (string item in infoXML)
                    {
                        outputXML += item;
                    }

                    WriteOutput(outputOption, outputPath, outputXML);
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
                    var request = new RestSharp.RestRequest(resourcePath, RestSharp.Method.GET);

                    var response = client.Execute(request).Content;
                    MessageBox.Show("The REST request was made to: \n"+ inputPath+"\nThe response is:\n"+ response);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error requesting: "+inputPath+" at "+resourcePath);
                }               

            } else
            {
                //MQTT broker
            }
        }

        private static void WriteOutput(string outputOption, string outputPath, string readInfo)
        {
            try
            {
                if (outputOption == C_HTML_PAGE)
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw = new StreamWriter(outputPath + ".html");
                    //Write a line of text
                    sw.WriteLine(readInfo);
                    //Close the file
                    MessageBox.Show("HTML File " + outputPath + ".html created!");
                    sw.Close();
                }
                else
                {
                    //output em REST
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
    }
}
