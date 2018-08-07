using System;
using System.Linq;
using System.Threading.Tasks;
using C3Test.Repositories.ViewResolverRepository;
using C3Test.ViewModels;
using Xamarin.Forms;

namespace C3Test.Services.NavigationService
{
    public class NavigationService : INavigationService<Page>
    {
        private readonly IViewResolverRepository<Page> _viewResolverRepository;

        public NavigationService(IViewResolverRepository<Page> viewResolverRepository)
        {
            _viewResolverRepository = viewResolverRepository;
        }

        public Page CurrentModalView
        {
            get { return CurrentView.Navigation.ModalStack.Count > 0 ? CurrentView.Navigation.ModalStack.LastOrDefault() : null; }
        }

        public Page CurrentView
        {
            get { return Application.Current.MainPage; }
        }

        public Task PushPageModal(BaseViewModel vm, bool animate = true, bool hasNavigationBar = true)
        {
            var page = _viewResolverRepository.FindViewForViewModel(vm);
            if (hasNavigationBar)
            {
                return CurrentView.Navigation.PushModalAsync(new NavigationPage(page), animate);
            }

            return CurrentView.Navigation.PushModalAsync(page, animate);
        }

        public async Task PopCurrentPageModal(bool animate = true)
        {
            if (CurrentModalView != null)
                await CurrentModalView.Navigation.PopModalAsync(animate);
        }
    }
}
