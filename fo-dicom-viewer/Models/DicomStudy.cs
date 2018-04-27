using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace fo_dicom_viewer.Models
{
    public partial class DicomStudy
    {
        public string StudyInstanceUid { get; set; }
        public string PatientName { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientMiddleName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientId { get; set; }
        public string StudyDate { get; set; }
        public string AccessionNumber { get; set; }
        public string StudyDescription { get; set; }
        public string PatientSex { get; set; }
        public List<DicomSeries> Series { get; set; }

        public DicomStudy()
        {
            Series = new List<DicomSeries>();
        }


        /// <summary>
        /// Loads properties from a dicom file
        /// </summary>
        /// <param name="dicomFile"></param>
        public DicomStudy(Dicom.DicomFile dicomFile)
        {
            Series = new List<DicomSeries>();

            try
            { 
                StudyInstanceUid = dicomFile.Dataset.Get<string>(Dicom.DicomTag.StudyInstanceUID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.InnerException);
            }

        }

    }

    public partial class DicomSeries
    {
        public string SeriesInstanceUid { get; set; }
        public string SeriesNumber { get; set; }
        public string SenderAeTitle { get; set; } 
        public string Modality { get; set; }  
        public string SeriesDescription { get; set; }
        public string StudyInstanceUid { get; set; }
        public BitmapSource Thumbnail { get; set; } 
        public List<Dicom.DicomFile> Instances { get; set; }
         

        public DicomSeries()
        {
            Instances = new List<Dicom.DicomFile>();
            Thumbnail = null;
        }


        /// <summary>
        /// Loads properties from a dicom file
        /// </summary>
        /// <param name="dicomFile"></param>
        public DicomSeries(Dicom.DicomFile dicomFile)
        {
            Instances = new List<Dicom.DicomFile>();

            try
            {
                SeriesInstanceUid = dicomFile.Dataset.Get<string>(Dicom.DicomTag.SeriesInstanceUID);
                SeriesNumber = dicomFile.Dataset.Get<string>(Dicom.DicomTag.SeriesNumber);
                Modality = dicomFile.Dataset.Get<string>(Dicom.DicomTag.Modality);
                SeriesDescription = dicomFile.Dataset.Get<string>(Dicom.DicomTag.SeriesDescription);
                StudyInstanceUid = dicomFile.Dataset.Get<string>(Dicom.DicomTag.StudyInstanceUID); 

                //try generate the thumbnail

                if (Thumbnail == null)
                {
                    if (dicomFile.Dataset.Contains(Dicom.DicomTag.PixelData))
                    {
                        var dicomImage = new Dicom.Imaging.DicomImage(dicomFile.Dataset);
                        WriteableBitmap dicomBitmap = dicomImage.RenderImage(0).As<WriteableBitmap>();
                        Thumbnail= dicomBitmap;
                    } 
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.InnerException);
            }

        }
    }
}
