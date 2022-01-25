using Copyright.Model;
using Copyright.View;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Copyright.Presenter
{
    public class CopyrightPresenter
    {
        private readonly ICopyrightView _view;
        private readonly ICopyrightHolderData _data;

        public CopyrightPresenter(ICopyrightView view, ICopyrightHolderData data)
        {
            _view = view;
            view.Presenter = this;
            _data = data;
        }

        public void UpdateCopyrightHolderList()
        {
            var copyrightHolderNames = from copyrightHolder in _data.GetAllCopyrightHolders() select copyrightHolder.Name;
            var copyrightHolderNumberOfFiles = from copyrightHolder in _data.GetAllCopyrightHolders() select copyrightHolder.NumberOfFiles;
        }

        public void SourcePathSet(string path)
        {
            _data.SourcePath = path;
        }

        public void FinalPathSet(string path)
        {
            _data.FinalPath = path;
        }
        
        public void FileTypeTxtSet(string type)
        {
            _data.FileType1 = type;
            _data.FileType2 = type;
        }

        public void FileTypeC_CppSet(string type1, string type2)
        {
            _data.FileType1 = type1;
            _data.FileType2 = type2;
        }

        public void FileTypeAllSet(bool type)
        {
            _data.FileTypeAll = type;            
        }

        public void CountProcessedFiles()
        {
            int processedFiles = _data.ProcessedFiles;            
            _data.ProcessedFiles = ++processedFiles;
        }        

        public void CountNoMatchesFound()
        {
            int noMatchesFound = _data.NoMatchesFound;            
            _data.NoMatchesFound = ++noMatchesFound;
        }        

        public void SaveCopyrightHolder(string name, int numberOfFiles)
        {
            CopyrightHolder copyrightHolder = new CopyrightHolder { Name = name, NumberOfFiles = numberOfFiles };
            _data.SaveCopyrightHolder(copyrightHolder);
        }


      
        public void Reset()
        {            
            _data.ProcessedFiles = 0;
            _data.NoMatchesFound = 0;            
            _data.ClearCopyrightHolder();
        }

        public void ReaderAndFilterFilesInArchive(string file)
        {
            using (ZipArchive archive = ZipFile.OpenRead(file))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    FilterFiles(entry);
                }
            }
        }
       
        public void FilterFiles(ZipArchiveEntry entry)
        {
            string fileType1 = _data.FileType1;
            string fileType2 = _data.FileType2;
            bool allFiles = _data.FileTypeAll;

            if (!allFiles)
            {
                if (entry.FullName.EndsWith(fileType1, StringComparison.OrdinalIgnoreCase) ||
                            entry.FullName.EndsWith(fileType2, StringComparison.OrdinalIgnoreCase))
                {
                    StreamReaderFile(entry);
                }
            }
            else
            {
                StreamReaderFile(entry);
            }
        }

        public void FilterFiles(string file)
        {
            string fileType1 = _data.FileType1;
            string fileType2 = _data.FileType2;
            bool allFiles = _data.FileTypeAll;

            if (!allFiles)
            {
                if (file.EndsWith(fileType1, StringComparison.OrdinalIgnoreCase) ||
                                            file.EndsWith(fileType2, StringComparison.OrdinalIgnoreCase))
                {
                    StreamReaderFile(file);
                }
            }
            else
            {
                StreamReaderFile(file);
            }
        }

        public void StreamReaderFile(string file)
        {
            StreamReader doc = new StreamReader(file);
            SearchSignatureInStream(doc, Path.GetFileName(file));
            CountProcessedFiles();
        }

        public void StreamReaderFile(ZipArchiveEntry entry)
        {
            StreamReader doc = new StreamReader(entry.Open());
            SearchSignatureInStream(doc, entry.Name.Replace(".", "_zip."));
            CountProcessedFiles();
        }

        public void SearchSignatureInStream(StreamReader doc, string fileName)
        {
            string finalPath = _data.FinalPath;
            string line;
            int matchesFound = 0;

            if (!String.IsNullOrEmpty(line = doc.ReadToEnd()))
            {
                string line2 = line;
                string pattern1 = "Copyright\\s\\(c\\)";
                string pattern2 = "Copyright\\(C\\)";
                string pattern2_ = "Copyright\\s\\(C\\)";
                string pattern3 = "Copyright";
                string pattern4 = "/\\*(.*?)\\*/"; // подстрока в /* */                
                //string pattern8 = "//(.+?)(?:\n|$)"; // подстрока в //
                string pattern8 = "//(.+?)(?:\\-end\\-|$)";
                string replacement = "_copyright_c_";

                ListAuthor(line);

                string multipleСomments = line;
                multipleСomments = multipleСomments.Replace("\r\n", "-end-");

                //MatchCollection matches = Regex.Matches(line, pattern4 + "|" + pattern8); // нужно удалить или игнорировать символы переноса строки
                MatchCollection matches = Regex.Matches(multipleСomments, pattern4 + "|" + pattern8);                

                foreach (Match match in matches)
                {
                    string str = match.Value;
                    str = str.Replace("-end-", "\r\n");

                    if (Regex.IsMatch(match.Value, pattern1 + "|" + pattern2 + "|" + pattern3 + "|" + pattern2_))
                    //if (Regex.IsMatch(match.Value, pattern2_))
                    {
                        string st = new Regex(pattern1 + "|" + pattern2 + "|" + pattern3 + "|" + pattern2_).Replace(str, replacement);
                        line2 = line2.Replace(match.Value, st);
                        //line2 = line2.Replace(match.Value, new Regex(pattern1 + "|" + pattern2 + "|" + pattern3 + "|" + pattern2_).Replace(str, replacement));
                        //line2 = line2.Replace(match.Value, new Regex(pattern2_).Replace(str, replacement));
                        matchesFound++;
                    }
                }

                if (matchesFound > 0)
                {
                    using (StreamWriter file = new StreamWriter(Path.Combine(finalPath, fileName)))
                    {
                        matchesFound = 0;
                        ListAuthorMatches(matches); 
                        file.Write(line2);
                    }
                }
                else
                {                    
                    CountNoMatchesFound();                    
                }
            }
        }

        public void ListAuthor(string line)
        {
            var copyrightHolderNames = from copyrightHolder in _data.GetAllCopyrightHolders() select copyrightHolder.Name;

            string pattern5 = @"(\S+)\s+(\S)\.\s*(\S)\."; // Фамилия И.О.
            string pattern6 = @"([A-Z][a-z]{1,14}\s[A-Z][a-z]{1,14}\s[A-Z][a-z]{1,14})|([А-Я][а-я]{1,14}\s[А-Я][а-я]{1,14}\s[А-Я][а-я]{1,14})"; // ФИО
            string pattern7 = @"([A-Z][a-z]{1,14}\s[A-Z][a-z]{1,14})|([А-Я][а-я]{1,14}\s[А-Я][а-я]{1,14})"; // Фамилия Имя

            MatchCollection copyrightHolderMatches = Regex.Matches(line, pattern5 + "|" + pattern6 + "|" + pattern7);           
            foreach (Match chm in copyrightHolderMatches)
            {                
                if (!copyrightHolderNames.Contains(chm.Value))
                {                    
                    SaveCopyrightHolder(chm.Value, 0);                    
                }
                else
                {
                    continue;
                }               
            }
        }

        public void ListAuthorMatches(MatchCollection matches)
        {
            var copyrightHolderNames = from copyrightHolder in _data.GetAllCopyrightHolders() select copyrightHolder.Name;           
            foreach (var lch in copyrightHolderNames)           
            {
                foreach (Match m in matches)
                {
                    if (Regex.IsMatch(m.Value, lch))
                    {
                        _data.CountNumberOfFiles_CopyrightHolder(lch);                        
                        break;
                    }
                }                
            }
        }

        public void Report()
        {

            int processedFiles = _data.ProcessedFiles;
            int noMatchesFound = _data.NoMatchesFound;
            var copyrightHolderNames = _data.GetAllCopyrightHolders();

            string table = @"{{\rtf1\ansi\deff0" +
                            @"\trowd\cellx4020\cellx5520\intbl\cell\intbl    Кол-во файлов:\cell\row" +
                            @"\trowd\cellx4020\cellx5520\intbl   Всего обработано:\cell\intbl                processedFiles\cell\row" +
                            @"\trowd\cellx4020\cellx5520\intbl   Сигнатуры не найдены:\cell\intbl                noMatchesFound\cell\row" +
                            @"\trowd\cellx5520\intbl\cell\row" +
                            @"\trowd\cellx4020\cellx5520\intbl   Список авторов:\cell\intbl\cell\row";                                                       

            string author = @"\trowd\cellx4020\cellx5520\intbl   Name\cell\intbl                NumberOfFiles\cell\row";

            StringBuilder str = new StringBuilder();
            str.Append(table);
            str.Replace("processedFiles", Convert.ToString(processedFiles));
            str.Replace("noMatchesFound", Convert.ToString(noMatchesFound));

            foreach (CopyrightHolder ch in copyrightHolderNames)
            {
                str.Append(author);
                str.Replace("Name", ch.Name);
                str.Replace("NumberOfFiles", Convert.ToString(ch.NumberOfFiles));               
            }

            str.Append("}}");

            _view.Order(str.ToString());                        
        }        
        
        public void SearchFiles()
        {
            string sourcePath = _data.SourcePath;

            try
            {                
                var Files = Directory.EnumerateFiles(sourcePath, "*.*", SearchOption.AllDirectories);

                foreach (string file in Files)
                {
                    if (file.Contains(".zip"))
                    {
                        ReaderAndFilterFilesInArchive(file);
                    }
                    else
                    {
                        FilterFiles(file);
                    }
                }

                Report();
                Reset();
                _view.Notification("Готово!");                
            }
            catch (Exception e)
            {                
                _view.Notification("The process failed: {0}", e.ToString());
            }
        }

    }
}
