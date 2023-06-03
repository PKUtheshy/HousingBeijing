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
    public partial class SearchByPrice : Form
    {
        private string SQLbyName = "";      //SQL查询语句
        //主窗口
        private AxMapControl mMapControl;
        //选中图层
        private IFeatureLayer mFeatureLayer;
        //根据选择图层查询到的特征类
        private IFeatureClass pFeatureClass = null;

        public SearchByPrice(AxMapControl sMapControl)
        {
            InitializeComponent();
            this.mMapControl = sMapControl;
            mFeatureLayer = mMapControl.get_Layer(1) as IFeatureLayer;
        }

        //加载窗体
        private void SearchByPrice_Load(object sender, EventArgs e)
        {
            //下拉框加载选项
            comboBoxRegion.Items.Add("全部");
            comboBoxRegion.Items.Add("东城区");
            comboBoxRegion.Items.Add("西城区");
            comboBoxRegion.Items.Add("海淀区");
            comboBoxRegion.Items.Add("朝阳区");
            comboBoxRegion.Items.Add("丰台区");
            comboBoxRegion.Items.Add("石景山区");
            comboBoxRegion.Items.Add("昌平区");
            comboBoxRegion.SelectedIndex = 0;
        }

        #region 控件事件
        /// <summary>
        /// 选择行政区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (numericUpDownHigh.Value < numericUpDownLow.Value)
            {
                MessageBox.Show("范围有误，请重新输入！");
                return;
            }
            SQLbyName = GetSqlText();
        }

        /// <summary>
        /// 修改房价上限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownHigh_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownHigh.Value < numericUpDownLow.Value)
            {
                MessageBox.Show("范围有误，请重新输入！");
                return;
            }
            SQLbyName = GetSqlText();
        }

        /// <summary>
        /// 修改房价下限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownLow_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownHigh.Value < numericUpDownLow.Value)
            {
                MessageBox.Show("范围有误，请重新输入！");
                return;
            }
            SQLbyName = GetSqlText();
        }

        /// <summary>
        /// 应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            ShowOnMap(SQLbyName);
            ShowOnTable(mFeatureLayer, SQLbyName);
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ShowOnMap(SQLbyName);
            //ShowOnTable(mFeatureLayer, SQLbyName);
            this.Close();
        }
        
        /// <summary>
        /// 单独查看某一行信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataHouseTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                // 获取当前选中行的name
                string nameValue = dataHouseTable.Rows[e.RowIndex].Cells["name"].Value.ToString();
                SQLbyName = "\"name\" = '" + nameValue + "'";   //假设name字段是唯一的，正规做法是根据FID字段查询


                #region 缩放到查询结果，但不更新表
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
                mMapControl.Map.SelectFeature(mFeatureLayer, pFeature); //选择要素
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

        //生成SQL语句
        private string GetSqlText()
        {
            string sqltext = "";
            string minValue = numericUpDownLow.Value.ToString(),
                maxValue = numericUpDownHigh.Value.ToString();
            sqltext = "\"price\" >" + minValue + " AND \"price\" <= " + maxValue;
            if (comboBoxRegion.SelectedItem.ToString() != "全部")
                sqltext += " AND \"地名\" = '" + comboBoxRegion.SelectedItem.ToString()+"'";
                //sqltext = "\"地名\" = '" + comboBoxRegion.SelectedItem.ToString() + "'";
            return sqltext;
        }

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
                if(bHasFeatures==true)
                {       
                    if(featureCount==1)
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
            while ((pFeature = pFeatureCursor.NextFeature()) != null)
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

        #endregion
    }
}
