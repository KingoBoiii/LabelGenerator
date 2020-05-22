namespace LabelGenerator.Models {
    public class WindowModel {
        public string WindowTitle { get; set; } = "Label Generator";
        public double WindowWidth { get; set; } = 300.0;
        public double WindowHeight { get; set; } = 450.0;

        public object ChildDataContext { get; set; } = null;
    }
}