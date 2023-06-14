using SampleDataGridApplication.Command;
using SampleDataGridApplication.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SampleDataGridApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly string SourceFileLocation;
        private ObservableCollection<DataGridFilePaths> dataGridFilePaths;

        public ObservableCollection<DataGridFilePaths> DataGridFilePaths
        {
            get
            {
                return dataGridFilePaths;
            }
            set
            {
                dataGridFilePaths = value;
                OnPropertyChanged(nameof(DataGridFilePaths));
            }
        }

        private DataGridFilePaths filePath;

        public DataGridFilePaths FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }

        private ICommand editButtonClickCommand;

        public ICommand EditButtonClickCommand
            => editButtonClickCommand ?? new RelayCommand(param => EditCell(param), param => CanEditCell(param));

        private ICommand deleteButtonClickCommand;

        public ICommand DeleteButtonClickCommand
            => deleteButtonClickCommand ?? new RelayCommand(param => DeleteCurrentRow(param), param => CanDeleteRow(param));

        private ICommand lostFocusCommand;

        public ICommand LostFocusCommand
            => lostFocusCommand ?? new RelayCommand(param => LostFocus(param));

        private ICommand saveButtonClickCommand;

        public ICommand SaveButtonClickCommand
        {
            get
            {
                if (saveButtonClickCommand == null)
                {
                    saveButtonClickCommand = new RelayCommand(x=>Save());
                }
                return saveButtonClickCommand;
            }
        }

 

        public MainViewModel()
        {
            SourceFileLocation = @"D:\Code\SampleDataGridApp\FilePaths.ini";
            DataGridFilePaths = new ObservableCollection<DataGridFilePaths>();
            CreateLayout();
        }

        private void CreateLayout()
        {
            var paths = File.ReadLines(SourceFileLocation);

            foreach (var path in paths)
            {
                DataGridFilePaths.Add(new DataGridFilePaths { FilePath = path, CanEdit = false });
            }
        }

        #region Command Implementation

        private bool CanEditCell(object param)
        {
            return true;
        }

        private void EditCell(object param)
        {
            if(param is DataGridFilePaths path)
            {
                path.CanEdit = true;
            }
        }

        private void DeleteCurrentRow(object param)
        {
            if (param is DataGridFilePaths path)
            {
                DataGridFilePaths.Remove(path);
            }
        }

        private bool CanDeleteRow(object param)
        {
            return true;
        }

        private void LostFocus(object param)
        {
            FilePath.CanEdit = false;
        }
        private void Save()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var item in DataGridFilePaths)
            {
                sb.AppendLine(item.FilePath);
            }
            File.WriteAllText(SourceFileLocation, sb.ToString());
            MessageBox.Show("File Saved to Source location","File Save",MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion Command Implementation
    }
}