using Album_App.Core;
using Album_App.Modules.ModuleName.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows.Documents;

namespace Album_App.Modules.ModuleName
{
    public class ModuleNameModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleNameModule(IRegionManager regionManager)
        {
            
            _regionManager = regionManager;
            
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(PhotoView));
           // _regionManager.RequestNavigate(RegionNames.ContentRegion, "PicFormatterView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PhotoView>();
            containerRegistry.RegisterForNavigation<PicFormatterView>();
        }
    }
}