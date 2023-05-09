using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Utilities
{
    public class JsonReader
    {
        public JsonReader()
        { }

        public T readJsonFile<T>(string filepath)
        {
            try
            {
                // Open the file using a stream reader
                using (StreamReader sr = new StreamReader(filepath))
                {
                    // Read the entire contents of the file
                    string json = sr.ReadToEnd();
                    T data = JsonConvert.DeserializeObject<T>(json);
                    return data;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Cannot Read File : " + e.Message);
            }



        }
    }
}
