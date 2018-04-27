using fo_dicom_viewer.Helpers;
using fo_dicom_viewer.ViewModels;
using System;
using System.Windows;

namespace fo_dicom_viewer.Views
{
    /// <summary>
    /// Interaction logic for ToolbarWindow.xaml
    /// </summary>
    public partial class ToolbarWindow : Window
    {
        public ViewerLayoutManager LayoutManager;
        
         
        public ToolbarWindow()
        {
            InitializeComponent();

            LayoutManager = new ViewerLayoutManager(this);
        }

        public void LoadThumbnails(string dicomPath)
        {
            LayoutManager.thumbnailsWindow = new ThumbnailsWindow();
            var thumbnailsViewModel = new ThumbnailsViewModel();
            LayoutManager.thumbnailsWindow.DataContext = thumbnailsViewModel;

            LayoutManager.thumbnailsWindow.layoutManager = LayoutManager;


            
            LayoutManager.thumbnailsWindow.Left = 0;
            LayoutManager.thumbnailsWindow.Top = this.Height;
            LayoutManager.thumbnailsWindow.Height = SystemParameters.PrimaryScreenHeight - this.Height;

            LayoutManager.thumbnailsWindow.Show();

            //load dicom files
            thumbnailsViewModel.LoadDicomFilesToStudyAsync(dicomPath);

        }
 

        private void Window_Closed(object sender, EventArgs e)
        {
            LayoutManager.CloseAllView2dWindows();
            LayoutManager.thumbnailsWindow.Close();
        }
    }
}
