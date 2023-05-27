using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Assignment1
{
    public class readFromFile<T>
    {
        public static T LoadTasksJSON(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error loading tasks from {filePath}: {err.Message}");
                return default;

            }
        }
        public static T LoadTasksXML(string data)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StringWriter writer = new StringWriter())
                {
                    serializer.Serialize(writer, data);
                    return default;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error converting to XML: {err.Message}");
                return default;
            }
        }
    }
}


