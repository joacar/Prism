using Prism.Navigation;

namespace Prism.Forms.Tests.Mocks.ViewModels
{
    public class TabbedPageMockViewModel : ViewModelBase
    {
        public int OnNavigatedToCount { get; private set; }

        public int OnNavigatedFromCount { get; private set; }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
            OnNavigatedFromCount++;
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            OnNavigatedToCount++;
        }
    }
}
