using System.Collections.Generic;

namespace LabelGenerator.Utils {
    using LabelGenerator.Data;

    public static class Formatter {
        public class FormattingData {
            public string WordToReplace { get; set; }
            public string Word { get; set; }
        }
        private static List<FormattingData> formattingDatas = new List<FormattingData>() {
            new FormattingData{ WordToReplace="#SERIALNUMBER#", Word="" },
            new FormattingData{ WordToReplace="#IMEINUMBER#", Word="" },
        };

        public static string GenerateStringOutput(string serialNumber, string imeiNumber) {
            string result = AppData.Instance.Template;

            formattingDatas[0].Word = serialNumber;
            formattingDatas[1].Word = imeiNumber;

            foreach (var data in formattingDatas) {
                result = result.Replace(data.WordToReplace, data.Word);
            }
            return result;
        }
    }
}
