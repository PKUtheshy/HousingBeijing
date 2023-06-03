namespace Housing
{
    partial class SearchByName
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
            this.textBox_housename = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.dataHouseTable = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataHouseTable)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_housename
            // 
            this.textBox_housename.Location = new System.Drawing.Point(160, 57);
            this.textBox_housename.Name = "textBox_housename";
            this.textBox_housename.Size = new System.Drawing.Size(400, 35);
            this.textBox_housename.TabIndex = 0;
            this.textBox_housename.TextChanged += new System.EventHandler(this.textBox_housename_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_housename);
            this.panel1.Location = new System.Drawing.Point(114, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 157);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "小区名称：";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(457, 706);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(168, 50);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(176, 709);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(160, 50);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // dataHouseTable
            // 
            this.dataHouseTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataHouseTable.Location = new System.Drawing.Point(69, 210);
            this.dataHouseTable.Name = "dataHouseTable";
            this.dataHouseTable.ReadOnly = true;
            this.dataHouseTable.RowTemplate.Height = 37;
            this.dataHouseTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataHouseTable.Size = new System.Drawing.Size(711, 468);
            this.dataHouseTable.TabIndex = 5;
            this.dataHouseTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataHouseTable_CellClick);
            // 
            // SearchByName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 804);
            this.Controls.Add(this.dataHouseTable);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.panel1);
            this.Name = "SearchByName";
            this.Text = "小区查询";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataHouseTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_housename;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DataGridView dataHouseTable;
    }
}