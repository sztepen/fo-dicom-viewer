using fo_dicom_viewer.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace fo_dicom_viewer.Views
{
    /// <summary>
    /// Interaction logic for Viewer2d.xaml
    /// </summary>
    public partial class Viewer2d : UserControl
    {

        private bool isMouseDown;
        private Point initialMousePoint;
 
         
        public Viewer2d()
        {
            InitializeComponent();

          
            isMouseDown = false;
         
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
 

        private void ImageViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                Point position = e.GetPosition(this);
       
                //get viewmodel
                var viewModel = (this.DataContext as Viewer2dViewModel);
                viewModel.GenerateCurrentImage(initialMousePoint, position);
            }


        }

        private void ImageViewer_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Cursor = Cursors.Hand;
            initialMousePoint = e.GetPosition(this); 
            isMouseDown = true;
        }

        private void ImageViewer_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = false;
            Cursor = Cursors.Arrow;
        }
    }
}
