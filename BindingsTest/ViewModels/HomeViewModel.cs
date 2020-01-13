using System;
using BindingsTest.Interfaces;
using Prism.Commands;
using Prism.Navigation;

namespace BindingsTest.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public DelegateCommand BtnPrsd { get; private set; }

        private ISdkTest sdk;

        public HomeViewModel(INavigationService navigationService, ISdkTest sdk) : base(navigationService)
        {
            Title = "Hello";
            BtnPrsd = new DelegateCommand(Pressed);
            this.sdk = sdk;
        }

        private void Pressed()
        {
            sdk.Speak("Testing");
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
        }
    }
}