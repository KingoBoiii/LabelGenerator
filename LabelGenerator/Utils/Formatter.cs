using System.Collections.Generic;

namespace LabelGenerator.Utils {
    using LabelGenerator.Data;

    public static class Formatter {
        public class FormattingData {
            public string WordToReplace { get; set; }
            public string Word { get; set; }
        }
        private static Dictionary<string, string> _formattingDatas = new Dictionary<string, string>() {
            { "#SERIALNUMBER#", "" },
            { "#IMEINUMBER#", "" },
        };

        public static string GenerateStringOutput(string serialNumber, string imeiNumber) {
            string result = AppData.Instance.Template;

            _formattingDatas["#SERIALNUMBER#"] = serialNumber;
            _formattingDatas["#IMEINUMBER#"] = imeiNumber;

            foreach (var data in _formattingDatas) {
                result = result.Replace(data.Key, data.Value);
            }
            return result;
        }
    }
}
