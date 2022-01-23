using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copyright.Model
{
    public interface ICopyrightHolderData
    {
        string SourcePath { get; set; }
        string FinalPath { get; set; }
        string FileType1 { get; set; }
        string FileType2 { get; set; }
        bool FileTypeAll { get; set; }       
        int ProcessedFiles { get; set; }
        int NoMatchesFound { get; set; }

        IEnumerable<CopyrightHolder> GetAllCopyrightHolders();

        CopyrightHolder GetCopyrightHolder(int id);

        void SaveCopyrightHolder(CopyrightHolder copyright);

        void ClearCopyrightHolder();

        void CountNumberOfFiles_CopyrightHolder(string name);
    }
}
