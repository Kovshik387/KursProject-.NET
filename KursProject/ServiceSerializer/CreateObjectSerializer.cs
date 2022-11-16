using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using TransferDataPackage.DataSerializations;

namespace KursProject.ServiceSerializer
{
    public class FileObjectSerializer
    {
        public SerializeAdapter ReadXmlData(string path)
        {
            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(DataSerializationBase));
            ServiceSerializer.SerializeAdapter? adapter = new();

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                ListSerializer? listSerializer = new();
                adapter = (dataContractSerializer.ReadObject(fs) as DataSerializationBase)!.StateExtraction<SerializeAdapter>();
            }
            return adapter;
        }

        public SerializeAdapter ReadJsonData(string path)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(DataSerializationBase));
            ServiceSerializer.SerializeAdapter adapter = new();
     
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                ListSerializer? listSerializer = new();
                adapter = (dataContractJsonSerializer.ReadObject(fs) as DataSerializationBase)!.StateExtraction<SerializeAdapter>();
            }
            return adapter;
        }

        public void CreateJsonData(string path, ListSerializer listSerializer)
        {
            FileObjectSerializer createObjectSerializer = new FileObjectSerializer();
            File.Delete(path);

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(DataSerializationBase));

                dataContractJsonSerializer.WriteObject(fs, new SerializeAdapter(listSerializer).StateInstaller());
                Console.WriteLine("Data has been saved to file");
            }
        }
    }
}
