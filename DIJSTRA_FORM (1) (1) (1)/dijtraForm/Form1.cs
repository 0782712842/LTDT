using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Runtime.InteropServices.ComTypes;
using System.Data.Common;
using Guna.UI2.WinForms;

namespace dijtraForm
{
    public partial class Form1 : Form
    {
        private int currentNodeIndex = 0;

        private int nodeCounter = 0; // Đếm số lượng đỉnh
        private bool showGrid = false;
        private Point currentMousePosition; // Vị trí chuột hiện tại

        private Node startNode = null; // Đỉnh bắt đầu của cạnh
        private Node endNode = null; // Đỉnh kết thúc của cạnh
        private bool isDrawingEdge = false; // Trạng thái vẽ cạnh

        private Node dashedLineStartNode = null;
        private Node dashedLineEndNode = null;

        Stack<Undo> undoStack = new Stack<Undo>();

        // thanh ngang nút exit
        private Node draggedNode = null;
        private Point dragOffset;
        private bool isDragging = false;
        private bool isDirected = false;
        private Graph graph = new Graph();
        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            pnGraph.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            .SetValue(pnGraph, true, null);

            showGrid = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            
        }
        private void txtStart_Enter(object sender, EventArgs e)
        {
            if (txtStart.Text == "Start")
            {
                txtStart.Text = ""; // Xóa placeholder
                txtStart.ForeColor = Color.Black; // Đặt màu chữ đậm
            }
        }
        private void txtStart_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStart.Text))
            {
                txtStart.Text = "Start"; // Đặt lại placeholder
                txtStart.ForeColor = Color.Gray; // Đặt màu chữ nhạt
            }
        }
        private void ShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            showGrid = checkBoxShowGrid.Checked ? true : false;
            pnGraph.Invalidate();
        }
        //private void
        private void pnGraph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            if (showGrid)
            {
                int cellSize = 25;
                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    for (int y = 0; y < pnGraph.Height; y += cellSize)
                    {
                        g.DrawLine(pen, 0, y, pnGraph.Width, y);
                    }
                    for (int x = 0; x < pnGraph.Width; x += cellSize)
                    {
                        g.DrawLine(pen, x, 0, x, pnGraph.Height);
                    }
                }
            }

            foreach (var edge in graph.Edges)
            {
                edge.DrawEdge(g, edge.From.Position, edge.To.Position, Color.Red, isDirected);
                if (!rdBfs.Checked && !rdDfs.Checked)
                {
                    edge.DrawEdgeWithWeight(edge, g);
                }
            }

            if (isDrawingEdge && startNode != null)
            {
                //Node tmpNode = new Node(-1, currentMousePosition, graph);
                Edge tmpEdge = new Edge(startNode, null);
                tmpEdge.DrawEdge(g, startNode.Position, currentMousePosition,Color.Green, isDirected,0, DashStyle.Dash);

            }

            if (dashedLineStartNode != null && dashedLineEndNode != null)
            {
                Edge tmp = new Edge(dashedLineStartNode, dashedLineEndNode);
                tmp.DrawEdge(g, dashedLineStartNode.Position, dashedLineEndNode.Position, Color.Green, isDirected,10.5, DashStyle.Dash);
            }
        }
       

        private void pnGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawingEdge && startNode != null)
            {
                // Vẽ cạnh tạm thời khi đang kết nối
                currentMousePosition = e.Location;
                foreach (Node i in graph.Nodes)
                {
                    if (Distance(e.Location, i.Position) < 16)
                    {
                        i.Visual.BackColor = Color.LightCyan; // Ví dụ đổi màu node bị click
                    }
                    else if (i != startNode)
                    {
                        i.Visual.BackColor = Color.Yellow;
                    }
                }
                pnGraph.Invalidate(); // Yêu cầu vẽ lại Panel
            }
        }
        private void pnGraph_MouseClick(object sender, MouseEventArgs e)
        {
            Point center = new Point(e.X, e.Y);
            setPositionPoint(ref center);

            if (graph.Nodes.Any(node => node.Position == center) || startNode != null)
            {
                return;
            }
            // Nếu không click vào đỉnh nào, tạo một đỉnh mới

            Node newNode = new Node(nodeCounter, center, graph);

            ClickNode(newNode);
            graph.AddNode(newNode);
            undoStack.Push(new Undo("AddNode", newNode));
            UpdateMatrix();
            UpdateList();
            pnGraph.Controls.Add(newNode.Visual);
            nodeCounter++;
        }
        private void ClickNode(Node newNode)
        {
            newNode.Visual.MouseClick += (s, args) =>
            {
                //MessageBox.Show(newNode.Position.ToString());
                if (args.Button == MouseButtons.Left)
                {
                    Node clickedNode = newNode;
                    if (clickedNode != null)
                    {
                        if (startNode == null)
                        {
                            startNode = clickedNode;
                            startNode.Visual.BackColor = Color.LightCyan;
                            isDrawingEdge = true;
                            pnGraph.MouseMove += pnGraph_MouseMove;
                        }
                        else
                        {
                            endNode = clickedNode;
                            if (endNode == startNode)
                            {
                                startNode.Visual.BackColor = Color.Yellow;
                                endNode = null;
                                startNode = null;
                                return;
                            }
                            string indexI = startNode.Visual.Text;
                            string indexJ = endNode.Visual.Text;
                            if (!isDirected)
                            {
                                graph.Matrix[int.Parse(indexJ), int.Parse(indexI)]++;
                                graph.Matrix[int.Parse(indexI), int.Parse(indexJ)]++;

                            }
                            else
                            {
                                graph.Matrix[int.Parse(indexJ), int.Parse(indexI)]++;
                            }
                            Edge tmp = new Edge(startNode, endNode);
                            bool isIncreWight = false;
                            for (int i = 0; i < graph.Edges.Count; i++)
                            {
                                
                                    if ((tmp.From.Id == graph.Edges[i].From.Id && tmp.To.Id == graph.Edges[i].To.Id ||
                                        tmp.From.Id == graph.Edges[i].To.Id && tmp.To.Id == graph.Edges[i].From.Id ) && !isDirected)
                                    {
                                        graph.Edges[i].Weight++;
                                        pnGraph.Invalidate();
                                        undoStack.Push(new Undo("IncreaseWeight", edge: graph.Edges[i], previousWeight: graph.Edges[i].Weight));
                                        isIncreWight = true;
                                        break;
                                    }
                                    else if (tmp.From.Id == graph.Edges[i].From.Id && tmp.To.Id == graph.Edges[i].To.Id && isDirected)
                                    {
                                        graph.Edges[i].Weight++;
                                        pnGraph.Invalidate();
                                        undoStack.Push(new Undo("IncreaseWeight", edge: graph.Edges[i], previousWeight: graph.Edges[i].Weight));
                                        isIncreWight = true;
                                        break;
                                    }


                            }
                            if (!isIncreWight)
                            {
                                graph.AddEdge(tmp);

                                pnGraph.Invalidate();
                                Edge x = new Edge(graph.Nodes[0], graph.Nodes[1]);
                                undoStack.Push(new Undo("AddEdge", edge: tmp));
                                using (Graphics g = pnGraph.CreateGraphics())
                                {
                                    tmp.DrawEdge(g, startNode.Position, endNode.Position, Color.Black, isDirected);
                                }
                            }
                            
                            UpdateMatrix();
                            UpdateList();
                            startNode.Visual.BackColor = Color.Yellow;
                            endNode.Visual.BackColor = Color.Yellow;

                            startNode = null;
                            isDrawingEdge = false;
                            endNode = null;
                            pnGraph.MouseMove -= pnGraph_MouseMove;
                        }
                        return;
                    }
                }
            };
        }
        // Hàm tính khoảng cách giữa hai điểm
        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
        private void UpdateList()
        {
            if (AdjacencyList == null)
                return;
            int nodeCount = graph.Nodes.Count;
            // gọi đến nhiều lần nên pk clear trc khi update
            AdjacencyList.Rows.Clear();

            for (int i = 0; i < nodeCount; i++)
            {
                // Thêm các ô vào dòng
                string value = "";
                bool isAdjacency = false;
                for (int j = 0 ; j < nodeCount; j++)
                {
                    if (graph.Matrix[i, j] != 0)
                    {
                        isAdjacency = true;
                        value += j.ToString() + " ";
                    }
                }
                if (isAdjacency)
                {
                    AdjacencyList.Rows.Add(i.ToString(), value);
                }
                else
                {
                    AdjacencyList.Rows.Add(i.ToString());
                }
            }
        }
        private void UpdateMatrix()
        {
            if (AdjacencyMatrix == null)
                return;
            // Lấy số lượng đỉnh trong đồ thị
            int nodeCount = graph.Nodes.Count;

            // Xóa tất cả các dòng và cột cũ trong DataGridView
            AdjacencyMatrix.Rows.Clear();
            AdjacencyMatrix.Columns.Clear();

            // Thêm cột đầu tiên (dùng để đánh số hàng)
            for (int i = 0; i < nodeCount; i++)
            {
                AdjacencyMatrix.Columns.Add(i.ToString(), i.ToString()); // Thêm các cột với số thứ tự
                AdjacencyMatrix.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            graph.ClearMatrix();

            for(int i = 0;i < graph.Edges.Count; i++)
            {
                int x = graph.Edges[i].From.Id ;
                int y = graph.Edges[i].To.Id;
                if (isDirected)
                {
                    graph.Matrix[x, y] = graph.Edges[i].Weight;
                }
                else
                {
                    graph.Matrix[x, y] = graph.Edges[i].Weight;
                    graph.Matrix[y, x] = graph.Edges[i].Weight;
                }
            }

            // Thêm các dòng vào DataGridView
            for (int i = 0; i < nodeCount; i++)
            {
                // Tạo một dòng mới
                DataGridViewRow row = new DataGridViewRow();
                // Thêm các ô vào dòng
                for (int j = 0; j < nodeCount; j++)
                {
                    string value;
                    // Kiểm tra điều kiện "∞"
                    if (graph.Matrix[i, j] == 0 && i != j)
                    {
                        value = "∞"; // Hiển thị "∞" nếu không có cạnh giữa i và j
                    }
                    else if (i == j)
                    {
                        value = "-"; // Điền dấu "-" nếu là phần tử chéo chính
                    }
                    else
                    {
                        value = graph.Matrix[i, j].ToString();
                    }

                    // Tạo một ô mới cho cột j
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    cell.Value = value;

                    // Thêm ô vào dòng
                    row.Cells.Add(cell);
                }

                // Thêm dòng vào DataGridView
                AdjacencyMatrix.Rows.Add(row);
                if (i < 10)
                {
                    // Nếu i nhỏ hơn 10, gán giá trị với dấu cách sau số
                    AdjacencyMatrix.Rows[i].HeaderCell.Value = " "+ i.ToString() ;
                }
                else
                {
                    // Nếu i không nhỏ hơn 10, chỉ gán giá trị của i mà không có dấu cách
                    AdjacencyMatrix.Rows[i].HeaderCell.Value = i.ToString();
                }
            }
            // Đặt chiều rộng , dài cột đều nhau
            foreach (DataGridViewColumn column in AdjacencyMatrix.Columns)
            {
                column.Width = 30;
            }
            foreach (DataGridViewRow row in AdjacencyMatrix.Rows)
            {
                row.Height = 30; // Chiều cao mỗi dòng là 30

            }
            // Đặt font để điều chỉnh chiều cao dòng
            AdjacencyMatrix.DefaultCellStyle.Font = new Font("Segoe UI", 12); // Thay đổi font cho toàn bộ DataGridView
        }
       
        public void RemoveNodeFromMatrix(int nodeId)
        {
            int nodeCount = graph.Nodes.Count;
            for (int i = nodeId; i < nodeCount - 1; i++)
            {
                for (int j = 0; j < nodeCount; j++)
                {
                    graph.Matrix[i, j] = graph.Matrix[i + 1, j];
                }
            }

            for (int j = nodeId; j < nodeCount - 1; j++)
            {
                for (int i = 0; i < nodeCount; i++)
                {
                    graph.Matrix[i, j] = graph.Matrix[i, j + 1];
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                Undo lastAction = undoStack.Pop();
                switch (lastAction.Type)
                {
                    case "AddNode":
                        if(lastAction.Node == startNode)
                        {
                            startNode = null;
                        }
                        // Xóa đỉnh khỏi danh sách đỉnh
                        graph.Nodes.Remove(lastAction.Node);
                        if(nodeCounter > 0)nodeCounter--;
                        // Cập nhật ma trận kề, xóa hàng và cột của đỉnh
                        RemoveNodeFromMatrix(lastAction.Node.Id);  // Id của đỉnh có thể là 1-based
                        // Cập nhật giao diện
                        pnGraph.Controls.Remove(lastAction.Node.Visual);
                        break;

                    case "AddEdge":
                        graph.Edges.Remove(lastAction.Edge);
                        graph.Matrix[lastAction.Edge.From.Id, lastAction.Edge.To.Id] = 0;
                        graph.Matrix[lastAction.Edge.To.Id, lastAction.Edge.From.Id] = 0;
                        break;

                    case "RemoveEdge":
                        graph.AddEdge(lastAction.Edge);
                        break;

                    case "RemoveNode":
                        //graph.Nodes = graph.Nodes.OrderBy(item => item.Id).ToList();
                        for (int i = lastAction.Node.Id; i < graph.Nodes.Count; i++)
                        {
                            int value;
                            if (int.TryParse(graph.Nodes[i].Visual.Text, out value))
                            {
                                value += 1;
                                graph.Nodes[i].Id = value;
                                graph.Nodes[i].Visual.Text = value.ToString();
                            }
                            else
                            {
                                MessageBox.Show("1");
                            }
                        }
                        graph.Nodes.Insert(lastAction.Node.Id, lastAction.Node);
                        
                        pnGraph.Controls.Add(lastAction.Node.Visual);
                        while (undoStack.Count > 0 && undoStack.Peek().Type == "RemoveEdgeOfNode")
                        {
                            graph.Edges.Add(undoStack.Pop().Edge);
                        }

                        nodeCounter++;
                        break;
                    case "IncreaseWeight":
                        // Kiểm tra và khôi phục trọng số trước đó trong danh sách cạnh
                        foreach (Edge edge in graph.Edges)
                        {
                            if (edge.From.Id == lastAction.Edge.From.Id && edge.To.Id == lastAction.Edge.To.Id ||
                                edge.From.Id == lastAction.Edge.To.Id && edge.To.Id == lastAction.Edge.From.Id)
                            {
                                //edge.Weight = lastAction.PreviousWeight;
                                edge.Weight -= 1;///này tự thêm
                                break;
                            }
                        }
                        break;
                    case "DecreaseWeight":
                        // Kiểm tra và khôi phục trọng số trước đó trong danh sách cạnh
                        foreach (Edge edge in graph.Edges)
                        {
                            if (edge.From.Id == lastAction.Edge.From.Id && edge.To.Id == lastAction.Edge.To.Id ||
                                edge.From.Id == lastAction.Edge.To.Id && edge.To.Id == lastAction.Edge.From.Id)
                            {
                                //edge.Weight = lastAction.PreviousWeight;
                                edge.Weight += 1;///này tự thêm
                                break;
                            }
                        }
                        break;
                    case "OpenGraph":
                        pnGraph.Controls.Clear();
                        graph.Nodes.Clear();
                        graph.Edges.Clear();
                        nodeCounter = 0;
                        break;
                    case "ClearEdge":
                        graph.Edges.Clear();
                        break;

                }
                // Cập nhật giao diện
                UpdateMatrix();
                UpdateList();
                pnGraph.Invalidate();
            }
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            string Sstart = txtStart.Text;
            
            #region Hủy sự kiện
            CbChoice.SelectedIndexChanged -= guna2ComboBox1_SelectedIndexChanged;
            pnGraph.MouseClick -= pnGraph_MouseClick;
            btnRanDomize.Click -= btnRanDomize_Click;
            btnUndo.Click -= btnUndo_Click;
            btnRun.Click -= btnRun_Click;
            checkBoxShowGrid.Enabled = false;
            txtStart.ReadOnly = true;
            trackbarSpeed.Enabled = false;


            #endregion
            lbLogs.Text = "";
            if(Sstart == "Start" || Sstart == "")
            {
                System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                // Hiển thị ToolTip
                toolTip.Show("Đỉnh bắt đầu không hợp lệ!!", this, 450, 100, 1500);
                txtStart.BorderColor = Color.Red;
                await Task.Delay(1500);
                txtStart.BorderColor = Color.PeachPuff;

            }
            int start, end;

            if (int.TryParse(Sstart, out start) && start >= 0 && start < graph.Nodes.Count)
            {
                if (rdDijStra.Checked )
                {
                    rdBfs.Enabled = false;
                    rdDfs.Enabled = false;
                    Algorithm algorithm = new Algorithm(isDirected);
                    await algorithm.Dijkstra(graph, start, pnGraph, lbLogs, trackbarSpeed);
                }
                else if (rdBfs.Checked)
                {
                    rdDfs.Enabled = false;
                    rdDijStra.Enabled = false;
                    Algorithm algorithm = new Algorithm(isDirected);
                    await algorithm.BFS(graph, start, pnGraph, lbLogs, trackbarSpeed);
                }
                else if (rdDfs.Checked)
                {
                    rdBfs.Enabled = false;
                    rdDijStra.Enabled = false;
                    Algorithm algorithm = new Algorithm(isDirected);
                    await algorithm.DFS(graph, start, pnGraph, lbLogs, trackbarSpeed);
                }
                else
                {
                    System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                    // Hiển thị ToolTip
                    toolTip.Show("Chưa chọn thuật toán!!", this, 450, 100, 1500);
                    rdBfs.ForeColor = Color.Red;
                    rdDfs.ForeColor = Color.Red;
                    rdDijStra.ForeColor = Color.Red;
                    await Task.Delay(1500);

                    rdBfs.ForeColor = Color.DarkGreen;
                    rdDfs.ForeColor = Color.DarkGreen;
                    rdDijStra.ForeColor = Color.DarkGreen;
                }
                pnGraph.Invalidate();
                
            }
            else
            {
                System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                toolTip.Show("Đỉnh bắt đầu không hợp lệ!!", this, 450, 100, 1500);
                txtStart.BorderColor = Color.Red;
                await Task.Delay(1500);
                txtStart.BorderColor = Color.PeachPuff;
            }
            #region đăng kí lại sự kiện
            pnGraph.MouseClick += pnGraph_MouseClick;
            btnRanDomize.Click+= btnRanDomize_Click;
            btnUndo.Click += btnUndo_Click;
            btnRun.Click += btnRun_Click;
            CbChoice.SelectedIndex = (isDirected ? 1 : 0);
            CbChoice.SelectedIndexChanged += guna2ComboBox1_SelectedIndexChanged;
            CbChoice.Invalidate();
            checkBoxShowGrid.Enabled = true;
            txtStart.ReadOnly = false;
            trackbarSpeed.Enabled = true;

            rdDijStra.Enabled = true;
            rdBfs.Enabled = true;
            rdDfs.Enabled = true;
            #endregion 
        }
        private void AdjacencyMatrix_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào một ô hợp lệ (không phải header)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex != e.ColumnIndex)
            {
                // Lấy chỉ số dòng và cột khi click vào
                int rowIndex = e.RowIndex;
                int colIndex = e.ColumnIndex;

                Edge edge = new Edge(graph.Nodes[rowIndex], graph.Nodes[colIndex]);
                // Kiểm tra nếu có cạnh hay không (ví dụ: graph.Matrix[rowIndex, colIndex] == 0)
                if (graph.Matrix[rowIndex, colIndex] == 0)
                {
                    if (!isDirected)
                    {
                        graph.Matrix[rowIndex, colIndex] = 1;
                        graph.Matrix[colIndex, rowIndex] = 1;
                        graph.Edges.Add(edge);

                        AdjacencyMatrix.Rows[rowIndex].Cells[colIndex].Value = 1;
                        AdjacencyMatrix.Rows[colIndex].Cells[rowIndex].Value = 1;

                    }
                    else
                    {
                        graph.Edges.Add(edge);
                        graph.Matrix[rowIndex, colIndex] = 1;
                        AdjacencyMatrix.Rows[rowIndex].Cells[colIndex].Value = 1;
                    }
                    undoStack.Push(new Undo("AddEdge", edge: edge));
                    // Cập nhật lại ma trận với giá trị mới (thêm cạnh)
                }
                else
                {
                    foreach (Edge i in graph.Edges)
                    {
                        if ((edge.To.Id == i.To.Id && edge.From.Id == i.From.Id ||
                            edge.To.Id == i.From.Id && edge.From.Id == i.To.Id) && !isDirected)
                        {
                            i.Weight += 1;
                            edge = i;
                            undoStack.Push(new Undo("IncreaseWeight", edge: edge, previousWeight: edge.Weight));
                            graph.Matrix[rowIndex, colIndex] += 1;
                            graph.Matrix[colIndex, rowIndex] += 1;

                            AdjacencyMatrix.Rows[rowIndex].Cells[colIndex].Value = edge.Weight;
                            AdjacencyMatrix.Rows[colIndex].Cells[rowIndex].Value = edge.Weight;
                            break;
                        }
                        else if (edge.From.Id == i.From.Id && edge.To.Id == i.To.Id && isDirected)
                        {
                            i.Weight += 1;
                            edge = i;
                            undoStack.Push(new Undo("IncreaseWeight", edge: edge, previousWeight: edge.Weight));
                            graph.Matrix[rowIndex, colIndex] += 1;
                            AdjacencyMatrix.Rows[rowIndex].Cells[colIndex].Value = edge.Weight;
                            break;
                        }
                    }
                }
                pnGraph.Invalidate();

            }
            UpdateList();
        }

        private void AdjacencyMatrix_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {

            dashedLineStartNode = null;
            dashedLineEndNode = null;

            foreach (var node in graph.Nodes)
            {
                node.Visual.BackColor = Color.Yellow;
            }
            pnGraph.Invalidate();
        }

        private void AdjacencyMatrix_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex != -1 || e.ColumnIndex == -1 && e.RowIndex != -1) {
                int NodeIndex = Math.Max(e.RowIndex, e.ColumnIndex);
                graph.Nodes[NodeIndex].Visual.BackColor = Color.Red;   
                foreach(Edge i in graph.Edges)
                {
                    if(i.From.Id == NodeIndex)
                    {
                        dashedLineStartNode = i.From;
                        dashedLineEndNode = i.To;
                    }else if (i.To.Id == NodeIndex)
                    {
                        dashedLineStartNode = i.To;
                        dashedLineEndNode = i.From;
                    }
                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int indexRow = e.RowIndex;
                int indexColum = e.ColumnIndex;

                // Làm nổi bật các đỉnh tương ứng
                graph.Nodes[indexRow].Visual.BackColor = Color.LightCyan;
                graph.Nodes[indexColum].Visual.BackColor = Color.LightCyan;

                // Kiểm tra ma trận kề để quyết định vẽ đường nét đứt
                if (graph.Matrix[indexRow, indexColum] == 0 && !isDirected) 
                {
                    dashedLineStartNode = graph.Nodes[indexRow];
                    dashedLineEndNode = graph.Nodes[indexColum];
                }
                if (isDirected)
                {
                    dashedLineStartNode = graph.Nodes[indexRow];
                    dashedLineEndNode = graph.Nodes[indexColum];
                }
            }
        }

        private void AdjacencyMatrix_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex == -1 && e.ColumnIndex != -1 || e.ColumnIndex == -1 && e.RowIndex != -1){
                int indexNode = Math.Max(e.RowIndex, e.ColumnIndex);

                for (int j = graph.Edges.Count - 1; j >= 0; j--)
                {
                    Edge edge = graph.Edges[j];
                    if (edge.From.Id == indexNode || edge.To.Id == indexNode)
                    {
                        undoStack.Push(new Undo("RemoveEdgeOfNode", edge: edge));
                        graph.Edges.RemoveAt(j);
                    }
                }

                for (int i = 0; i < graph.Nodes.Count; i++)
                {
                    if (graph.Nodes[i].Id == indexNode)
                    {
                        
                        undoStack.Push(new Undo("RemoveNode", graph.Nodes[i]));
                        graph.Nodes.RemoveAt(i);
                        break;

                    }
                }
                for(int i = 0;i < pnGraph.Controls.Count; i++)
                {
                    if (pnGraph.Controls[i].Text == indexNode.ToString())
                    {
                        pnGraph.Controls.RemoveAt(i);
                        break;

                    }
                }

                nodeCounter--;
                System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                // Hiển thị ToolTip
                toolTip.Show($"Đã cập nhật lại sau khi xóa đỉnh {indexNode} ", this, 440, 100, 1500);

                for (int i = 0; i < graph.Nodes.Count; i++)
                {
                    graph.Nodes[i].Id = i;
                    graph.Nodes[i].Visual.Text = i.ToString();

                }
                pnGraph.Invalidate();
                UpdateMatrix();
                UpdateList();
                return;
            }
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex != e.ColumnIndex)
            {
                // Lấy chỉ số dòng và cột khi click vào
                int rowIndex = e.RowIndex;
                int colIndex = e.ColumnIndex;
                if (graph.Matrix[rowIndex, colIndex] != 0)
                {
                    Edge tmpEdge = new Edge(graph.Nodes[rowIndex], graph.Nodes[colIndex]);
                    if(!isDirected)
                    {
                        graph.Matrix[rowIndex, colIndex] -= 1;
                        graph.Matrix[colIndex, rowIndex] -= 1;
                        string value = graph.Matrix[rowIndex, colIndex].ToString();
                        if (value == "0") {
                            value = "∞";
                        }
                        AdjacencyMatrix.Rows[rowIndex].Cells[colIndex].Value = value;
                        AdjacencyMatrix.Rows[colIndex].Cells[rowIndex].Value = value;
                    }
                    else
                    {
                        graph.Matrix[rowIndex, colIndex] -= 1;
                        string value = graph.Matrix[rowIndex, colIndex].ToString();
                        if (value == "0")
                        {
                            value = "∞";
                        }
                        AdjacencyMatrix.Rows[rowIndex].Cells[colIndex].Value = value;
                    }


                    for (int i = graph.Edges.Count - 1; i >= 0; i--)
                    {
                        Edge edge = graph.Edges[i];
                        if (!isDirected && edge.From == tmpEdge.From && edge.To == tmpEdge.To ||
                                edge.From == tmpEdge.To && edge.To == tmpEdge.From)
                        {
                            if (graph.Matrix[rowIndex, colIndex] == 0)
                            {
                                graph.Edges.RemoveAt(i);

                                undoStack.Push(new Undo("RemoveEdge", edge: edge));
                            }
                            else
                            {
                                graph.Edges[i].Weight -= 1;
                                undoStack.Push(new Undo("DecreaseWeight", edge: graph.Edges[i], previousWeight: graph.Edges[i].Weight));
                            }

                            break;
                        }
                        else if (isDirected && edge.From == tmpEdge.From && edge.To == tmpEdge.To)
                        {
                            if (graph.Matrix[rowIndex, colIndex] == 0)
                            {
                                graph.Edges.RemoveAt(i);

                                undoStack.Push(new Undo("RemoveEdge", edge: edge));
                            }
                            else
                            {
                                graph.Edges[i].Weight -= 1;
                                undoStack.Push(new Undo("DecreaseWeight", edge: graph.Edges[i], previousWeight: graph.Edges[i].Weight));
                            }

                            break;
                        }
                    }
                    UpdateList();
                    pnGraph.Invalidate();
                }
            }
        }
        private void btnRanDomize_Click(object sender, EventArgs e)
        {
            if (nodeCounter == 0) return;

            graph.Edges.Clear();
            graph.ClearMatrix();
            Random random = new Random();
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int nodeID = random.Next(0, graph.Nodes.Count);
                    if (nodeID != i && graph.Matrix[i, nodeID] == 0)
                    {
                        if (!isDirected && graph.Matrix[nodeID, i] != 0)
                        {
                            continue;
                        }
                        int _weight = random.Next(1, 10);
                        Edge edge = new Edge(graph.Nodes[i], graph.Nodes[nodeID], _weight);
                        graph.Matrix[i, nodeID] = _weight;
                        graph.Edges.Add(edge);
                        break;
                    }
                }
            }
            undoStack.Push(new Undo("ClearEdge"));
            pnGraph.Invalidate();
            UpdateMatrix();
            UpdateList();
        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            if (txtStart.Text != "Start" && txtStart.Text.Length > 0)
            {
                btnUndo.Enabled = true;
            }
        }

        private void lbLogs_Enter(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void ToolTripOpenGraph_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "Open Graph File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Đọc nội dung file
                    string filePath = openFileDialog.FileName;
                    string fileContent = File.ReadAllText(filePath);
                    readGraph(filePath);

                }
            }
        }
        private void readGraph(string path)
        {
            //isFile = true;
            EdgesList.Clear();
            graph.ClearMatrix();
            graph.Nodes.Clear();
            graph.Edges.Clear();
            UpdateMatrix();
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        #region reset
                        nodeCounter = 0;
                        graph.Nodes.Clear();
                        graph.Edges.Clear();
                        undoStack.Clear();
                        pnGraph.Controls.Clear();
                        lbLogs.Clear();
                        undoStack.Push(new Undo("OpenGraph"));
                        #endregion
                        nodeCounter = int.Parse(reader.ReadLine());
                        Point[] points = new Point[nodeCounter];
                        Random rand = new Random();
                        for (int x = 0; x < nodeCounter; x++)
                        {
                            Point tmp = new Point(rand.Next(90, 365), rand.Next(60, 365));
                            setPositionPoint(ref tmp);
                            while (findPoint(tmp, points))
                            {
                                tmp = new Point(rand.Next(90, 365), rand.Next(60, 365));
                                setPositionPoint(ref tmp);
                            }

                            points[x] = tmp;
                        }
                        int i = 0;
                        while (!reader.EndOfStream)
                        {
                            Node node = new Node(i, points[i], graph);
                            graph.AddNode(node);
                            ClickNode(node);
                            pnGraph.Controls.Add(node.Visual);

                            string line = reader.ReadLine();
                            string[] values = line.Split(' '); 

                            for (int j = 0; j < values.Length; j++)
                            {
                                graph.Matrix[i, j] = int.Parse(values[j]);
                                
                            }
                            i++;
                        }
                        btnFocus.PerformClick();
                        for (int j = 0; j < nodeCounter; j++)
                        {

                            for (int k = 0; k < nodeCounter; k++)
                            {
                                if (graph.Matrix[j, k] != graph.Matrix[k, j])
                                {
                                    isDirected = true;
                                    break;
                                }

                            }
                            if (isDirected) break;
                        }
                        if (isDirected)
                        {
                            for (i = 0; i < nodeCounter; i++)
                            {

                                for (int j = 0; j < nodeCounter; j++)
                                {
                                    if (graph.Matrix[i, j] != 0)
                                    {
                                        Edge edge = new Edge(graph.Nodes[i], graph.Nodes[j], graph.Matrix[i, j]);
                                        graph.Edges.Add(edge);
                                    }
                                }
                            }
                            CbChoice.SelectedIndex = 1;

                        }
                        else
                        {
                            for (i = 0; i < nodeCounter - 1; i++)
                            {

                                for (int j = i + 1; j < nodeCounter; j++)
                                {
                                    if (graph.Matrix[i, j] != 0)
                                    {
                                        Edge edge = new Edge(graph.Nodes[i], graph.Nodes[j], graph.Matrix[i, j]);
                                        graph.Edges.Add(edge);
                                    }
                                }
                            }
                        }
                        
                        
                        UpdateMatrix();
                        UpdateList();
                        pnGraph.Invalidate();
                    }
                    System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                    // Hiển thị ToolTip
                    toolTip.Show("Mở file thành công!", this, 450, 100, 3000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }
            
        }
        private bool findPoint(Point point, Point[] arrayPoint)
        {
            for (int i = 0; i < arrayPoint.Length; i++)
            {
                if (arrayPoint[i] == point) { return true; }
            }
            return false;
        }
        private void setPositionPoint(ref Point e)
        {
            int cellSize = 25;
            // Tính toán tọa độ của đỉnh sao cho nó nằm trong một ô lưới
            int gridX = (e.X / cellSize) * cellSize;
            int gridY = (e.Y / cellSize) * cellSize;
            Point center = new Point(gridX + cellSize / 2, gridY + cellSize / 2);
            center.X += 3;
            center.Y += 3;
            e = center;
        }

        private void SaveGraphToolTrip_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Graph File";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    writeGraph(filePath);
                }
            }
        }

        private void writeGraph(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Ghi số đỉnh
                    writer.WriteLine(graph.Nodes.Count);

                    // Ghi ma trận kề
                    for (int i = 0; i < graph.Nodes.Count; i++)
                    {
                        for (int j = 0; j < graph.Nodes.Count; j++)
                        {
                            writer.Write(graph.Matrix[i, j]);
                            if(j < graph.Nodes.Count - 1)
                            {
                                writer.Write(' ');
                            }
                        }
                        if(i < graph.Nodes.Count - 1)
                        {
                            writer.WriteLine();  // Xuống dòng sau mỗi hàng
                        }
                    }
                }
                System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                // Hiển thị ToolTip
                toolTip.Show("Dữ liệu đã được lưu lại!", this, 450, 100, 3000);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi");
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackbarSpeed_ValueChanged(object sender, EventArgs e)
        {
            labelValue.Text = $"{trackbarSpeed.Maximum +100 - trackbarSpeed.Value}ms";
            int thumbX = trackbarSpeed.Location.X +
                     (trackbarSpeed.Width - 15) *  // 15 là một giá trị ước tính kích thước Thumb
                     (trackbarSpeed.Value - trackbarSpeed.Minimum) /
                     (trackbarSpeed.Maximum - trackbarSpeed.Minimum);

            // Cập nhật vị trí Label phía dưới
            labelValue.Location = new Point(thumbX - labelValue.Width / 2,
                                            trackbarSpeed.Location.Y + trackbarSpeed.Height + 5);

            labelValue.Visible = true;
        }

        private void trackbarSpeed_MouseUp(object sender, MouseEventArgs e)
        {
            labelValue.Visible = false;
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Group frm = new Group();
            frm.Show();
        }

        private void instructionManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIntruction frm = new frmIntruction();
            frm.Show();
        }

        //tạo ra 1 list tạm để lưu cạnh nào 2 chiều (2 trọng số)
        private List<Edge> EdgesList = new List<Edge>();
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnGraph.Invalidate();
            string value = CbChoice.SelectedItem.ToString();
            isDirected = (value == "Undirected") ? false : true;

            if (!isDirected)
            {
                for (int i = graph.Edges.Count - 1; i >= 0; i--)
                {
                    Edge edge = graph.Edges[i];
                    for (int j = i - 1; j >= 0; j--)
                    {
                        Edge edgeTmp = graph.Edges[j];
                        if ((edge.From.Id == edgeTmp.From.Id && edge.To.Id == edgeTmp.To.Id ||
                            edge.From.Id == edgeTmp.To.Id && edge.To.Id == edgeTmp.From.Id))
                        {
                            graph.Edges.RemoveAt(i);
                            EdgesList.Add(edge);
                        }
                    }

                }
            }
            else
            {
                for (int i = 0; i < EdgesList.Count; i++)
                {
                    graph.Edges.Add(EdgesList[i]);
                }
                EdgesList.Clear();
            }

            UpdateMatrix();
            UpdateList();
        }

        private void btnFocus_Click(object sender, EventArgs e)
        {
            if (nodeCounter == 0) return;

            // Lấy kích thước của panel để xác định tâm của màn hình
            int panelWidth = pnGraph.Width;
            int panelHeight = pnGraph.Height;

            // Tâm của màn hình
            Point screenCenter = new Point(panelWidth / 2, panelHeight / 2);

            // Bán kính của hình tròn (có thể điều chỉnh theo ý muốn)
            int radius = Math.Min(panelWidth, panelHeight) / 3;

            // Góc chia đều cho mỗi node
            double angleStep = 2 * Math.PI / graph.Nodes.Count;
            int index = 0;

            foreach (Node node in graph.Nodes)
            {
                // Tính toán vị trí mới của node theo hình tròn
                double angle = angleStep * index;
                Point newPosition = new Point
                {
                    X = (int)(screenCenter.X + radius * Math.Cos(angle)),
                    Y = (int)(screenCenter.Y + radius * Math.Sin(angle))
                    //để xác định vị trí của một điểm trên một đường tròn có bán kính r và góc θ 
                    //x = r.Cos(0)
                    //y = r.Sin(0)
                };

                // Đảm bảo không vượt quá ranh giới của panel (tùy chọn, nếu cần)
                newPosition.X = Math.Max(0, Math.Min(newPosition.X, panelWidth));
                newPosition.Y = Math.Max(0, Math.Min(newPosition.Y, panelHeight));

                setPositionPoint(ref newPosition);
                node.Position = newPosition;
                node.Visual.Location = new Point(newPosition.X - 15, newPosition.Y - 15);

                index++;
            }

            // Vẽ lại panel
            pnGraph.Invalidate();
        }

        private void rdBfs_CheckedChanged(object sender, EventArgs e)
        {
            pnGraph.Invalidate();
        }

        private void rdDfs_CheckedChanged(object sender, EventArgs e)
        {
            pnGraph.Invalidate();
        }

        private void rdDijStra_CheckedChanged(object sender, EventArgs e)
        {
            pnGraph.Invalidate();
        }

    }

}
