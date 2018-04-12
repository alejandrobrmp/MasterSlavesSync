using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSlavesSync.Services
{
    public class JSONUtilsService : IService
    {

        public T Deserialize<T>(Uri file)
        {
            Directory.CreateDirectory(new FileInfo(file.AbsolutePath).DirectoryName);
            if (!File.Exists(file.AbsolutePath)) return default(T);
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(file.AbsolutePath));
        }

        public void Serialize(Uri file, object serialize)
        {
            string serialized = JsonConvert.SerializeObject(serialize, Formatting.Indented);
            File.WriteAllText(file.AbsolutePath, serialized);
        }

    }
}
