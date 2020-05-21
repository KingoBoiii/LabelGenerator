namespace LabelGenerator.Data {
    public class AppData {
        private static AppData s_Instance;

        public static AppData Instance {
            get {
                if(s_Instance == null) {
                    s_Instance = new AppData();
                }
                return s_Instance;
            }
            private set {
                s_Instance = value;
            }
        }

        public string Template { get; set; } = string.Empty;
    }
}
