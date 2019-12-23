using Prism.Navigation;

namespace BindingsTest.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Hello";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
        }
    }
}