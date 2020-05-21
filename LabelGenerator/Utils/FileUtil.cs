using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Win32;

namespace LabelGenerator.Utils {
    public static class FileUtil {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filter"></param>
        public static void OpenAndReadFileDialog(out string data, string filter = "Text Files (*.txt)|*.txt") {
            data = string.Empty;
            // Configure open file dialog box
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog.Filter = filter;

            // Show open file dialog box
            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true) {
                string filepath = openFileDialog.FileName;
                data = ReadFile(filepath);
            }
        }

        /// <summary>
        /// Reading text data from a textfile, and returns the string data
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string ReadFile(string filepath) {
            string data = string.Empty;
            if(File.Exists(filepath) == false) {
                Trace.WriteLine($"File at given path; {filepath}, doesn't exists!", "FileUtil.ReadFile(string)");
                return string.Empty;
            }

            using (FileStream fs = File.OpenRead(filepath)) {
                byte[] bytes = new byte[1024];
                UTF8Encoding encoding = new UTF8Encoding(true);
                fs.Read(bytes, 0, bytes.Length);
                data = encoding.GetString(bytes);

                fs.Close();
                fs.Dispose();
            }

            return data;
        }

        /// <summary>
        /// Writing <paramref name="data"/> to a text file, to the given <paramref name="filepath"/> 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <param name="data"></param>
        public static void WriteFile(string filepath, string data) {
            string path = filepath;
            if (File.Exists(path) == true) {
                File.Delete(path);
            }

            using (FileStream fs = File.Create(path)) {
                byte[] bytes = new UTF8Encoding(true).GetBytes(data);
                fs.Write(bytes, 0, bytes.Length);

                fs.Close();
                fs.Dispose();
            }
        }
    }
}
