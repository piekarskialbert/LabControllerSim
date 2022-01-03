using LabControllerSim.Modules.ObjectSimulator.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LabControllerSim.Modules.ObjectSimulator
{
    public class ObjectSimulatorModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ObjectSimulatorUserControl", typeof(ObjectSimulatorUserControl));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}