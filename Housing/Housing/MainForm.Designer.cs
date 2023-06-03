namespace Housing
{
    partial class MainForm
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
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.searchHousesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchByNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchByPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchPOIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.searchHousesToolStripMenuItem,
            this.searchPOIsToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1718, 43);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDoc,
            this.menuOpenDoc,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.menuSeparator,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(65, 35);
            this.menuFile.Text = "File";
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuNewDoc.Image")));
            this.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(321, 38);
            this.menuNewDoc.Text = "New Document";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDoc.Image")));
            this.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(321, 38);
            this.menuOpenDoc.Text = "Open Document...";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveDoc.Image")));
            this.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(321, 38);
            this.menuSaveDoc.Text = "SaveDocument";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(321, 38);
            this.menuSaveAs.Text = "Save As...";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(318, 6);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(321, 38);
            this.menuExitApp.Text = "Exit";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // searchHousesToolStripMenuItem
            // 
            this.searchHousesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchByNameToolStripMenuItem,
            this.searchByPriceToolStripMenuItem});
            this.searchHousesToolStripMenuItem.Name = "searchHousesToolStripMenuItem";
            this.searchHousesToolStripMenuItem.Size = new System.Drawing.Size(188, 35);
            this.searchHousesToolStripMenuItem.Text = "SearchHouses";
            // 
            // searchByNameToolStripMenuItem
            // 
            this.searchByNameToolStripMenuItem.Name = "searchByNameToolStripMenuItem";
            this.searchByNameToolStripMenuItem.Size = new System.Drawing.Size(286, 38);
            this.searchByNameToolStripMenuItem.Text = "SearchByName";
            this.searchByNameToolStripMenuItem.Click += new System.EventHandler(this.searchByNameToolStripMenuItem_Click);
            // 
            // searchByPriceToolStripMenuItem
            // 
            this.searchByPriceToolStripMenuItem.Name = "searchByPriceToolStripMenuItem";
            this.searchByPriceToolStripMenuItem.Size = new System.Drawing.Size(286, 38);
            this.searchByPriceToolStripMenuItem.Text = "SearchByPrice";
            this.searchByPriceToolStripMenuItem.Click += new System.EventHandler(this.searchByPriceToolStripMenuItem_Click);
            // 
            // searchPOIsToolStripMenuItem
            // 
            this.searchPOIsToolStripMenuItem.Name = "searchPOIsToolStripMenuItem";
            this.searchPOIsToolStripMenuItem.Size = new System.Drawing.Size(156, 35);
            this.searchPOIsToolStripMenuItem.Text = "SearchPOIs";
            this.searchPOIsToolStripMenuItem.Click += new System.EventHandler(this.searchPOIsToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(84, 35);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(80, 35);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 43);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(6);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1718, 28);
            this.axToolbarControl1.TabIndex = 3;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTOCControl1.Location = new System.Drawing.Point(6, 71);
            this.axTOCControl1.Margin = new System.Windows.Forms.Padding(6);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(265, 975);
            this.axTOCControl1.TabIndex = 4;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(466, 278);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(6);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 71);
            this.splitter1.Margin = new System.Windows.Forms.Padding(6);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 1011);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY});
            this.statusStrip1.Location = new System.Drawing.Point(6, 1046);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1712, 36);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(111, 31);
            this.statusBarXY.Text = "Test 123";
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(271, 71);
            this.axMapControl1.Margin = new System.Windows.Forms.Padding(6);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(1447, 975);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1718, 1082);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "Housing Beijing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewDoc;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        private System.Windows.Forms.ToolStripMenuItem searchPOIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchHousesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchByNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchByPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

