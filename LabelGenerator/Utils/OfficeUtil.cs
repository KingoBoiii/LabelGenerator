using System.Linq;
using System.Collections.ObjectModel;
using IronXL;

namespace LabelGenerator.Utils {
    public static class OfficeUtil {
        public static ObservableCollection<string> OpenExcelFile(string filepath) {
            if(FileUtil.DoesFileExists(filepath) == false) {
                return null;
            }

            WorkBook workbook = WorkBook.Load(filepath);
            WorkSheet sheet = workbook.WorkSheets.First();

            ObservableCollection<string> cellData = new ObservableCollection<string>();
            
            int rowCount = 0;
            Range useableRange = sheet["A1:A10"];
            foreach (var cell in useableRange) {
                if(cell.IsEmpty) {
                    break;
                }
                cellData.Add(cell.StringValue);
                rowCount++;
            }

            workbook.Close();
            return cellData;
        }
    }
}
