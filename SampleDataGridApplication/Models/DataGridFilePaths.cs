using SampleDataGridApplication.ViewModels;

namespace SampleDataGridApplication.Models
{
    public class DataGridFilePaths : ViewModelBase
    {
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                OnPropertyChanged();
            }
        }

        private bool canEdit;

        public bool CanEdit
        {
            get => canEdit;
            set
            {
                canEdit = value;
                OnPropertyChanged();
            }
        }
    }
}