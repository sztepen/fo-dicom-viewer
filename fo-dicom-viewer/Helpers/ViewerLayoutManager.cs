using fo_dicom_viewer.Models;
using fo_dicom_viewer.Views;
using System.Collections.Generic;
using System.Windows;

namespace fo_dicom_viewer.Helpers
{
    public class ViewerLayoutManager
    {
        public List<ViewerWindow> Viewer2dWindowsList { get; set; }
        public ThumbnailsWindow thumbnailsWindow { get; set; }
        public ToolbarWindow toolbarWindow { get; set; }

        public double CurrentImageWindowLevel { get; set; }


        public ViewerLayoutManager(ToolbarWindow toolbar)
        {
            Viewer2dWindowsList = new List<ViewerWindow>();
            toolbarWindow = toolbar;
        }

        public void RemoveView2dWindow(ViewerWindow viewer)
        {
            int indexToRemove = -1;

            for (int i = 0; i < Viewer2dWindowsList.Count; i++)
            {
                if (Viewer2dWindowsList[i].ViewerPosition == viewer.ViewerPosition)
                {
                    indexToRemove = i;
                }
            }

            if (indexToRemove > -1)
            {
                Viewer2dWindowsList.RemoveAt(indexToRemove);
            }
           


        }

        public void CloseAllView2dWindows()
        {
            foreach (var view in Viewer2dWindowsList)
            {
                view.Close();
            }
        }

        public void AddNewViewerWindow(ViewerWindow viewer)
        {
            viewer.LayoutManager = this;
            SetPositionForNewViewer(viewer);
            viewer.ViewerPosition = Viewer2dWindowsList.Count;
            Viewer2dWindowsList.Add(viewer);
            RealignViews();
        }


        private void SetPositionForNewViewer(ViewerWindow viewer)
        {
            viewer.Left = thumbnailsWindow.Width ;
            viewer.Top = toolbarWindow.Height - 8;
            viewer.Height = SystemParameters.PrimaryScreenHeight - toolbarWindow.Height - 24;//64 is topbar
            viewer.Width = SystemParameters.PrimaryScreenWidth - thumbnailsWindow.Width;
        }

        private void RealignViews()
        {

            if (Viewer2dWindowsList.Count == 2)
            {
                ViewerWindow viewer1 = Viewer2dWindowsList[0];
                ViewerWindow viewer2 = Viewer2dWindowsList[1];

                viewer1.Width = viewer1.Width / 2;
                viewer2.Width = viewer2.Width / 2;
                                
                viewer1.Left = thumbnailsWindow.Width;
                viewer2.Left = viewer1.Width + thumbnailsWindow.Width;
            }
        }
    }
}
