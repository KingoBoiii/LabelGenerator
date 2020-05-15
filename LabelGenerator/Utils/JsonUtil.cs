using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace LabelGenerator.Utils {
    public static class JsonUtil {
        /// <summary>
        /// Creates a .json file at <paramref name="filepath"/>, 
        /// and saves the <paramref name="data"/> into the .json file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <param name="data"></param>
        public static void SaveJson<T>(string filepath, T data) {
            try {
                string jsonData = JsonConvert.SerializeObject(data);

                bool doesFileExists = File.Exists(filepath);
                if (!doesFileExists) {
                    File.Create(filepath);
                }

                File.WriteAllText(filepath, jsonData);

#if DEBUG
                // Trace.WriteLine($"Successfully saved {filepath}", "JsonUtil.SaveJson<T>");
#endif
            } catch (Exception ex) {
                Trace.WriteLine($"Exception: {ex.Message}", "JsonUtil.SaveJson<T>");
            }
        }

        /// <summary>
        /// Loads a .json file, from the given <paramref name="filepath"/>,
        /// and return the <paramref name="data"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <param name="data"></param>
        public static void LoadJson<T>(string filepath, out T data) {
            try {
                string jsonString = File.ReadAllText(filepath);
                data = JsonConvert.DeserializeObject<T>(jsonString);
#if DEBUG
                if(data != null) {
                    // Trace.WriteLine($"Successfully loaded {filepath}", "JsonUtil.LoadJson<T>");
                }
#endif
            } catch (Exception ex) {
                Trace.WriteLine($"Exception: {ex.Message}", "JsonUtil.LoadJson<T>");
                data = default;
            }
        }
    }
}
