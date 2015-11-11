using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MessageParser.NET.Tools
{
   public class JsonTools
    {
        /// <summary>
        /// Deserialize Json To Specified Object
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="json">Json Message</param>
        /// <returns>Json Message</returns>
        public static T Deserialize<T>(string json)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }

        /// <summary>
        /// Serialize Specified Object To Json
        /// </summary>
        /// <typeparam name="T">Object Tyoe</typeparam>
        /// <param name="obj">Object</param>
        /// <returns>Json Message</returns>
        public static string Serialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
