using fo_dicom_viewer.Helpers;
using fo_dicom_viewer.Models;
using fo_dicom_viewer.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace fo_dicom_viewer.Views
{
    /// <summary>
    /// Interaction logic for StudyRootWindow.xaml
    /// </summary>
    public partial class ThumbnailsWindow : Window
    {

        public ViewerLayoutManager layoutManager;

        public ThumbnailsWindow()
        {
            InitializeComponent();
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            var MainViewerWindow = new ViewerWindow();

            var Viewer2DWindow = new Viewer2d();
            var Viewer2ViewModel = new Viewer2dViewModel();
            Viewer2DWindow.DataContext = Viewer2ViewModel;

            //add to layouts
            //layoutManager.Viewer2dWindowsList.Add(MainViewerWindow);
            //layoutManager.SetPositionForNewViewer(MainViewerWindow);
            layoutManager.AddNewViewerWindow(MainViewerWindow);

            MainViewerWindow.Content = Viewer2DWindow;
            MainViewerWindow.Show();

            var dicomSeries = ((sender as ListBox).SelectedItem as DicomSeries);
            //load dicom files
            //Viewer2ViewModel.LoadDicomFilesFromStudy(dicomSeries);
            Viewer2ViewModel.LoadBitmapsFromStudy(dicomSeries);

            
            
        }
    }
}
