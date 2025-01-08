using System.Collections.Generic;
using System;
using dijtraForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

public class Graph
{
    public List<Node> Nodes { get; set; }
    public List<Edge> Edges { get; set; }
    public int[,] Matrix { get; set; }  // Ma trận kề

    private int nodeCount;  // Đếm số đỉnh
    const int Max = 100;
    private bool isDirected = false;

    public Graph()
    {
        Nodes = new List<Node>();
        Edges = new List<Edge>();
        nodeCount = 0;
        Matrix = new int[Max, Max];  // Khởi tạo ma trận kề với kích thước mặc định 10x10
        //isDirected = _isDirected;
    }
    public void ClearMatrix()
    {
        for (int i = 0; i < Nodes.Count; i++)
        {
            for (int j = 0; j < Nodes.Count; j++)
            {
                Matrix[i, j] = 0;
            }
        }
    }
    // Hàm thêm đỉnh vào đồ thị
    public void AddNode(Node node)
    {
        Nodes.Add(node);
        nodeCount++;
    }

    // Hàm thay đổi kích thước ma trận kề khi số đỉnh tăng
    private void ResizeMatrix(int newSize)
    {
        int[,] newMatrix = new int[newSize, newSize];
        Array.Copy(Matrix, newMatrix, Matrix.Length);
        Matrix = newMatrix;
    }

    // Hàm thêm cạnh vào đồ thị
    public void AddEdge(Edge tmp)
    {
        //if(isDirected){
        //    Edges.Add(tmp);
        //    return;
        //}
        //for (int i = 0; i < Edges.Count; i++)
        //{
        //    if (tmp.From.Id == Edges[i].From.Id && tmp.To.Id == Edges[i].To.Id ||
        //        tmp.From.Id == Edges[i].To.Id && tmp.To.Id == Edges[i].From.Id)
        //    {
        //        Edges[i].Weight = tmp.Weight;
        //        return;
        //    }
        //}

        Edges.Add(tmp);
    }
 




}
