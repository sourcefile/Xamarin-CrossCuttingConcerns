using System;
using System.Collections.Generic;
using Autofac;
using C3Test.ViewModels;
using Xamarin.Forms;

namespace C3Test.Repositories.ViewResolverRepository
{
    public class FormsPageViewResolverRepository: IViewResolverRepository<Page>
    {
        private readonly Dictionary<Type, Type> _vmToViewMap = new Dictionary<Type, Type>();
        private Tuple<Type, Type> _startPage;

        public Page FindViewForViewModel(BaseViewModel vm)
        {
            var viewType = _vmToViewMap[vm.GetType()];
            var view = Activator.CreateInstance(viewType) as Page;

            view.BindingContext = vm;

            return view;
        }

        public void RegisterView<TViewModel, TView>(bool isStartPage = false)
        {
            if (isStartPage)
            {
                _startPage = new Tuple<Type, Type>(typeof(TViewModel), typeof(TView));
            }

            if (_vmToViewMap.ContainsKey(typeof(TViewModel)))
            {
                _vmToViewMap[typeof(TViewModel)] = typeof(TView);
            }
            else
            {
                _vmToViewMap.Add(typeof(TViewModel), typeof(TView));
            }
        }

        public Page InitializeLaunchView()
        {
            var view = Activator.CreateInstance(_startPage.Item2) as Page;
            using(var scope = App.Container.BeginLifetimeScope())
            {
                BaseViewModel vm = (BaseViewModel)scope.Resolve(_startPage.Item1);
                view.BindingContext = vm;
            }

            return view;
        }
    }
}
