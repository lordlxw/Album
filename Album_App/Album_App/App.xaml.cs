using Album_App.Modules.ModuleName;
using Album_App.Services.Instances;
using Album_App.Services.Interfaces.Interfaces;
using Album_App.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace Album_App
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
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            
            moduleCatalog.AddModule<ModuleNameModule>();
        }

      
    }
}
