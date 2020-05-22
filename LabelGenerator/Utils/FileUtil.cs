using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;

namespace LabelGenerator.Utils {
    public static class FileUtil {
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

        public static bool DoesFileExists(string filepath) {
            return File.Exists(filepath);
        }

        /// <summary>
        /// Opens a File Dialog to get the <paramref name="filepath"/> of a file.
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="filter"></param>
        /// <param name="initDirectory"></param>
        public static void OpenDialog(out string filepath, string filter, Environment.SpecialFolder initDirectory = Environment.SpecialFolder.MyDocuments) {
            OpenFileDialog fileDialog = new OpenFileDialog {
                Filter = filter, ShowReadOnly = true, Multiselect = false, Title = "Open File Dialog",
                ValidateNames = true, CheckFileExists = true, CheckPathExists = true, 
                InitialDirectory = Environment.GetFolderPath(initDirectory),
            };

            Nullable<bool> result = fileDialog.ShowDialog();
            if(result == true) {
                filepath = fileDialog.FileName;
                return;
            }
            filepath = string.Empty;
        }
    }
}
