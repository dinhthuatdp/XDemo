using Prism.Commands;
using Prism.Navigation;
using Prism.Mvvm;
using XDemo.UI.Extensions;
using XDemo.UI.ViewModels.Base;

namespace XDemo.UI.ViewModels
{
    public class DetailAPageViewModel : ViewModelBase
    {
        public DelegateCommand btnBack { get; set; }

        public DetailAPageViewModel(INavigationService navigationService)
        {
            Title = "Page A";
            btnBack = new DelegateCommand(() => {
                navigationService.PopAsync();
            });
        }
    }
}
