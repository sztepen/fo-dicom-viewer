using Dicom.Imaging;
using Dicom.Log;
using fo_dicom_viewer.ViewModels;
using fo_dicom_viewer.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fo_dicom_viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ImageManager.SetImplementation(WPFImageManager.Instance);
            LogManager.SetImplementation(ConsoleLogManager.Instance);

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            Title = "FO-DICOM | Viewer  v" + version;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dicomFilesPath = txtDicomFilesPath.Text;
            var MainViewerWindow = new ViewerWindow();

            var Viewer2DWindow = new Viewer2d();
            var Viewer2ViewModel = new Viewer2dViewModel();
            Viewer2DWindow.DataContext = Viewer2ViewModel;

            MainViewerWindow.Content = Viewer2DWindow;
            MainViewerWindow.Show();

            //load dicom files
            Viewer2ViewModel.LoadDicomFilesFromPath(dicomFilesPath);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string dicomFilesPath = txtDicomFilesPath.Text;
             
            //create tool bar window for this study

            var toolbarWindow = new ToolbarWindow();
            var toolbarViewModel = new ToolbarViewModel();
            toolbarWindow.DataContext = toolbarViewModel;

            toolbarWindow.Left = 0;
            toolbarWindow.Top = 0;
            toolbarWindow.Width = SystemParameters.PrimaryScreenWidth;

            toolbarWindow.Show();

            //load files from folder
            toolbarWindow.LoadThumbnails(dicomFilesPath);
        }
    }
}
