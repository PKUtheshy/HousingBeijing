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
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Location;

namespace Housing
{
    public partial class SearchPOI : Form
    {
        #region 私有变量
        private AxMapControl axMapControl;
        private IMap mMap;  //当前mapcontrol控件的对象

        //选中图层
        private IFeatureLayer mFeatureLayer;
        //根据选择图层查询到的特征类
        private IFeatureClass pFeatureClass = null;
        private IGraphicsContainer PGC;
        private IPoint bufferPoint;

        //路径规划起点源图层
        private IFeatureLayer spFeatureLayer;
        //最短路径终点
        private IPoint endPoint;

        //网络分析变量
        public INAContext m_NAContext;  //网络分析上下文
        public INetworkDataset networkDataset; //网络数据集
        public IFeatureWorkspace pFWorkspace;
        public IFeatureDataset featureDataset;
        #endregion

        //初始化窗口
        public SearchPOI(AxMapControl sMapControl)
        {
            InitializeComponent();
            this.axMapControl = sMapControl;
            this.mMap = sMapControl.Map;
        }

        private void SearchPOI_Load(object sender, EventArgs e)
        {
            //初始化待选图层
            comboBoxPOIType.Items.Add("公交地铁站");
            comboBoxPOIType.Items.Add("中小学");
            comboBoxPOIType.Items.Add("娱乐场所");
            comboBoxPOIType.Items.Add("医院");
            comboBoxPOIType.SelectedIndex = 0;
            mFeatureLayer = FindLayerByName("traffic");

            //初始化起点图层
            comboBoxStart.Items.Add("小区");
            comboBoxStart.Items.Add("公交地铁站");
            comboBoxStart.Items.Add("中小学");
            comboBoxStart.Items.Add("娱乐场所");
            comboBoxStart.Items.Add("医院");
            comboBoxStart.SelectedIndex = 0;
            spFeatureLayer = FindLayerByName("house");
        }

        #region 控件事件

        /// <summary>
        /// 选择POI点类型发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPOIType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string layerName = comboBoxPOIType.SelectedItem.ToString();
            if (layerName == "公交地铁站")
                mFeatureLayer = FindLayerByName("traffic");
            else if (layerName == "中小学")
                mFeatureLayer = FindLayerByName("school");
            else if (layerName == "娱乐场所")
                mFeatureLayer = FindLayerByName("entertainment");
            else if (layerName == "医院")
                mFeatureLayer = FindLayerByName("hospital");
        }

