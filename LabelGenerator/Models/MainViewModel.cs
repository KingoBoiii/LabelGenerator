using System;

namespace LabelGenerator.Models {
    using LabelGenerator.Utils;

    public class MainViewModel {
        public const int MIN_YEAR = 0;
        public const int MAX_YEAR = 99;

        public const int MIN_WEEK = 1;
        public const int MAX_WEEK = 52;

        public const int MIN_NUMBER = 0;
        public const int MAX_NUMBER = 9999;

        private int m_Year;
        public int Year {
            get { return m_Year; }
            set { m_Year = Math.Min(Math.Max(value, MIN_YEAR), MAX_YEAR); }
        }

        private int m_Week;
        public int Week {
            get { return m_Week; }
            set { m_Week = Math.Min(Math.Max(value, MIN_WEEK), MAX_WEEK); }
        }

        private int m_Number;
        public int Number {
            get { return m_Number; }
            set { m_Number = Math.Min(Math.Max(value, MIN_NUMBER), MAX_NUMBER); }
        }

        public string SerialNumber {
            get {
                string fYear = StringUtil.FormatString(Year, 2);
                string fWeek = StringUtil.FormatString(Week, 2);
                string fNumber = StringUtil.FormatString(Number, 4);
                string serialNumber = $"E{fYear}{fWeek}{fNumber}";
                return serialNumber;
            }
        }

        private string m_IMEINumber;
        public string IMEINumber { 
            get { return m_IMEINumber; }
            set { m_IMEINumber = value; }
        }

        public MainViewModel(int year = 0, int week = 1, int number = 0) {
            this.Year = year;
            this.Week = week;
            this.Number = number;
            this.IMEINumber = new string('0', 15);
        }
    }
}
