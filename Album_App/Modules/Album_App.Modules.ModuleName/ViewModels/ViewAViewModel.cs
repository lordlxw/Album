﻿using Album_App.Core.Mvvm;
using Album_App.Services.Interfaces.Interfaces;
using Prism.Regions;
using System.Windows;

namespace Album_App.Modules.ModuleName.ViewModels
{
    public class ViewAViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            Message = messageService.GetMessage();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            MessageBox.Show("1");
        }

    
    }
}
