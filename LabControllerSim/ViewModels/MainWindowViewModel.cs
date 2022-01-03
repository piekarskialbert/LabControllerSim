using Prism.Mvvm;
using Prism.Events;
using Prism.Commands;
using LabControllerSim.Core;
using LabControllerSim.Models;
using System.Windows.Input;
using System.IO;
using System.Windows;
using ICSharpCode.AvalonEdit.Document;
using System;

namespace LabControllerSim.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Symulator sterownika laboratoryjnego";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }

        }
        public DelegateCommand<KeyEventArgs> KeyUpCommand { get; private set; }
        public ICommand CloseWindowCommand { get; }
        private DocumentModel _document;
        public FileViewModel File { get; set; }
        public HelpViewModel Help { get; set; }
        public SimulatorViewModel Simulator { get; set; }
        public ProgramViewModel Program { get; set; }

        

        public MainWindowViewModel(IEventAggregator ea)
        {
            KeyUpCommand = new DelegateCommand<KeyEventArgs>(KeyUp);
            CloseWindowCommand = new RelayCommand(WindowClose);
            _document = new DocumentModel();
            Help = new HelpViewModel();
            File = new FileViewModel(_document);
            Program = new ProgramViewModel(File, ea);
            Simulator = new SimulatorViewModel(ea);
            string path = Directory.GetCurrentDirectory();
        }

        private void WindowClose()
        {
           // throw new NotImplementedException();
        }

        private void KeyUp(KeyEventArgs e)
        {
            if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (!File.Document.isEmpty) File.SaveFile();
                else File.SaveFileAs();
            }

            if (e.Key == Key.N && Keyboard.Modifiers == ModifierKeys.Control)
            {
                File.NewFile();
            }
            if (e.Key == Key.O && Keyboard.Modifiers == ModifierKeys.Control)
            {
                File.OpenFile();
            }
            if (e.Key == Key.F5)
            {
                Program.Compile();
            }

        }

    }
}
