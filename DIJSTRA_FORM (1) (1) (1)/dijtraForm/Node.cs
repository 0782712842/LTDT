using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using System;

public class Node
{
    public int Id { get; set; }
    public Point Position { get; set; }
    public Label Visual { get; set; }
    private Graph graph; // Thêm tham chiếu đến đối tượng graph

    internal bool isDragging = false;
    private Point dragOffset;
    internal bool dragged = false;
    private Node draggedNode = null;
    public Node(int id, Point position, Graph graph)
    {
        Id = id;
        Position = position;
        this.graph = graph; // Gán đối tượng graph

        Visual = new Label
        {
            Text = Id.ToString(),
            Size = new Size(25, 25),
            Font = new Font("Arial", 10, FontStyle.Bold),
            BackColor = Color.Yellow,
            TextAlign = ContentAlignment.MiddleCenter,
            BorderStyle = BorderStyle.None,
            Location = new Point(position.X - 15, position.Y - 15)
        };

        MakeCircular(Visual);
        //Visual.Click += (s, args) => {
                Visual.MouseDown += Visual_MouseDown;
                Visual.MouseMove += Visual_MouseMove;
                Visual.MouseUp += Visual_MouseUp;
        //};
        
    }

    private void MakeCircular(Label label)
    {
        int size = Math.Min(label.Width, label.Height);
        label.Width = size;
        label.Height = size;

        GraphicsPath path = new GraphicsPath();
        path.AddEllipse(0, 0, size, size);
        label.Region = new Region(path);

        label.Paint += (s, e) =>
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawEllipse(pen, 1, 1, size - 2, size - 2);
            }
        };
    }

    private void Visual_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            isDragging = true;
            dragOffset = new Point(e.X, e.Y);
            draggedNode = this;
        }
    }
    private double Distance(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }
    private void Visual_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            Point newLocation = Visual.Location;
            newLocation.X += e.X - dragOffset.X;
            newLocation.Y += e.Y - dragOffset.Y;
            newLocation.X = Math.Max(0, Math.Min(newLocation.X, 600));
            newLocation.Y = Math.Max(0, Math.Min(newLocation.Y, 525));

            // Kiểm tra xem vị trí mới có trùng với vị trí của bất kỳ node nào khác không
            Point newPosition = new Point(newLocation.X + 15, newLocation.Y + 15);

            //Rectangle oldRect = new Rectangle(////
            Visual.Location = newLocation;
            Position = new Point(newLocation.X + 15, newLocation.Y + 15);

            // Cập nhật vị trí của các cạnh liên quan
            foreach (var edge in graph.Edges)
            {
                if (edge.From == this || edge.To == this)
                {
                    Visual.Parent.Invalidate(); // Yêu cầu vẽ lại Panel để cập nhật vị trí các cạnh
                }
            }
        }
    }
    private void Visual_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            isDragging = false;

            // Kích thước của mỗi ô lưới
            int cellSize = 25;

            // Tính toán tọa độ của đỉnh sao cho nó nằm trong một ô lưới
            int gridX = (draggedNode.Position.X / cellSize) * cellSize;
            int gridY = (draggedNode.Position.Y / cellSize) * cellSize;
            Point center = new Point(gridX + cellSize / 2, gridY + cellSize / 2);
            center.X += 3;
            center.Y += 3;
            draggedNode.Position = center;
            draggedNode.Visual.Location = new Point(center.X - 15, center.Y - 15);
            Visual.Parent.Invalidate();
        }
    }
}