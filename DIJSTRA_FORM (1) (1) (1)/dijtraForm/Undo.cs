using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dijtraForm
{
    public class Undo
    {
        public string Type { get; set; } // Loại hành động: "AddNode", "AddEdge", "IncreaseWeight"........
        public Node Node { get; set; }  // Đỉnh liên quan (nếu hành động liên quan đến đỉnh)
        public Edge Edge { get; set; }  // Cạnh liên quan (nếu hành động liên quan đến cạnh)
        public int PreviousWeight { get; set; }

        public Undo(string type, Node node = null, Edge edge = null, int previousWeight = 0)
        {
            Type = type;
            Node = node;
            Edge = edge;
            PreviousWeight = previousWeight;
        }
    }

}
