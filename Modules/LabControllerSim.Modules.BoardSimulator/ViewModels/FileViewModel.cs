using LabControllerSim.Core;
using LabControllerSim.Modules.BoardSimulator.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LabControllerSim.Modules.BoardSimulator.ViewModels
{
    public class FileViewModel : ObservableObject
    {
        private string _info ="";
        public string Info { get { return _info; } set { OnPropertyChange(ref _info, value); } }
        public string Path { get; private set; }
        public string Name { get; private set; }
        public ICommand SelectProgramFileCommand { get; }
        public ControlButton SelectButton { get; set; }

        public FileViewModel()
        {
            SelectButton = new ControlButton() { IsEnabled = true };
            SelectProgramFileCommand = new RelayCommand(SelectFile, () => SelectButton.IsEnabled);
        }

        private void SelectFile()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "exe file (*.exe)|*.exe";
            if (openFileDialog.ShowDialog() == true)
                {
                    Path = openFileDialog.FileName;
                    Info = $"Aktualnie wybrany program:\n{Path}";
                }
        }


    }
}
