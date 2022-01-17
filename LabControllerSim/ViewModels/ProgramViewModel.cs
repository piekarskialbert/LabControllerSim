using LabControllerSim.Core;
using LabControllerSim.Core.Events;
using LabControllerSim.Models;
using LabControllerSim.Core.Parameters;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LabControllerSim.ViewModels
{
    public class ProgramViewModel
    {
        IEventAggregator _ea;
        public DocumentModel Document { get; private set; }
        public FileViewModel File { get; set; }

        public DelegateCommand CompileCommand { get; private set; }
        public DelegateCommand CheckErrorsCommand { get; private set; }
        public ProgramViewModel(FileViewModel file, IEventAggregator ea)
        {
            File = file;
            _ea = ea;
            CompileCommand = new DelegateCommand(Compile);
            CheckErrorsCommand = new DelegateCommand(CheckErrors);
        }

        // Metoda sprawdzająca błędu programu użytownika przy pomocy modułu 'Compilation'
        public void CheckErrors()
        {

            if (!string.IsNullOrEmpty(File.Document.FileName))
            {
                File.SaveFile();
                // Przesłanie informacji o nazwie i ścieżce pliku utworzonego przez uzytkownika, którego kod kompilator ma sprawdzić
                _ea.GetEvent<CodeCheckErrorsEvent>().Publish(new CodeCompileEventParameters() { FileName = File.Document.FileName, FilePath = File.Document.FilePath });
            }
            else
            {
                // Okno z informacją o nie zapisanym pliku
                string messageBoxText = "Przed sprawdzeniem błędów zapisz plik.";
                string caption = "";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }

        // Metoda tworząca plik wykonywalny kodu użytkownika przy pomocy modułu 'Compilation'
        public void Compile()
        {
            if (!string.IsNullOrEmpty(File.Document.FileName)) 
            {
                File.SaveFile();
                // Przesłanie informacji o nazwie i ścieżce pliku utworzonego przez uzytkownika, z którego kompilator ma utworzyć plik wykonywalny
                _ea.GetEvent<CodeCompileEvent>().Publish(new CodeCompileEventParameters() { FileName = File.Document.FileName, FilePath = File.Document.FilePath });
            }
            else
            {
                // Okno z informacją o nie zapisanym pliku
                string messageBoxText = "Przed skompilowaniem zapisz plik.";
                string caption = "";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }

    }
}