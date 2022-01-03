using LabControllerSim.Modules.BoardSimulator.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LabControllerSim.Modules.BoardSimulator
{
    public class BoardSimulatorModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("BoardSimulatorUserControl", typeof(BoardSimulatorUserControl));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}