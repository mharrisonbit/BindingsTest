using BindingsTest.Interfaces;
using Prism.Commands;
using Prism.Navigation;

namespace BindingsTest.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public DelegateCommand BtnPrsd { get; private set; }

        private ISdkTest Sdk { get; }

        public HomeViewModel(INavigationService navigationService, ISdkTest sdk) : base(navigationService)
        {
            Title = "Hello";
            BtnPrsd = new DelegateCommand(Pressed);
            Sdk = sdk;
        }

        private void Pressed()
        {
            Sdk.Speak("Testing");
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
        }
    }
}