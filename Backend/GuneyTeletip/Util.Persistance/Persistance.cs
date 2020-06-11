using Newtonsoft.Json;
using System.Text;

namespace Util.Persistance
{
    public class Persistance
    {
        public string FilePath { get; set; }
        public Persistance(string filePath)
        {
            FilePath = filePath;
        }

        public T Get<T>(string key)
        {
            T d = default(T);

            if (System.IO.File.Exists(FilePath))
            {
                var str = System.IO.File.ReadAllText(FilePath);
                if (string.IsNullOrEmpty(str))
                {
                    return d;
                }
                d = JsonConvert.DeserializeObject<T>(str);
            }
            return d;
        }
        public void Save<T>(string key, T data)
        {
            var str = JsonConvert.SerializeObject(data);
            System.IO.File.WriteAllText(FilePath, str, Encoding.UTF8);
        }
        public void Delete(string key)
        {
            System.IO.File.Delete(FilePath);
        }
    }
}