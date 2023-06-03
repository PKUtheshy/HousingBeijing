namespace Housing
{
    partial class SearchPOI
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
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPOIType = new System.Windows.Forms.ComboBox();
            this.numericUpDownBuffer = new System.Windows.Forms.NumericUpDown();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStartPoint = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnGoto = new System.Windows.Forms.Button();
            this.dataPOITable = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxStart = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBuffer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataPOITable)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxPOIType);
            this.panel1.Controls.Add(this.numericUpDownBuffer);
            this.panel1.Controls.Add(this.textBoxName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(135, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 189);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "设施类型：";
            // 
            // comboBoxPOIType
            // 
            this.comboBoxPOIType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPOIType.FormattingEnabled = true;
            this.comboBoxPOIType.Location = new System.Drawing.Point(180, 128);
            this.comboBoxPOIType.Name = "comboBoxPOIType";
            this.comboBoxPOIType.Size = new System.Drawing.Size(300, 32);
            this.comboBoxPOIType.TabIndex = 7;
            this.comboBoxPOIType.SelectedIndexChanged += new System.EventHandler(this.comboBoxPOIType_SelectedIndexChanged);
            // 
            // numericUpDownBuffer
            // 
            this.numericUpDownBuffer.Location = new System.Drawing.Point(180, 78);
            this.numericUpDownBuffer.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownBuffer.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownBuffer.Name = "numericUpDownBuffer";
            this.numericUpDownBuffer.Size = new System.Drawing.Size(300, 35);
            this.numericUpDownBuffer.TabIndex = 6;
            this.numericUpDownBuffer.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(180, 29);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(300, 35);
            this.textBoxName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "查询范围：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "小区名称：";
            // 
            // textBoxStartPoint
            // 
            this.textBoxStartPoint.Location = new System.Drawing.Point(283, 899);
            this.textBoxStartPoint.Name = "textBoxStartPoint";
            this.textBoxStartPoint.Size = new System.Drawing.Size(400, 35);
            this.textBoxStartPoint.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 904);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "输入起点：";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(151, 1039);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(193, 50);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "查询";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnGoto
            // 
            this.btnGoto.Location = new System.Drawing.Point(478, 1039);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(193, 50);
            this.btnGoto.TabIndex = 8;
            this.btnGoto.Text = "去这里";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // dataPOITable
            // 
            this.dataPOITable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPOITable.Location = new System.Drawing.Point(92, 280);
            this.dataPOITable.Name = "dataPOITable";
            this.dataPOITable.RowTemplate.Height = 37;
            this.dataPOITable.Size = new System.Drawing.Size(669, 591);
            this.dataPOITable.TabIndex = 9;
            this.dataPOITable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataPOITable_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 952);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "起点类型：";
            // 
            // comboBoxStart
            // 
            this.comboBoxStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStart.FormattingEnabled = true;
            this.comboBoxStart.Location = new System.Drawing.Point(283, 948);
            this.comboBoxStart.Name = "comboBoxStart";
            this.comboBoxStart.Size = new System.Drawing.Size(278, 32);
            this.comboBoxStart.TabIndex = 11;
            this.comboBoxStart.SelectedIndexChanged += new System.EventHandler(this.comboBoxStart_SelectedIndexChanged);
            // 
            // SearchPOI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 1179);
            this.Controls.Add(this.comboBoxStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataPOITable);
            this.Controls.Add(this.btnGoto);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxStartPoint);
            this.Controls.Add(this.panel1);
            this.Name = "SearchPOI";
            this.Text = "查询设施点";
            this.Load += new System.EventHandler(this.SearchPOI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBuffer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataPOITable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDownBuffer;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPOIType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxStartPoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.DataGridView dataPOITable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxStart;
    }
}