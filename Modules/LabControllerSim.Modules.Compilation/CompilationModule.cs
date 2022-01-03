using LabControllerSim.Modules.Compilation.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LabControllerSim.Modules.Compilation
{
    public class CompilationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ErrorListRegion", typeof(ErrorList));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}