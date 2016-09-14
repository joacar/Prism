using Prism.Mvvm;
using Xamarin.Forms;

namespace Prism.Forms.Tests.Mocks.Views
{
    public class ContentModalPageMock : ContentPage
    {
        public ContentModalPageMock()
        {
            ViewModelLocator.SetAutowireViewModel(this, true);
        }
    }
}
