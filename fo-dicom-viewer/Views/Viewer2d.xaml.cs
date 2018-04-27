using System.Windows.Controls;
using System.Windows.Input;

namespace fo_dicom_viewer.Views
{
    /// <summary>
    /// Interaction logic for Viewer2d.xaml
    /// </summary>
    public partial class Viewer2d : UserControl
    {
        public Viewer2d()
        {
            InitializeComponent();
        }

        private void ImageViewer_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                double valueToSet = ImageSliderBar.Value + 1;

                if (valueToSet <= ImageSliderBar.Maximum)
                {
                    ImageSliderBar.Value = valueToSet;
                }

            }
            else
            {
                double valueToSet = ImageSliderBar.Value - 1;

                if (valueToSet >= ImageSliderBar.Minimum)
                {
                    ImageSliderBar.Value = valueToSet;
                }
            }
        }

     

       
    }
}
