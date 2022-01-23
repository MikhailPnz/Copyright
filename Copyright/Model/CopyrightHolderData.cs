using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copyright.Model
{
    internal class CopyrightHolderData : ICopyrightHolderData
    {
        private string sourcePath_;
        private string finalPath_;
        private string fileType1_;
        private string fileType2_;
        private bool fileTypeAll_;
        
        private int processedFiles;
        private int noMatchesFound;
        private readonly List<CopyrightHolder> _author;

        public CopyrightHolderData()
        {
            _author = new List<CopyrightHolder>();
            processedFiles = 0;
            noMatchesFound = 0;
            fileTypeAll_ = false;
        }

        public string SourcePath
        {
            get { return sourcePath_; }
            set { sourcePath_ = value; }
        }

        public string FinalPath
        {
            get { return finalPath_; }
            set { finalPath_ = value; }
        }
        
        public string FileType1
        {
            get { return fileType1_; }
            set { fileType1_ = value; }
        }

        public string FileType2
        {
            get { return fileType2_; }
            set { fileType2_ = value; }
        }

        public bool FileTypeAll
        {
            get { return fileTypeAll_; }
            set { fileTypeAll_ = value; }
        }      

        public int ProcessedFiles
        {
            get { return processedFiles; }
            set { processedFiles = value; }
        }

        public int NoMatchesFound
        {
            get { return noMatchesFound; }
            set { noMatchesFound = value; }
        }

        public IEnumerable<CopyrightHolder> GetAllCopyrightHolders()
        {
            return _author;
        }

        public CopyrightHolder GetCopyrightHolder(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveCopyrightHolder(CopyrightHolder copyright)
        {
            _author.Add(copyright);            
        }

        public void CountNumberOfFiles_CopyrightHolder(string name)
        {
            foreach (CopyrightHolder author in _author.Where(ff => ff.Name == name))
            {
                author.NumberOfFiles++;
            }
        }

        public void ClearCopyrightHolder()
        {
            _author.Clear();
        }
    }
}
