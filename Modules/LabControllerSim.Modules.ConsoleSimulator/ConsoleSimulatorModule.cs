using LabControllerSim.Modules.ConsoleSimulator.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LabControllerSim.Modules.ConsoleSimulator
{
    public class ConsoleSimulatorModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ConsoleSimulatorUserControl", typeof(ConsoleSimulatorUserControl));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}