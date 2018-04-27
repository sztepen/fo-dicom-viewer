using Dicom;
using fo_dicom_viewer.Helpers;
using fo_dicom_viewer.Models;
using fo_dicom_viewer.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace fo_dicom_viewer.ViewModels
{
    public class ThumbnailsViewModel : ViewModelBase
    {
        #region Properties

        private DicomStudy study;        
        public DicomStudy Study
        {
            get
            {
                return study;
            }
            set
            {
                study = value;
                OnPropertyChanged("Study"); 
            }
        }

        private int selectedSeriesIndex;
        public int SelectedSeriesIndex
        {
            get
            {
                return selectedSeriesIndex;
            }
            set
            {
                selectedSeriesIndex = value;
                OnPropertyChanged("SelectedSeriesIndex");
            }
        }

        private DicomSeries selectedSeries;
        public DicomSeries SelectedSeries
        {
            get
            {
                return selectedSeries;
            }
            set
            {
                selectedSeries = value;
                OnPropertyChanged("SelectedSeries");
            }
        }
        
        #endregion

        #region Commands  
        public RelayCommand ThumbnailMouseDoubleClickCommand { get; private set; }
        
        #endregion


        #region Constructor  
        public ThumbnailsViewModel()
        {
           
        }


        #endregion

        #region Command implementations  





        #endregion


        #region dicom loading functions

        /// <summary>
        /// Loads dicom files from disk to a study object
        /// Todo - needs to add support for frames
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task LoadDicomFilesToStudyAsync(string path)
        {
            var dicomFiles = new List<DicomFile>();
          
            //load all files from dir
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
            {
                try
                {
                    DicomFile dicomFile = await DicomFile.OpenAsync(fileName);
                    dicomFiles.Add(dicomFile);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(ex.InnerException);
                }
            }

            //now sort and add to study object
            
            var studies = new List<DicomStudy>();

            foreach (var dicomFile in dicomFiles)
            {
                FindMatchingSeriesOrSplit(studies, dicomFile);
            }

            Study = studies[0];
        }


        /// <summary>
        /// This method will split dicom file to series and add to study object
        /// </summary>
        /// <param name="study"></param>
        /// <param name="dicomFile"></param>
        private void FindMatchingSeriesOrSplit(List<DicomStudy> studies, DicomFile dicomFile)
        {

            var seriesInstanceUID = dicomFile.Dataset.Get<string>(DicomTag.SeriesInstanceUID);
            var studyInstanceUID = dicomFile.Dataset.Get<string>(DicomTag.StudyInstanceUID);


            bool matchingStudyFound = false; 
            //first add study to list
            foreach (var study in studies)
            {
                //check if study is in list
                if (study.StudyInstanceUid == studyInstanceUID)
                {
                    matchingStudyFound = true;

                    bool matchingSeriesFound = false;
                    foreach (var series in study.Series)
                    {
                        if (series.SeriesInstanceUid == seriesInstanceUID)
                        {
                            matchingSeriesFound = true;
                            //if series found then add the dicomfile to instance
                            series.Instances.Add(dicomFile);
                        }
                    }

                    //add series if matching series not found
                    if (matchingSeriesFound == false)
                    {
                        DicomSeries dicomSeries = new DicomSeries(dicomFile);
                        study.Series.Add(dicomSeries);
                    }
                } 
            }

            //check if study is in list if not add new study and add the series and instance
            if (matchingStudyFound == false)
            {
                DicomStudy dicomStudy = new DicomStudy(dicomFile);
                DicomSeries dicomSeries = new DicomSeries(dicomFile);
                dicomSeries.Instances.Add(dicomFile);
                dicomStudy.Series.Add(dicomSeries);

                studies.Add(dicomStudy);
            } 


        }


        #endregion

    }
}
