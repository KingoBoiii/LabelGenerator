namespace LabelGenerator.Utils {
    public static class StringUtil {
        /// <summary>
        /// Converts a number into a formatted string, depending on the count value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string FormatString(int value, int count) {
            string v = value.ToString();
            if (v.Length > count) return new string('9', count);

            string format = new string('0', count);
            int valueLength = value.ToString().Length;
            string result = format.Insert(format.Length - valueLength, value.ToString());
            return result.Remove(format.Length);
        }
    }
}