        /// <summary>
        /// 起点源图层发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            string layerName = comboBoxStart.SelectedItem.ToString();
            if (layerName == "小区")
                spFeatureLayer = FindLayerByName("house");
            else if (layerName == "公交地铁站")
                spFeatureLayer = FindLayerByName("traffic");
            else if (layerName == "中小学")
                spFeatureLayer = FindLayerByName("school");
            else if (layerName == "娱乐场所")
                spFeatureLayer = FindLayerByName("entertainment");
            else if (layerName == "医院")
                spFeatureLayer = FindLayerByName("hospital");
        }

        /// <summary>
        /// 查询POI点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            IFeatureLayer houselayer = axMapControl.Map.get_Layer(1) as IFeatureLayer;
            string houseName = textBoxName.Text;
            int bDistance = (int)numericUpDownBuffer.Value;
            SearchOnMap(houseName,houselayer, mFeatureLayer, bDistance);
            SearchOnTable(houseName, houselayer, mFeatureLayer, bDistance);
        }

        /// <summary>
        /// 规划生成最短路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGoto_Click(object sender, EventArgs e)
        {
            //设置gdb路径
            string gdbname = @"D:\MyProject\UTMdata\network.gdb";
            //起点与终点        
            string startPointName = textBoxStartPoint.ToString();
            IPoint startPoint = GetPointByName(startPointName, spFeatureLayer);
            FindShortestPath(gdbname, startPoint, endPoint);
        }

        /// <summary>
        /// 单独看某一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataPOITable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>0)
            {
                // 获取当前选中行的name
                string nameValue = dataPOITable.Rows[e.RowIndex].Cells["name"].Value.ToString();
                string SQLbyName = "";
                if (mFeatureLayer.Name == "hospital")
                    SQLbyName = "\"name\" = '" + nameValue + "'";
                else
                    SQLbyName = "\"名称\" = '" + nameValue + "'";

                #region 缩放到查询结果，但不更新表
                //清除查询结果
                axMapControl.Map.ClearSelection();
                IActiveView pActivaView = axMapControl.Map as IActiveView;
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
                axMapControl.Map.SelectFeature(mFeatureLayer, pFeature);
                endPoint = pFeature.Shape as IPoint;    //选择的要素作为点返回内存
                //将要素的几何体合并到envelope中
                IGeometry pGeometry = pFeature.ShapeCopy;
                pEnvelope.Union(pGeometry.Envelope);
                axMapControl.CenterAt(pEnvelope.LowerLeft);
                axMapControl.MapScale = 10000.00;
                pActivaView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                pActivaView.Refresh();
                #endregion
            }
        }

        #endregion

        #region 查询私有函数

        //获取对应图层
        private IFeatureLayer FindLayerByName(string layerName)
        {
            IFeatureLayer featureLayer = null;
            // 获取所有图层
            IEnumLayer layers = axMapControl.Map.Layers;
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer.Name.Equals(layerName))
                {
                    featureLayer = layer as IFeatureLayer;
                    break;
                }
                layer = layers.Next();
            }
            return featureLayer;
        }

        //周边搜索,结果在地图中高亮
        private void SearchOnMap(string pointname, IFeatureLayer pointLayer, IFeatureLayer sFeaturelayer, int bufferDistance)
        {
            //清除查询结果
            axMapControl.Map.ClearSelection();
            IActiveView pActivaView = axMapControl.Map as IActiveView;

            // 在图层1中根据name字段搜索到某点要素
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = "\"name\" ='" + pointname + "'";
            IFeatureCursor featureCursor = pointLayer.Search(queryFilter, false);
            IFeature pointFeature = featureCursor.NextFeature();

            //创建一个新的envelope对象用于缩放
            IEnvelope pEnvelope = new EnvelopeClass();
            if (pointFeature != null)
            {

                #region 画出缓冲区范围
                IPoint bufferPoint = pointFeature.Shape as IPoint;
                // 创建一个GraphicsContainer来存储要绘制的图形
                PGC = axMapControl.ActiveView as IGraphicsContainer;
                IElement element = null;

                // 创建一个圆
                IConstructCircularArc constructCircularArc = new CircularArcClass();
                constructCircularArc.ConstructCircle(bufferPoint, bufferDistance, false);
                ICircularArc circularArc = constructCircularArc as ICircularArc;
                IGeometry geometry = circularArc as IGeometry;
                IRgbColor pColor = new RgbColorClass();
                pColor.Red = 0;pColor.Blue = 0;pColor.Green = 0;pColor.Transparency = 255;
                //产生线符号对象
                ILineSymbol lineSymbol = new SimpleLineSymbolClass();
                lineSymbol.Width = 3;lineSymbol.Color = pColor;

                // 将圆形转换为面
                ISegmentCollection segmentCollection = new RingClass();
                segmentCollection.AddSegment(circularArc as ISegment);

                // 创建一个面符号来表示缓冲区
                ISimpleFillSymbol fillSymbol = new SimpleFillSymbolClass();
                fillSymbol.Outline = lineSymbol; // 设置缓冲区边界线符号

                // 创建一个面元素
                IFillShapeElement fillElement = new PolygonElementClass();
                fillElement.Symbol = fillSymbol;

                // 将面元素添加到图形容器
                element = fillElement as IElement;
                PGC.AddElement(element, 0);
                #endregion

                //将小区的坐标存入
                pEnvelope.Union(pointFeature.ShapeCopy.Envelope);
                axMapControl.Map.SelectFeature(pointLayer, pointFeature);

                // 创建缓冲区
                ITopologicalOperator topoOperator = pointFeature.Shape as ITopologicalOperator;
                IGeometry bufferGeometry = topoOperator.Buffer(bufferDistance);

                // 在图层2中查询出距离该点要素一定范围的点
                ISpatialFilter spatialFilter = new SpatialFilterClass();
                spatialFilter.Geometry = bufferGeometry;
                spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;

                IFeatureCursor sFeatureCursor = sFeaturelayer.Search(spatialFilter, false);
                IFeature sFeature = sFeatureCursor.NextFeature();
                int count = 0;
                while (sFeature != null)
                {
                    count++;
                    axMapControl.Map.SelectFeature(sFeaturelayer, sFeature);    //选择要素
                    axMapControl.Extent = sFeature.Shape.Envelope;   //放大到要素
                    //将要素的几何体合并到envelope中
                    IGeometry pGeometry = sFeature.ShapeCopy;
                    pEnvelope.Union(pGeometry.Envelope);
                    sFeature = sFeatureCursor.NextFeature();
                }
                if(count==0)
                {
                    //缩放到小区
                    axMapControl.CenterAt(pEnvelope.LowerLeft);
                }
                else
                {
                    //调整envelope的大小，确保要素可见
                    pEnvelope.Expand(1.5, 1.5, true);
                    //缩放到envelope所表示的范围
                    axMapControl.Extent = pEnvelope;
                }
                pActivaView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                pActivaView.Refresh();
                //MessageBox.Show("距离" + pointname + "点" + bufferDistance + "的点数量为：" + count);
            }
            else
            {
                MessageBox.Show("未找到小区：" + pointname+",请重新输入！");
            }
        }

        //周边搜索，结果在表中显示
        private void SearchOnTable(string pointname, IFeatureLayer pointLayer, IFeatureLayer sFeaturelayer, int bufferDistance)
        {
            // 在图层1中根据name字段搜索到某点要素
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = "\"name\" ='" + pointname + "'";
            IFeatureCursor featureCursor = pointLayer.Search(queryFilter, false);
            IFeature pointFeature = featureCursor.NextFeature();

            if(pointFeature!=null)
            {
                //构造dataTable并添加列
                DataTable dTable = new DataTable();
                string layerName = sFeaturelayer.Name;
                if(layerName=="hospital")
                {
                    dTable.Columns.Add("name", typeof(string));
                    dTable.Columns.Add("adress", typeof(string));
                    dTable.Columns.Add("level", typeof(string));
                    dTable.Columns.Add("area", typeof(string));
                }
                else
                {
                    dTable.Columns.Add("name", typeof(string));
                    dTable.Columns.Add("type", typeof(string));
                    dTable.Columns.Add("area", typeof(string));
                }

                // 创建缓冲区
                ITopologicalOperator topoOperator = pointFeature.Shape as ITopologicalOperator;
                IGeometry bufferGeometry = topoOperator.Buffer(bufferDistance);
                // 在图层2中查询出距离该点要素一定范围的点
                ISpatialFilter spatialFilter = new SpatialFilterClass();
                spatialFilter.Geometry = bufferGeometry;
                spatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;

                IFeatureCursor sFeatureCursor = sFeaturelayer.Search(spatialFilter, false);
                IFeature sFeature = null;
                while((sFeature=sFeatureCursor.NextFeature())!=null)
                {
                    DataRow dRow = dTable.NewRow();
                    if(layerName == "hospital")
                    {
                        dRow["name"] = sFeature.get_Value(sFeature.Fields.FindField("name"));
                        dRow["adress"] = sFeature.get_Value(sFeature.Fields.FindField("adress"));
                        dRow["level"] = sFeature.get_Value(sFeature.Fields.FindField("level"));
                        dRow["area"] = sFeature.get_Value(sFeature.Fields.FindField("area"));
                    }
                    else
                    {
                        dRow["name"] = sFeature.get_Value(sFeature.Fields.FindField("名称"));
                        dRow["type"] = sFeature.get_Value(sFeature.Fields.FindField("中类"));
                        dRow["area"] = sFeature.get_Value(sFeature.Fields.FindField("区域"));
                    }
                    dTable.Rows.Add(dRow);
                }
                //数据在表中显示
                dataPOITable.DataSource = dTable;
            }
        }
        #endregion

        #region 网络分析函数

        //根据name字段获取起点
        private IPoint GetPointByName(string pointName, IFeatureLayer sFeatureLayer)
        {
            //基于SQL语句查询
            IQueryFilter queryFilter = new QueryFilterClass();
            string sqltext = "";
            if (sFeatureLayer.Name == "house" || sFeatureLayer.Name == "hospital")
                sqltext = "\"name\" = '" + pointName + "'";
            else
                sqltext = "\"名称\" = '" + pointName + "'";
            queryFilter.WhereClause = sqltext;
            IFeatureCursor featureCursor = sFeatureLayer.Search(queryFilter, true);
            IFeature pFeature = featureCursor.NextFeature();
            if (pFeature != null)
            {
                IGeometry geometry = pFeature.Shape;
                return geometry as IPoint;
            }
            else
            {
                return null;
            }
        }

        //打开工作空间
        public IWorkspace OpenWorkspace(string strGDBName)
        {
            IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactory();
            return workspaceFactory.OpenFromFile(strGDBName, 0);
        }

        //打开网络数据集
        public INetworkDataset OpenNetworkDataset(IWorkspace networkDatasetWorkspace, string networkDatasetName, string featureDatasetName)
        {
            if (networkDatasetWorkspace == null || networkDatasetName == "" || featureDatasetName == null)
            {
                return null;
            }
            IFeatureWorkspace featureWorkspace = networkDatasetWorkspace as IFeatureWorkspace;
            featureDataset = featureWorkspace.OpenFeatureDataset(featureDatasetName);
            IFeatureDatasetExtensionContainer featureDatasetExtensionContainer = featureDataset as IFeatureDatasetExtensionContainer;
            IFeatureDatasetExtension featureDatasetExtension = featureDatasetExtensionContainer.FindExtension(esriDatasetType.esriDTNetworkDataset);
            IDatasetContainer3 datasetContainer3 = (IDatasetContainer3)featureDatasetExtension;
            if (datasetContainer3 == null)
                return null;
            IDataset dataset = datasetContainer3.get_DatasetByName(esriDatasetType.esriDTNetworkDataset, networkDatasetName);
            return dataset as INetworkDataset;
        }

        //创建网络分析上下文
        public INAContext CreateSolverContext(INetworkDataset networkDataset)
        {
            //获取创建网络分析上下文所需的IDENETWORKDATASET类型参数
            IDENetworkDataset deNDS = GetDENetworkDataset(networkDataset);
            INASolver naSolver;
            naSolver = new NARouteSolver();
            INAContextEdit contextEdit = naSolver.CreateContext(deNDS, naSolver.Name) as INAContextEdit;
            contextEdit.Bind(networkDataset, new GPMessagesClass());
            return contextEdit as INAContext;
        }

        //得到创建网络分析上下文所需的IDENETWORKDATASET类型参数
        public IDENetworkDataset GetDENetworkDataset(INetworkDataset networkDataset)
        {
            //将网络分析数据集QI添加到DATASETCOMPOENT
            IDatasetComponent dstComponent;
            dstComponent = networkDataset as IDatasetComponent;
            //获得数据元素
            return dstComponent.DataElement as IDENetworkDataset;
        }

        //网络分析规划最短路径
        private void FindShortestPath(string gdbname,IPoint sPoint, IPoint ePoint)
        {
            //打开工作空间
            pFWorkspace = OpenWorkspace(gdbname) as IFeatureWorkspace;
            //打开网络数据集
            networkDataset = OpenNetworkDataset(pFWorkspace as IWorkspace, "network_ND", "road");
            //创建网络分析上下文，建立一种解决关系
            m_NAContext = CreateSolverContext(networkDataset);

            // 创建路径分析解决器
            //INASolver naSolver = new NARouteSolver();
            //INARouteSolver naRouteSolver = naSolver as INARouteSolver;
            //INARouteParams naRouteParams = naRouteSolver.CreateDefaultRouteParams();
            //naRouteParams.OutSpatialReference = m_NAContext.NAClasses.get_ItemByName("Streets").SpatialReference;
            //naRouteParams.ImpedanceAttributeName = "Length";

            //// 添加起点和终点到路径分析中
            //INALocationArray locationArray = new NALocationArrayClass();
            //INALocation location = new NALocationClass();
            //location.Shape = startPoint;
            //locationArray.AddLocation(location);

            //location = new NALocationClass();
            //location.Shape = endPoint;
            //locationArray.AddLocation(location);

            //naRouteParams.Stops = locationArray;

            //// 解决路径分析
            //INASolverResults naSolverResults = naRouteSolver.Solve(naRouteParams, m_NAContext);

            //// 获取结果几何
            //INARoute naRoute;
            //INALayer naLayer = naSolverResults.get_LayerByName("Routes") as INALayer;
            //naRoute = naLayer.ContextItem as INARoute;
            //IPolyline resultLine = naRoute.ShapeCopy as IPolyline;
        }

        #endregion
    }
}
