using Dicom;
using Dicom.Imaging;
using fo_dicom_viewer.Helpers;
using fo_dicom_viewer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace fo_dicom_viewer.ViewModels
{
    public class Viewer2dViewModel : ViewModelBase
    {

        #region Properties

        private List<DicomFile> _loadedDicomFiles;
        private List<BitmapSource> _loadedBitmapSources;

        private int currentImageIndex;
        private int numberOfImages;
    

        public int CurrentImageIndex
        {
            get
            {
                return currentImageIndex;
            }
            set
            {
                currentImageIndex = value;
                OnPropertyChanged("CurrentImage");
                OnPropertyChanged("CurrentImageIndex");
            }
        }

        public int NumberOfImages
        {
            get
            {
                return this.numberOfImages;
            }
            set
            {
                if (value == this.numberOfImages)
                {
                    return;
                }
                this.numberOfImages = value;
                OnPropertyChanged("NumberOfImages");
                this.CurrentImageIndex = 0;
            }
        }


        public BitmapSource CurrentImage
         => NumberOfImages > 0 ? _loadedBitmapSources[Math.Max(CurrentImageIndex - 1, 0)] : null;

        /*
        private BitmapSource currentImage;
        public BitmapSource CurrentImage
        {
            get
            {
                if (NumberOfImages > 0)
                {
                    //keeping list of WriteableBitmap requires a lot of memory so we keep the dicom list and convert to bitmap on the fly
                    if (_loadedDicomFiles[Math.Max(CurrentImageIndex - 1, 0)].Dataset.Contains(DicomTag.PixelData))
                    {
                        var dicomImage = new DicomImage(_loadedDicomFiles[Math.Max(CurrentImageIndex - 1, 0)].Dataset);
                        WriteableBitmap dicomBitmap = dicomImage.RenderImage(0).As<WriteableBitmap>();
                        return dicomBitmap;
                    }else {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            set
            {
                //set slider
                currentImage = value;
                OnPropertyChanged("CurrentImage");
            }
        }
        */
        #endregion

        #region Commands 


        #endregion


        #region Constructor  
        public Viewer2dViewModel()
        {

        }

        public void cleanup()
        {
            _loadedBitmapSources = null;
            _loadedDicomFiles = null; 
        }


        #endregion


        #region functions


        public void LoadDicomFilesFromPath(string path)
        {
            //load dicom files in path
            LoadDicomFilesAsync(path);
        }


        /// <summary>
        /// Loads images as writablebitmaps to list - consumes a lot of memory but works fast
        /// Frames support added
        /// </summary>
        /// <param name="series"></param>
        public void LoadBitmapsFromStudy(DicomSeries series)
        {
            //load dicom files from series 
            _loadedBitmapSources = new List<BitmapSource>();
            NumberOfImages = 0;

            foreach (var dicomFile in series.Instances)
            {
                try
                {
                    if (dicomFile.Dataset.Contains(DicomTag.PixelData))
                    {
                        var dicomImage = new DicomImage(dicomFile.Dataset);
                        var frames = Enumerable.Range(0, dicomImage.NumberOfFrames).Select(frame => dicomImage.RenderImage(frame).As<WriteableBitmap>());

                        //WriteableBitmap dicomBitmap = dicomImage.RenderImage(0).As<WriteableBitmap>();
                       // _loadedBitmapSources.Add(dicomBitmap);

                        _loadedBitmapSources.AddRange(frames.ToList());
                    }


                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(ex.InnerException);
                }
            }

            NumberOfImages = _loadedBitmapSources.Count;
        }


        /// <summary>
        /// Not used because this is slow
        /// </summary>
        /// <param name="series"></param>
        public void LoadDicomFilesFromStudy(DicomSeries series)
        {
            //load dicom files from series 
            _loadedDicomFiles = new List<DicomFile>();
            NumberOfImages = 0;

            foreach (var dicomFile in series.Instances)
            {
                try
                {

                    _loadedDicomFiles.Add(dicomFile);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(ex.InnerException);
                }
            }

            NumberOfImages = _loadedDicomFiles.Count;
        }
         


        /// <summary>
        /// Loads dicom files from disk
        /// Todo- needs to add support for frames
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task LoadDicomFilesAsync(string path)
        {
            _loadedDicomFiles = new List<DicomFile>();
            NumberOfImages = 0;
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
            {
                try
                {
                    DicomFile dicomFile = await DicomFile.OpenAsync(fileName);
                    _loadedDicomFiles.Add(dicomFile);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(ex.InnerException);
                }
            }
            //NumberOfImages = NumberOfImages + 1;
            NumberOfImages = _loadedDicomFiles.Count;

        }

        #endregion



    }
}
