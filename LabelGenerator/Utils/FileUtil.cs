using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;

namespace LabelGenerator.Utils {
    public static class FileUtil {
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
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string ReadFile(string filepath) {
            string data = string.Empty;
            StreamReader sr = new StreamReader(filepath);

            try {
                data = sr.ReadToEnd();
            } catch (Exception ex) {
                data = $"Error: {ex.Message}";
                Trace.WriteLine($"{ex.Message}", "FileUtil.ReadFile");
            } finally {
                sr.Close();
                sr.Dispose();
            }

            return data;
        }

        /// <summary>
        /// Save textfiles to <paramref name="filepath"/> with the given <paramref name="data"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <param name="data"></param>
        public static void WriteFile(string filepath, string data) {
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
