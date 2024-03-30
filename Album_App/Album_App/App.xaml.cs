using Album_App.Modules.ModuleName;
using Album_App.Services.Instances;
using Album_App.Services.Interfaces.Interfaces;
using Album_App.ViewModels;
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
            // 注册 ICaptureVideoImage 接口的实现类 CaptureVideoImage
            containerRegistry.Register<ICaptureVideoImage, CaptureVideoImage>();

            // 注册 MainWindowViewModel 类
           // containerRegistry.Register<MainWindowViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            
            moduleCatalog.AddModule<ModuleNameModule>();
        }

      
    }
}
