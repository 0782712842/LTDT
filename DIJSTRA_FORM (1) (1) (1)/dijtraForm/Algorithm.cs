using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace dijtraForm
{
    internal class Algorithm
    {
        private bool isDirected = false;
        public Algorithm(bool _isDirected) { 
            isDirected = _isDirected;
        }
        private void DrawEdge(Edge edge, Color color, Panel pnGraph)
        {
            using (Graphics g = pnGraph.CreateGraphics())
            {
                edge.DrawEdge(g, edge.From.Position, edge.To.Position, color, isDirected);
            }
        }
        public async Task Dijkstra(Graph graph, int start, Panel pnGraph, TextBox lbLogs, Guna2TrackBar trackbarSpeed)
        {
            int TimerDraw = 2100 - trackbarSpeed.Value;
            int n = graph.Nodes.Count; // Số lượng đỉnh
            int[] distance = new int[n]; // Mảng lưu khoảng cách ngắn nhất từ start
            int[] previous = new int[n]; // Mảng lưu đỉnh trước đó trong đường đi
            bool[] visited = new bool[n]; // Mảng đánh dấu đỉnh đã được duyệt

            // Khởi tạo giá trị ban đầu
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue; // Khoảng cách vô cực
                previous[i] = -1;           // Không có đỉnh trước
                visited[i] = false;         // Chưa được duyệt
            }
            distance[start] = 0; // Khoảng cách từ start đến chính nó là 0

            int v = start; // Đỉnh hiện tại
            #region bắt đầu thuật toán
            await Task.Delay(200);
            lbLogs.Text = "";
            lbLogs.Text += "Thuật toán  Dijkstra bắt đầu" + Environment.NewLine; 
            await Task.Delay(200);
            lbLogs.Text += $"Đỉnh bắt đầu {start}";
            await Task.Delay(200);
            #endregion
            // Vòng lặp tìm đường đi ngắn nhất
            int step = 1;
            while (true)
            {
                // Tìm đỉnh chưa được duyệt có khoảng cách ngắn nhất
                v = -1;
                for (int i = 0; i < n; i++)
                {
                    if (!visited[i] && (v == -1 || distance[i] < distance[v]))
                    {
                        v = i;
                    }
                }
                // Nếu không còn đỉnh khả dụng hoặc không thể tiếp tục, dừng vòng lặp
                if (v == -1 || distance[v] == int.MaxValue)
                    break;
                #region Logs
                lbLogs.Text += Environment.NewLine;
                lbLogs.Text += $"Bước {step}: Đỉnh đang xét {v}: Khoảng cách hiện tại {distance[v]}" + Environment.NewLine;
                #endregion
                step++;
                // Tô màu xanh lá cây cho đỉnh đang được chọn (đỉnh v)
                graph.Nodes[v].Visual.BackColor = Color.LightSkyBlue;
                if (previous[v] != -1)
                {
                    //for(int i = 0;)
                    Edge edge = new Edge(graph.Nodes[previous[v]], graph.Nodes[v]);
                    DrawEdge(edge, Color.Green, pnGraph); // Vẽ cạnh màu xanh lá cây
                }
                await Task.Delay(TimerDraw);  // Chờ 1 giây 
                // Đánh dấu đỉnh hiện tại là đã duyệt
                visited[v] = true;
                // Cập nhật khoảng cách của các đỉnh kề
                bool isUpdateLogs = false;
                for (int i = 0; i < n; i++)
                {
                    if (!visited[i] && graph.Matrix[v, i] != 0) // Có cạnh nối và chưa được duyệt
                    {
                        graph.Nodes[i].Visual.BackColor = Color.Red;
                        Edge edge = new Edge(graph.Nodes[v], graph.Nodes[i]);
                        DrawEdge(edge, Color.Blue, pnGraph);
                        int newDistance = distance[v] + graph.Matrix[v, i];
                        if (newDistance < distance[i])
                        {
                            distance[i] = newDistance; // Cập nhật khoảng cách ngắn nhất
                            previous[i] = v;
                            // Lưu đỉnh trước đó
                            isUpdateLogs = true;
                            #region Logs
                            lbLogs.Text += $"\t- Cập nhật khoảng cách -> đỉnh {i}: {distance[i]} (Qua đỉnh {v})" + Environment.NewLine;
                            #endregion
                        }
                    }
                }
                #region Logs
                if (!isUpdateLogs)
                {
                    lbLogs.Text += $"\t- Không có cập nhật mới" + Environment.NewLine;

                }
                #endregion
                lbLogs.Text += $"\tCập nhật khoảng cách hiện tại :" + Environment.NewLine;
                for(int i = 0; i < n; i++)
                {
                    string tmpDis = distance[i].ToString();
                    if (distance[i] == int.MaxValue)
                    {
                        tmpDis = "∞";
                    }
                    lbLogs.Text += $"\tĐỉnh {i}: {tmpDis}   ";
                    if ( (i + 1) % 3 == 0 ) lbLogs.Text += Environment.NewLine;
                }
                
                #region Chỉnh tốc độ hiển thị
                await Task.Delay(TimerDraw/2);                    
                #endregion
                for (int i = 0; i < graph.Nodes.Count; i++)
                {
                    if (visited[i] == false && graph.Matrix[v, i] != 0)
                    {
                        graph.Nodes[i].Visual.BackColor = Color.Yellow;
                        Edge edge = new Edge(graph.Nodes[v], graph.Nodes[i]);
                        DrawEdge(edge, Color.Red, pnGraph);
                    }
                }
                
            }
            #region Show kết quả
            lbLogs.Text += Environment.NewLine;
            lbLogs.Text += "Kết quả:" + Environment.NewLine;
            await Task.Delay(150);
            lbLogs.Text += $"Khoảng cách ngắn nhất từ {start} đến các đỉnh còn lại là: " + Environment.NewLine;
        
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                if (i != start)
                {
                    if (distance[i] != int.MaxValue)
                    {
                        lbLogs.Text += $"\t- {start} -> {i} có tồng trọng số: {distance[i]}" + Environment.NewLine;
                        await Task.Delay(150);
                    }
                    else
                    {
                        lbLogs.Text += $"\t- Không có đường đi từ {start} -> {i}" + Environment.NewLine;
                        await Task.Delay(150);
                    }
                }

            }
            #endregion
            #region đổi màu lại
            await Task.Delay(trackbarSpeed.Value);
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                graph.Nodes[i].Visual.BackColor = Color.Yellow;
            }
            #endregion
        }
  
        // Hàm vẽ cạnh

        public async Task DFS(Graph graph, int start, Panel pnGraph, TextBox lbl, Guna2TrackBar trackbarSpeed)
        {
            int TimerDraw = 2100 - trackbarSpeed.Value;
            int n = graph.Nodes.Count;
            bool[] visited = new bool[n];
            int[] parent = new int[n];   // Mảng lưu đỉnh cha
            int[] path = new int[n];

            Stack<int> stack = new Stack<int>();
            stack.Push(start);
            visited[start] = true;
            parent[start] = -1;  // Đỉnh bắt đầu không có cha
            #region bắt đầu thuật toán
            lbl.Text = "";
            await Task.Delay(200);
            lbl.Text += "Thuật toán DFS bắt đầu" + Environment.NewLine;
            await Task.Delay(200);
            lbl.Text += $"Xuất phát từ đỉnh {start} (thêm đỉnh {start} vào ngăn xếp )" + Environment.NewLine;
            await Task.Delay(200);
            #endregion
            int step = 1;
            while (stack.Count > 0)
            {
                int key = stack.Pop();
                path[step - 1] = key;
                // Lấy đỉnh từ Stack
                #region Logs
                lbl.Text += $"Bước {step}: Đỉnh đang xét {key} (Đẩy đỉnh {key} ra khỏi ngăn xếp)" + Environment.NewLine;
                #endregion
                step++;
                // Tô màu đỉnh hiện tại

                graph.Nodes[key].Visual.BackColor = Color.Red; // Đỉnh sáng màu đỏ
                #region chỉnh thời gian
                await Task.Delay(TimerDraw / 2);
                #endregion// Chờ để hiển thị
                // Nếu đỉnh hiện tại có cha, vẽ cạnh giữa đỉnh hiện tại và cha
                if (parent[key] != -1)
                {
                    Edge edge = new Edge(graph.Nodes[parent[key]], graph.Nodes[key]);
                    DrawEdge(edge, Color.Green, pnGraph);
                }
                // Sau khi xử lý xong, đổi màu đỉnh thành màu cyan
                graph.Nodes[key].Visual.BackColor = Color.Cyan;
                await Task.Delay(TimerDraw); // Chờ để hiển thị
                string NodeConnectTo = "";
                bool isUpdateLogs = false;
                bool adjacentPeak = false;//tìm xem có đỉnh kề

                // Duyệt các đỉnh kề
                for (int i = n - 1; i >= 0; i--)
                {
                    if (!visited[i] && graph.Matrix[key, i] != 0)
                    {
                        graph.Nodes[i].Visual.BackColor = Color.LightGray;
                        NodeConnectTo += $"{i} ";
                        visited[i] = true;
                        stack.Push(i);
                        isUpdateLogs = true;
                        parent[i] = key;// Gán cha của đỉnh kề
                        await Task.Delay(200);
                    }
                    if (graph.Matrix[key, i] != 0)
                    {
                        adjacentPeak = true;
                    }
                }
                #region Logs
                if(adjacentPeak && !isUpdateLogs)
                {
                    lbl.Text += "\t- Các đỉnh liền kề đã thăm tiếp tục xét đỉnh đầu trong ngăn xếp" + Environment.NewLine;
                    lbl.Text += $"\t- Ngăn xếp [{string.Join(", ", stack.ToList())}]" + Environment.NewLine;
                }
                else if (!adjacentPeak)
                {
                    lbl.Text += "\t- Không có đỉnh liền kề! Thuật toán kết thúc" + Environment.NewLine;
                } 
                else if(isUpdateLogs)
                {
                    lbl.Text += $"\t- Đỉnh {key} kết nối với {NodeConnectTo}" + Environment.NewLine;
                    lbl.Text += $"\t- Đã thăm đỉnh {NodeConnectTo}, thêm {NodeConnectTo} vào ngăn xếp" + Environment.NewLine;
                    lbl.Text += $"\t- Ngăn xếp [{string.Join(", ", stack.ToList())}]" + Environment.NewLine;
                }
                #endregion
            }
            #region Logs
            lbl.Text += "Kết quả: " + Environment.NewLine + "Đã duyệt đỉnh theo thứ tự: ";
            for (int i = 0; i < step - 1; i++)
            {
                lbl.Text += $"{path[i]}";
                if (i < step - 2) lbl.Text += " -> ";
            }
            #endregion
            #region đổi màu lại
            // Sau khi hoàn thành DFS, đổi màu tất cả các đỉnh thành màu vàng
            await Task.Delay(trackbarSpeed.Value);
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                graph.Nodes[i].Visual.BackColor = Color.Yellow;
            }
            #endregion
        }
        public async Task BFS(Graph graph, int start, Panel pnGraph, TextBox lbl, Guna2TrackBar trackbarSpeed)
        {
            int TimerDraw = 2100 - trackbarSpeed.Value;
            int n = graph.Nodes.Count;
            bool[] visited = new bool[n];
            int[] path = new int[n];
            int[] parent = new int[n];    // Mảng lưu đỉnh cha
            List<Edge> edgesInPath = new List<Edge>();

            // Khởi tạo hàng đợi BFS
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            visited[start] = true;
            parent[start] = -1;  // Đỉnh bắt đầu không có cha
            #region bắt đầu thuật toán
            lbl.Text = "";
            await Task.Delay(200);
            lbl.Text += "Thuật toán BFS bắt đầu" + Environment.NewLine;
            await Task.Delay(200);
            lbl.Text += $"Xuất phát từ đỉnh {start} (thêm đỉnh {start} vào hàng đợi )" + Environment.NewLine;
            await Task.Delay(200);
            #endregion
            int step = 1;
            while (q.Count > 0)
            {
                int key = q.Dequeue();
                path[step - 1] = key;

                graph.Nodes[key].Visual.BackColor = Color.Red;
                #region Logs
                lbl.Text += $"Bước {step}: Đỉnh đang xét {key} (Đẩy đỉnh {key} ra khỏi hàng đợi)" + Environment.NewLine;
                #endregion
                step++;
                #region chỉnh thời gian

                await Task.Delay(TimerDraw / 2);
                #endregion
                // Duyệt tất cả các đỉnh kề
                string NodeConnectTo = "";
                bool isUpdateLogs = false;
                bool adjacentPeak = false;//tìm xem có đỉnh kề

                for (int i = 0; i < n; i++)
                {
                    if (!visited[i] && graph.Matrix[key, i] != 0)
                    {
                        graph.Nodes[i].Visual.BackColor = Color.LightGray;
                        NodeConnectTo += $"{i} ";
                        visited[i] = true;
                        q.Enqueue(i);
                        parent[i] = key;  // Gán cha của đỉnh i
                        isUpdateLogs = true;
                        await Task.Delay(200);
                    }
                    if(graph.Matrix[key, i] != 0)
                    {
                        adjacentPeak = true;
                    }
                }
                #region Logs

                if (adjacentPeak && !isUpdateLogs) {
                    lbl.Text += "\t- Các đỉnh liền kề đã được thăm tiếp tục xét đỉnh đầu trong hàng đợi" + Environment.NewLine;
                    lbl.Text += $"\t- Hàng đợi [{string.Join(", ", q.ToList())}]" + Environment.NewLine;
                }
                else if (!adjacentPeak)
                {
                    lbl.Text += "\t- Không có đỉnh liền kề nào! Thuật toán kết thúc" + Environment.NewLine;
                }
                else if(isUpdateLogs)
                {
                    lbl.Text += $"\t- Đỉnh {key} kết nối với {NodeConnectTo}" + Environment.NewLine;
                    lbl.Text += $"\t- Đã thăm đỉnh {NodeConnectTo}, thêm {NodeConnectTo} vào Hàng đợi" + Environment.NewLine;
                    lbl.Text += $"\t- Hàng đợi [{string.Join(", ", q.ToList())}]" + Environment.NewLine;

                }
                #endregion
                if (parent[key] != -1)
                {
                    Edge edge = new Edge(graph.Nodes[parent[key]], graph.Nodes[key]);
                    DrawEdge(edge, Color.Green, pnGraph); // Vẽ cạnh màu đỏ
                }

                // Đổi màu đỉnh hiện tại thành cyan sau khi duyệt
                graph.Nodes[key].Visual.BackColor = Color.Cyan;
                await Task.Delay(TimerDraw);
            }
            #region Logs
            lbl.Text += "Kết quả: " + Environment.NewLine + "Đã duyệt đỉnh theo thứ tự: ";
            for(int i = 0; i < step - 1; i++)
            {
                lbl.Text += $"{path[i]}";
                if (i < step - 2) lbl.Text += " -> ";
            }
            #endregion
            #region đổi màu lại
            // Đổi màu tất cả các đỉnh thành vàng khi hoàn tất
            await Task.Delay(trackbarSpeed.Value);
            for (int i = 0; i < n; i++)
            {
                graph.Nodes[i].Visual.BackColor = Color.Yellow;
            }
            #endregion
        }
    }
}
