using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemesisLibrary
{
    public static class NemesisExtensions
    {
        public static T Load<T>(this T element, string fileName)
        {
            string path = Environment.CurrentDirectory;
            var json = File.ReadAllText(Path.Combine(path, fileName));
            element = JsonConvert.DeserializeObject<T>(json);
            return element;
            
        }

        public static void Save<T>(this T element, string fileName)
        {
            var json = JsonConvert.SerializeObject(element, Formatting.Indented);
            string path = Environment.CurrentDirectory;
            File.WriteAllText(Path.Combine(path, fileName), json);
        }
    }
}
