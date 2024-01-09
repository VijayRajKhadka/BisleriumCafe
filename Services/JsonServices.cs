using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisleriumCafe.NewFolder;
using System.Text.Json;

namespace BisleriumCafe.Services
{
    public class JsonServices <T> where T : class
    {

        public static List<T> GetAllData(string filepath)
        {
            if(!File.Exists(filepath))
            {
                return new List<T>();
            }
            var json = File.ReadAllText(filepath);

            var result = JsonSerializer.Deserialize<List<T>>(json);

            return result;
        }

        public static void SaveData(List<T> users, String filePath) 
        {
            if (!Directory.Exists(Constants.DATADIRECTORYPATH))
            {
                Directory.CreateDirectory(Constants.DATADIRECTORYPATH);
            }

            var json = JsonSerializer.Serialize(users);

            File.WriteAllText(filePath, json);
        }
    }
}
