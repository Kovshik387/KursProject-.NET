using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TransferDataPackage.DataSerializations;

namespace KursProject.ServiceSerializer
{
    [XmlRootAttribute(ElementName = "Root")]
    public sealed class SerializeAdapter : DataSerializationBase
    {
        [JsonIgnore,XmlIgnore] public ListSerializer list { get; private set; } = new ();
        public SerializeAdapter(ListSerializer list) => this.list = list;
        public SerializeAdapter() { }

        protected override void SetContextData(TransferDataInstaller<VertexInfo> vertexs, TransferDataInstaller<EdgeInfo> edges)
        {
            for (int i = 0; i < list.SerialVertex!.Count; i++)
            {
                vertexs.InstallData(new VertexInfo()
                {
                    ID = i + 1,
                    PositionX = list.SerialVertex[i].X,
                    PositionY = list.SerialVertex[i].Y
                });
            }

            foreach (var item in list.SerialEdge!)
                edges.InstallData(new EdgeInfo()
                {
                    LeftNodeID = item.IdStart + 1,
                    RightNodeID = item.IdEnd + 1,
                });
        }

        protected override void GetContextData(TransferDataExtractor<VertexInfo> vertexs, TransferDataExtractor<EdgeInfo> edges)
        {
            foreach (var item in vertexs.ExtractData()) list.SerialVertex!.Add(new(item.PositionX - 1,item.PositionY - 1));
            foreach (var item in edges.ExtractData()) list.SerialEdge!.Add(new (item.LeftNodeID - 1,item.RightNodeID - 1));
        }
    }
}
