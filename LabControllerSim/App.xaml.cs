using LabControllerSim.Modules.BoardSimulator;
using LabControllerSim.Modules.Compilation;
using LabControllerSim.Modules.ConsoleSimulator;
using LabControllerSim.Modules.ObjectModels;
using LabControllerSim.Modules.ObjectSimulator;
using LabControllerSim.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace LabControllerSim
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CompilationModule>();
            moduleCatalog.AddModule<BoardSimulatorModule>();
            moduleCatalog.AddModule<ConsoleSimulatorModule>();
            moduleCatalog.AddModule<ObjectModelsModule>();
            moduleCatalog.AddModule<ObjectSimulatorModule>();
        }
    }
}
