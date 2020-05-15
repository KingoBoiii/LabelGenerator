using System.IO;
using System.Text;

namespace LabelGenerator.Utils {
    public static class FileUtil {
        /// <summary>
        /// Save textfiles to <paramref name="filepath"/> with the given <paramref name="data"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <param name="data"></param>
        public static void SaveFile(string filepath, string data) {
            if (File.Exists(filepath)) {
                File.Delete(filepath);
            }

            using (FileStream fs = File.Create(filepath)) {
                byte[] bytes = new UTF8Encoding(true).GetBytes(data);
                fs.Write(bytes, 0, bytes.Length);

                fs.Close();
                fs.Dispose();
            }
        }
    }
}
