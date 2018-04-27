using fo_dicom_viewer.Helpers;
using fo_dicom_viewer.ViewModels;
using fo_dicom_viewer.Views;
using System;
using System.Windows;

namespace fo_dicom_viewer
{
    /// <summary>
    /// Interaction logic for ViewerWindow.xaml
    /// </summary>
    public partial class ViewerWindow : Window
    {
        public int ViewerPosition = -1;
        public ViewerLayoutManager LayoutManager;

        public ViewerWindow()
        {
            InitializeComponent();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Dispose();
        }


        /// <summary>
        /// Only way to clear the memory used
        /// </summary>
        public void Dispose()
        {
            try
            {
                this.LayoutManager.RemoveView2dWindow(this);

                Viewer2d Viewer2DWindow = (this.Content as Viewer2d);
                

                Viewer2dViewModel Viewer2ViewModel = (Viewer2DWindow.DataContext as Viewer2dViewModel);

                Viewer2ViewModel.cleanup();


                

                GC.SuppressFinalize(Viewer2ViewModel);
                GC.SuppressFinalize(this);
                this.DataContext = null;
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
