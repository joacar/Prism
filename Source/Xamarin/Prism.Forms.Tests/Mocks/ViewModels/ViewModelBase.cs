using Prism.Mvvm;
using Prism.Navigation;

namespace Prism.Forms.Tests.Mocks.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        public NavigationParameters NavigatedToParameters { get; private set; }
        public NavigationParameters NavigatedFromParameters { get; private set; }

        public int OnNavigatedToCount { get; private set; }

        public int OnNavigatedFromCount { get; private set; }

        public bool OnNavigatedToCalled { get; private set; } = false;

        public bool OnNavigatedFromCalled { get; private set; } = false;

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            OnNavigatedFromCalled = true;
            OnNavigatedFromCount++;
            NavigatedFromParameters = parameters;
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            OnNavigatedToCalled = true;
            OnNavigatedToCount++;
            NavigatedToParameters = parameters;
        }
    }
}
