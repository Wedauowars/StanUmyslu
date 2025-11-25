using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konkurs
{
    public static class FileManager {
        public static void Save(string path, string content) {
            File.WriteAllText(path, content);
        }
        public static void Append(string path, string content) {
            File.AppendAllText(path, content + "\n");
        }
        public static string Load(string path) {
            if (!File.Exists(path))
                return null;

            return File.ReadAllText(path);
        }

    }
}
