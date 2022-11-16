using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KursProject.ServiceSerializer
{
    [Serializable]
    public class ListSerializer
    {
        public List<Vertex>? SerialVertex { get; set; } = new List<Vertex>();// вершины
        public List<EdgeN>? SerialEdge { get; set; } = new List<EdgeN>();// ребра
        public ListSerializer() { }
        public ListSerializer(List<Vertex> vert, List<EdgeN> edge)
        {
            SerialVertex = vert;
            SerialEdge = edge;
        }
    }
}
