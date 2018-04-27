namespace fo_dicom_viewer.Models
{
    public class WindowPositionOnScreen
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public double Height { get; set; }

        public WindowPositionOnScreen(double left, double top, double height)
        {
            Left = left;
            Top = top;
            Height = height;
        }
    }
}
