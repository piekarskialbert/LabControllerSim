using LabControllerSim.Modules.ObjectModels.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LabControllerSim.Modules.ObjectModels
{
    public class ObjectModelsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("SingleReservoir", typeof(SingleReservoir));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}