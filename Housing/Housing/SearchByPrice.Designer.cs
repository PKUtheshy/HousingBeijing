namespace Housing
{
    partial class SearchByPrice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownHigh = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownLow = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.dataHouseTable = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataHouseTable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numericUpDownHigh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericUpDownLow);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxRegion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(121, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 265);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "上限：";
            // 
            // numericUpDownHigh
            // 
            this.numericUpDownHigh.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownHigh.Location = new System.Drawing.Point(180, 162);
            this.numericUpDownHigh.Maximum = new decimal(new int[] {
            250000,
            0,
            0,
            0});
            this.numericUpDownHigh.Name = "numericUpDownHigh";
            this.numericUpDownHigh.Size = new System.Drawing.Size(232, 35);
            this.numericUpDownHigh.TabIndex = 7;
            this.numericUpDownHigh.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericUpDownHigh.ValueChanged += new System.EventHandler(this.numericUpDownHigh_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "下限：";
            // 
            // numericUpDownLow
            // 
            this.numericUpDownLow.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownLow.Location = new System.Drawing.Point(180, 114);
            this.numericUpDownLow.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.numericUpDownLow.Name = "numericUpDownLow";
            this.numericUpDownLow.Size = new System.Drawing.Size(232, 35);
            this.numericUpDownLow.TabIndex = 5;
            this.numericUpDownLow.ValueChanged += new System.EventHandler(this.numericUpDownLow_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "房价(元/平方米)";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(180, 29);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(368, 32);
            this.comboBoxRegion.TabIndex = 3;
            this.comboBoxRegion.SelectedIndexChanged += new System.EventHandler(this.comboBoxRegion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "小区范围：";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(189, 913);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(160, 50);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(479, 913);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(168, 50);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // dataHouseTable
            // 
            this.dataHouseTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataHouseTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataHouseTable.Location = new System.Drawing.Point(81, 370);
            this.dataHouseTable.Name = "dataHouseTable";
            this.dataHouseTable.Size = new System.Drawing.Size(703, 505);
            this.dataHouseTable.TabIndex = 7;
            this.dataHouseTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataHouseTable_CellClick);
            // 
            // SearchByPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 1277);
            this.Controls.Add(this.dataHouseTable);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.panel1);
            this.Name = "SearchByPrice";
            this.Text = "根据房价查询";
            this.Load += new System.EventHandler(this.SearchByPrice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataHouseTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownHigh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownLow;
        private System.Windows.Forms.DataGridView dataHouseTable;
    }
}