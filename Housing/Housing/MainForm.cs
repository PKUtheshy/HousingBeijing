using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;

namespace Housing
{
    public sealed partial class MainForm : Form
    {
        #region class private members
        private IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;
        #endregion

        #region class constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// 加载主窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;
            //默认地图路径
            string mxd_path = @"D:\MyProject\map\";
            string mxd_filename = @"beijing.mxd";
            //打开默认地图
            axMapControl1.LoadMxFile(mxd_path + mxd_filename, 0, Type.Missing);
            axMapControl1.Extent = axMapControl1.FullExtent;
            //disable the Save menu (since there is no document yet)
            menuSaveDoc.Enabled = false;
        }

        #region 文件菜单事件
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            //execute Open Document command
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
        {
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;

            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName);
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        #region 查询菜单事件
        
        /// <summary>
        /// 按小区名查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开按小区名查询窗口
            SearchByName sbnForm = new SearchByName(axMapControl1);
            sbnForm.Show();
        }

        /// <summary>
        /// 按房价查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchByPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开按价格查询窗口
            SearchByPrice sbpForm = new SearchByPrice(axMapControl1);
            sbpForm.Show();
        }

        /// <summary>
        /// 查询周围设施点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchPOIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开查询设施点窗口
            SearchPOI spoiForm = new SearchPOI(axMapControl1);
            spoiForm.Show();
        }

        #endregion

        /// <summary>
        /// 清除选择要素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.axMapControl1.Map.ClearSelection();
            axMapControl1.Refresh();
        }

        /// <summary>
        /// 相关信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Housing Beijing System\n Author:hzc\n mail:2000012520@stu.pku.edu.cn";
            MessageBox.Show(text);
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitForm exitform = new ExitForm(this);
            exitform.Show();
        }
    }
}