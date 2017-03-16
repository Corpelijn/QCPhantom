using openDicom.File;
using openDicom.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCAnalyser.DICOM
{
    public class DICOMImage
    {
        #region "Attributes"



        #endregion

        #region "Constructors"



        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        public void ReadDICOMFile()
        {
            DataElementDictionary dataElementDictionary = new DataElementDictionary();

            UidDictionary uidDictionary = new UidDictionary();

            try
            {
                dataElementDictionary.LoadFrom("dicom-elements-2007.dic", DictionaryFileFormat.BinaryFile);
                uidDictionary.LoadFrom("dicom-uids-2007.dic", DictionaryFileFormat.BinaryFile);
            }
            catch (Exception dictionaryException)
            {
                Console.Error.WriteLine("Problems processing dictionaries:\n" + dictionaryException);
                return;
            }

            AcrNemaFile file = null;

            string fileName = @"J:\LZR QCPhantom\DICOMOBJ\DICOMOBJ\1";

            try
            {
                if (DicomFile.IsDicomFile(fileName))
                    file = new DicomFile(fileName, false);
                else if (AcrNemaFile.IsAcrNemaFile(fileName))
                    file = new AcrNemaFile(fileName, false);
                else
                    Console.Error.WriteLine("Selected file is wether a DICOM nor an ACR-NEMA file.");
            }
            catch (Exception dicomFileException)
            {
                Console.Error.WriteLine("Problems processing DICOM file:\n" + dicomFileException);
                return;
            }
        }

        #endregion

        #region "Static Methods"



        #endregion

        #region "Inherited Methods"



        #endregion
    }
}
