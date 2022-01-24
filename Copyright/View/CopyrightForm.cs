using System;
using System.Windows.Forms;

namespace Copyright.View
{
    internal partial class CopyrightForm : Form, ICopyrightView
    {
        private bool _fileTypeSelected = false;
        private bool _sourcePathSelected = false;
        private bool _finalPathSelected = false;        
        private bool fileTypeAll = true;
        private readonly string fileTypeTxt = ".txt";
        private readonly string fileTypeC = ".c";
        private readonly string fileTypeCpp = ".cpp";
      
        public CopyrightForm()
        {
            InitializeComponent();
        }        

        private void SourcePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _sourcePathSelected = !_sourcePathSelected;
                Presenter.SourcePathSet(folderBrowserDialog1.SelectedPath);
            }                
        }

        private void FinalPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _finalPathSelected = !_finalPathSelected;
                Presenter.FinalPathSet(folderBrowserDialog1.SelectedPath);
            }
        }

        private void Txt_Click(object sender, EventArgs e)
        {
            _fileTypeSelected = !_fileTypeSelected;            
            Presenter.FileTypeTxtSet(fileTypeTxt);
        }

        private void C_cpp_Click(object sender, EventArgs e)
        {
            _fileTypeSelected = !_fileTypeSelected;            
            Presenter.FileTypeC_CppSet(fileTypeC, fileTypeCpp);
        }

        private void AllFile_Click(object sender, EventArgs e)
        {
            _fileTypeSelected = !_fileTypeSelected;            
            Presenter.FileTypeAllSet(fileTypeAll);
        }

        private void Processed_Click(object sender, EventArgs e)
        {            


            if (_sourcePathSelected && _finalPathSelected && _fileTypeSelected)
            {                
                _sourcePathSelected = !_sourcePathSelected;
                _finalPathSelected = !_finalPathSelected;
                _fileTypeSelected = !_fileTypeSelected;
                Presenter.SearchFiles();                
            }
            else if (!_sourcePathSelected)
            {
                MessageBox.Show("Укажите начальную директорию!");
            }
            else if (!_finalPathSelected)
            {
                MessageBox.Show("Укажите конечную директорию!");
            }
            else if (!_fileTypeSelected)
            {
                MessageBox.Show("Укажите тип файла!");
            }
        }        

        public void Notification(string message)
        {
            MessageBox.Show(message);
        }

        public void Notification(string message1, string message2)
        {
            MessageBox.Show(message1, message2);
        }

        public void Order(string order)
        {
            int index = richTextBox1.Rtf.LastIndexOf("}");
            richTextBox1.Rtf = richTextBox1.Rtf.Substring(0, index) + order;            
        }

        public Presenter.CopyrightPresenter Presenter
        { private get; set; }
    }
}
