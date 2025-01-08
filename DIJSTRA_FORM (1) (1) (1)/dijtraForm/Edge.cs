using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class Edge
{
    public Node From { get; set; } // Đỉnh bắt đầu
    public Node To { get; set; } // Đỉnh kết thúc
    public int Weight { get; set; } // Trọng số cạnh (nếu có)
   
    public Edge(Node from, Node to, int weight = 1)
    {
        From = from;
        To = to;
        Weight = weight;
    }
    public void DrawEdge(Graphics graphics, Point start, Point end, Color color, bool isDirected,double radius = 10.5, DashStyle dashStyle = DashStyle.Solid, int thickness = 2)
    {
        // Bật các chế độ làm mịn đồ họa cao cấp
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;


        if (isDirected)
        {                                  
            // Tính dx, dy, khoảng cách start và end
            double dx = end.X - start.X;
            double dy = end.Y - start.Y;
            double length = (double)Math.Sqrt(dx * dx + dy * dy);
            if(length == 0)
            {
                //MessageBox.Show("Trùng nhau");
                //return;
                length = 1;
            }

            /*
             * Để tránh mũi tên đè lên đỉnh, ta cần "rút ngắn" đoạn thẳng, tức là dịch chuyển điểm 
             * kết thúc end ngược về hướng của điểm bắt đầu tart một khoảng bằng bán kính của đỉnh (radius).

             * vector donvi = (dx/lenght, dy/lenght) xác định hướng k làm thay đổi độ dài
             */
            Point lastEnd = new Point(
                (int)(end.X - (dx / length) * radius),
                (int)(end.Y - (dy / length) * radius)
            );

            using (Pen pen = new Pen(color, thickness))
            {
                pen.DashStyle = dashStyle;
                // Tạo đầu mũi tên
                System.Drawing.Drawing2D.AdjustableArrowCap arrowCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 8);
                pen.CustomEndCap = arrowCap;

                // Vẽ đường thẳng từ start đến lastEnd
                graphics.DrawLine(pen, start, lastEnd);
            }
        }
        else
        {
            using (Pen pen = new Pen(color, thickness))
            {
                pen.DashStyle = dashStyle;
                // Vẽ đường thẳng giữa start và end
                graphics.DrawLine(pen, start, end);
            }
        }
    }

    internal void DrawEdgeWithWeight(Edge edge, Graphics g)
    {
        // Lấy các node gốc và đích từ đối tượng edge
        Point start = edge.From.Position; // Tọa độ của node gốc
        Point end = edge.To.Position;     // Tọa độ của node đích

        // Tính vị trí trung tâm của đường thẳng để vẽ trọng số
        PointF midpoint = new PointF(
            ((start.X + end.X) / 2),  // Thêm một chút offset để đảm bảo không bị che khuất
            ((start.Y + end.Y) / 2 )
        );

        int radius = 7;
        double dx = start.X - midpoint.X;
        double dy = start.Y - midpoint.Y;
        double lenght = Math.Sqrt( dx * dx + dy * dy );

        midpoint = new Point(
            (int)(midpoint.X + dx/lenght*radius),
            (int)(midpoint.Y + dy/lenght*radius)
        );
        // Tính kích thước của văn bản (trọng số)
        string weightText = edge.Weight.ToString(); // Trọng số của cạnh
        Font font = new Font("Arial", 10);
        SizeF textSize = g.MeasureString(weightText, font); // Lấy kích thước của văn bản

        Brush brush = Brushes.Black;
        g.DrawString(weightText, font, brush, midpoint);
    }
}
