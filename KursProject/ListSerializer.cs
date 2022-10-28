using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProject
{
    [Serializable]
    public class ListSerializer
    {
        public List<EdgeN>? SerialEdge { get; set; } // ребра
        public List<Vertex>? SerialVertex { get; set; } // 
        public ListSerializer() { }

        public ListSerializer(List<Vertex> vert, List<EdgeN> edge)
        {
            INIT();
            SerialEdge = edge;
            SerialVertex = vert;
        }
        private void INIT ()
        {
            SerialVertex = new List<Vertex>();
            SerialEdge = new List<EdgeN>();
        }

    }
}
