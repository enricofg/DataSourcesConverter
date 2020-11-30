namespace DataSourcesConverter
{
    partial class FormDataSourcesConverter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonRunFlow = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSaveFlow = new System.Windows.Forms.Button();
            this.buttonLoadFlow = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.Input = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RESTtype = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PathInput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResourcePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PathOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonAddConfig = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRunFlow
            // 
            this.buttonRunFlow.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonRunFlow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRunFlow.ForeColor = System.Drawing.Color.FloralWhite;
            this.buttonRunFlow.Location = new System.Drawing.Point(663, 373);
            this.buttonRunFlow.Name = "buttonRunFlow";
            this.buttonRunFlow.Size = new System.Drawing.Size(141, 32);
            this.buttonRunFlow.TabIndex = 2;
            this.buttonRunFlow.Text = "Run Flow";
            this.buttonRunFlow.UseVisualStyleBackColor = false;
            this.buttonRunFlow.Click += new System.EventHandler(this.buttonRunFlow_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Input,
            this.RESTtype,
            this.PathInput,
            this.ResourcePath,
            this.Output,
            this.PathOutput,
            this.ButtonAddConfig});
            this.dataGridView.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dataGridView.Location = new System.Drawing.Point(26, 63);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(778, 295);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellValueChanged);
            this.dataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_RowValidating);
            // 
            // buttonSaveFlow
            // 
            this.buttonSaveFlow.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonSaveFlow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSaveFlow.ForeColor = System.Drawing.Color.FloralWhite;
            this.buttonSaveFlow.Location = new System.Drawing.Point(26, 373);
            this.buttonSaveFlow.Name = "buttonSaveFlow";
            this.buttonSaveFlow.Size = new System.Drawing.Size(73, 32);
            this.buttonSaveFlow.TabIndex = 4;
            this.buttonSaveFlow.Text = "Save Flow";
            this.buttonSaveFlow.UseVisualStyleBackColor = false;
            this.buttonSaveFlow.Click += new System.EventHandler(this.buttonSaveFlow_Click);
            // 
            // buttonLoadFlow
            // 
            this.buttonLoadFlow.BackColor = System.Drawing.Color.Gray;
            this.buttonLoadFlow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLoadFlow.ForeColor = System.Drawing.Color.FloralWhite;
            this.buttonLoadFlow.Location = new System.Drawing.Point(105, 373);
            this.buttonLoadFlow.Name = "buttonLoadFlow";
            this.buttonLoadFlow.Size = new System.Drawing.Size(73, 32);
            this.buttonLoadFlow.TabIndex = 5;
            this.buttonLoadFlow.Text = "Load Flow";
            this.buttonLoadFlow.UseVisualStyleBackColor = false;
            this.buttonLoadFlow.Click += new System.EventHandler(this.buttonLoadFlow_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Crimson;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClear.ForeColor = System.Drawing.Color.FloralWhite;
            this.buttonClear.Location = new System.Drawing.Point(184, 373);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(73, 32);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Clear Flow";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddRow.ForeColor = System.Drawing.Color.FloralWhite;
            this.buttonAddRow.Location = new System.Drawing.Point(779, 32);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(25, 25);
            this.buttonAddRow.TabIndex = 7;
            this.buttonAddRow.Text = "+";
            this.buttonAddRow.UseVisualStyleBackColor = false;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "dataflow_config";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "dataflow_config";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // Input
            // 
            this.Input.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Input.HeaderText = "Input Type";
            this.Input.Items.AddRange(new object[] {
            "Excel File",
            "XML File",
            "RESTful API",
            "Broker"});
            this.Input.Name = "Input";
            // 
            // RESTtype
            // 
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.RESTtype.DefaultCellStyle = dataGridViewCellStyle1;
            this.RESTtype.FillWeight = 65F;
            this.RESTtype.HeaderText = "REST Type";
            this.RESTtype.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "DELETE"});
            this.RESTtype.Name = "RESTtype";
            this.RESTtype.ReadOnly = true;
            this.RESTtype.Visible = false;
            // 
            // PathInput
            // 
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.PathInput.DefaultCellStyle = dataGridViewCellStyle2;
            this.PathInput.HeaderText = "File Path / Base URL / IP";
            this.PathInput.Name = "PathInput";
            // 
            // ResourcePath
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.ResourcePath.DefaultCellStyle = dataGridViewCellStyle3;
            this.ResourcePath.FillWeight = 80F;
            this.ResourcePath.HeaderText = "Resource Path";
            this.ResourcePath.Name = "ResourcePath";
            this.ResourcePath.ReadOnly = true;
            // 
            // Output
            // 
            this.Output.HeaderText = "Output Type";
            this.Output.Items.AddRange(new object[] {
            "HTML Page",
            "RESTful API"});
            this.Output.Name = "Output";
            // 
            // PathOutput
            // 
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.PathOutput.DefaultCellStyle = dataGridViewCellStyle4;
            this.PathOutput.HeaderText = "Output: Path+Filename";
            this.PathOutput.Name = "PathOutput";
            // 
            // ButtonAddConfig
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = "Remove";
            this.ButtonAddConfig.DefaultCellStyle = dataGridViewCellStyle5;
            this.ButtonAddConfig.FillWeight = 75F;
            this.ButtonAddConfig.HeaderText = "";
            this.ButtonAddConfig.Name = "ButtonAddConfig";
            this.ButtonAddConfig.Text = "";
            // 
            // FormDataSourcesConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(843, 428);
            this.Controls.Add(this.buttonAddRow);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonLoadFlow);
            this.Controls.Add(this.buttonSaveFlow);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonRunFlow);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormDataSourcesConverter";
            this.Text = "Data Sources Converter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonRunFlow;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSaveFlow;
        private System.Windows.Forms.Button buttonLoadFlow;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Input;
        private System.Windows.Forms.DataGridViewComboBoxColumn RESTtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResourcePath;
        private System.Windows.Forms.DataGridViewComboBoxColumn Output;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathOutput;
        private System.Windows.Forms.DataGridViewButtonColumn ButtonAddConfig;
    }
}

