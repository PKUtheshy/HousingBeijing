using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace Housing
{
    public partial class SearchByName : Form
    {
        private string inputHouseName = ""; //输入小区名称
        private string SQLbyName = "";      //SQL查询语句
        //主窗口
        private AxMapControl mMapControl;   
        //选中图层
        private IFeatureLayer mFeatureLayer;    
        //根据选择图层查询到的特征类
        private IFeatureClass pFeatureClass = null;

        public SearchByName(AxMapControl sMapControl)
        {
            InitializeComponent();
            this.mMapControl = sMapControl;
            mFeatureLayer = mMapControl.get_Layer(1) as IFeatureLayer;
        }

        #region 控件事件

        /// <summary>
        /// 获取输入小区名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_housename_TextChanged(object sender, EventArgs e)
        {
            inputHouseName = textBox_housename.Text;
            SQLbyName = "\"name\" like '%" + inputHouseName + "%'";
        }

        /// <summary>
        /// 执行查询结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            ShowOnMap(SQLbyName);
            ShowOnTable(mFeatureLayer, SQLbyName);
            //ShowAttributes(mFeatureLayer, dataHouseTable);
        }

        /// <summary>
        /// 执行查询结果并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ShowOnMap(SQLbyName);
            this.Close();
        }

        /// <summary>
        /// 选中行单独高亮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataHouseTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>0)
            {
                // 获取当前选中行的name
                string nameValue = dataHouseTable.Rows[e.RowIndex].Cells["name"].Value.ToString();
                SQLbyName = "\"name\" = '" + nameValue + "'";
                //查询此要素，但不更新表
                //ShowOnMap(SQLbyName);
                #region 缩放到查询结果
                //清除查询结果
                mMapControl.Map.ClearSelection();
                IActiveView pActivaView = mMapControl.Map as IActiveView;
                //设置过滤条件
                IQueryFilter pQueryFilter = new QueryFilterClass();
                pQueryFilter.WhereClause = SQLbyName;   //SQL语句
                //查询
                IFeatureCursor pFeatureCursor = mFeatureLayer.Search(pQueryFilter, false);
                //创建一个新的envelope对象用于缩放
                IEnvelope pEnvelope = new EnvelopeClass();
                //获取查询要素
                IFeature pFeature = pFeatureCursor.NextFeature();
                //选择要素
                mMapControl.Map.SelectFeature(mFeatureLayer, pFeature);
                //将要素的几何体合并到envelope中
                IGeometry pGeometry = pFeature.ShapeCopy;
                pEnvelope.Union(pGeometry.Envelope);
                mMapControl.CenterAt(pEnvelope.LowerLeft);
                mMapControl.MapScale = 10000.00;
                pActivaView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                pActivaView.Refresh();
                #endregion
            }
        }
        #endregion

        #region 私有函数

        //查询结果在地图上显示
        private void ShowOnMap(string sql)
        {
            try
            {
                //清除查询结果
                mMapControl.Map.ClearSelection();
                IActiveView pActivaView = mMapControl.Map as IActiveView;
                //设置过滤条件
                IQueryFilter pQueryFilter = new QueryFilterClass();
                pQueryFilter.WhereClause = sql;   //SQL语句
                //查询
                IFeatureCursor pFeatureCursor = mFeatureLayer.Search(pQueryFilter, false);
                //创建一个新的envelope对象用于缩放
                IEnvelope pEnvelope = new EnvelopeClass();
                bool bHasFeatures = false;
                int featureCount = 0;
                //获取查询要素
                IFeature pFeature = pFeatureCursor.NextFeature();
                //判断是否获取到要素
                while (pFeature != null)
                {
                    bHasFeatures = true;
                    featureCount++;
                    mMapControl.Map.SelectFeature(mFeatureLayer, pFeature); //选择要素
                    mMapControl.Extent = pFeature.Shape.Envelope;   //放大到要素
                    //将要素的几何体合并到envelope中
                    IGeometry pGeometry = pFeature.ShapeCopy;
                    pEnvelope.Union(pGeometry.Envelope);

                    pFeature = pFeatureCursor.NextFeature();
                }
                if (bHasFeatures == true)
                {
                    if (featureCount == 1)
                        mMapControl.CenterAt(pEnvelope.LowerLeft);
                    else
                    {
                        //调整envelope的大小，确保要素可见
                        pEnvelope.Expand(1.5, 1.5, true);
                        //缩放到envelope所表示的范围
                        mMapControl.Extent = pEnvelope;
                    }
                }
                pActivaView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                pActivaView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //查询结果信息在表上显示
        private void ShowOnTable(IFeatureLayer featureLayer, string sql)
        {
            //设置过滤条件
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.WhereClause = sql;   //SQL语句
            IFeatureCursor pFeatureCursor = featureLayer.Search(pQueryFilter, false);
            IFeature pFeature = null;

            //构造dataTable并添加列
            DataTable dTable = new DataTable();
            dTable.Columns.Add("name", typeof(string));
            dTable.Columns.Add("count", typeof(int));
            dTable.Columns.Add("price", typeof(int));
            dTable.Columns.Add("地名", typeof(string));

            //遍历查询结果中的要素，将字段添加到table
            while((pFeature=pFeatureCursor.NextFeature())!=null)
            {
                DataRow dRow = dTable.NewRow();
                dRow["name"] = pFeature.get_Value(pFeature.Fields.FindField("name"));
                dRow["count"] = pFeature.get_Value(pFeature.Fields.FindField("count"));
                dRow["price"] = pFeature.get_Value(pFeature.Fields.FindField("price"));
                dRow["地名"] = pFeature.get_Value(pFeature.Fields.FindField("地名"));
                dTable.Rows.Add(dRow);
            }
            //数据在表中显示
            dataHouseTable.DataSource = dTable;
        }

        //把要素图层中的所有name字段列出来，检查错误用
        private void ShowAttributes(IFeatureLayer sFeatureLayer, DataGridView dataGridView)
        {
            ITable attributeTable;
            if (sFeatureLayer != null)
            {
                attributeTable = sFeatureLayer as ITable;
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("name", typeof(string));

                // 查询所有要素
                ICursor cursor = attributeTable.Search(null, false);
                IRow row = cursor.NextRow();
                while (row != null)
                {
                    // 获取 "name" 字段的值
                    object nameValue = row.get_Value(attributeTable.FindField("name"));

                    // 创建新行并添加到 DataTable
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["name"] = nameValue;
                    dataTable.Rows.Add(dataRow);

                    row = cursor.NextRow();
                }

                // 将 DataTable 设置为 DataGridView 的数据源
                dataGridView.DataSource = dataTable;
            }
        }

        #endregion
    }
}
