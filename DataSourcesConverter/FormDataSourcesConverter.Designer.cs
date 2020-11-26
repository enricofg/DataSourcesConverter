﻿namespace DataSourcesConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataSourcesConverter));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRunFlow = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Input = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PathInput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Output = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PathOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonAddConfig = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // buttonRunFlow
            // 
            this.buttonRunFlow.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonRunFlow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRunFlow.ForeColor = System.Drawing.Color.FloralWhite;
            this.buttonRunFlow.Location = new System.Drawing.Point(478, 373);
            this.buttonRunFlow.Name = "buttonRunFlow";
            this.buttonRunFlow.Size = new System.Drawing.Size(112, 32);
            this.buttonRunFlow.TabIndex = 2;
            this.buttonRunFlow.Text = "Run Flow";
            this.buttonRunFlow.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Input,
            this.PathInput,
            this.Output,
            this.PathOutput,
            this.ButtonAddConfig});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.dataGridView1.Location = new System.Drawing.Point(26, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(564, 295);
            this.dataGridView1.TabIndex = 3;
            // 
            // Input
            // 
            this.Input.HeaderText = "Input";
            this.Input.Items.AddRange(new object[] {
            "Excel File",
            "XML File",
            "RESTful API",
            "Broker"});
            this.Input.Name = "Input";
            // 
            // PathInput
            // 
            this.PathInput.HeaderText = "Input Path";
            this.PathInput.Name = "PathInput";
            // 
            // Output
            // 
            this.Output.HeaderText = "Output";
            this.Output.Items.AddRange(new object[] {
            "HTML page",
            "RESTful API"});
            this.Output.Name = "Output";
            // 
            // PathOutput
            // 
            this.PathOutput.HeaderText = "Output Path";
            this.PathOutput.Name = "PathOutput";
            // 
            // ButtonAddConfig
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "Remove";
            this.ButtonAddConfig.DefaultCellStyle = dataGridViewCellStyle1;
            this.ButtonAddConfig.HeaderText = "Config";
            this.ButtonAddConfig.Name = "ButtonAddConfig";
            this.ButtonAddConfig.Text = "Add";
            // 
            // FormDataSourcesConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(619, 428);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonRunFlow);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDataSourcesConverter";
            this.Text = "Data Sources Converter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRunFlow;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Input;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathInput;
        private System.Windows.Forms.DataGridViewComboBoxColumn Output;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathOutput;
        private System.Windows.Forms.DataGridViewButtonColumn ButtonAddConfig;
    }
}

