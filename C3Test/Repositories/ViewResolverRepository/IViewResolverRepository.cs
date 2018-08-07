using System;
using C3Test.ViewModels;

namespace C3Test.Repositories.ViewResolverRepository
{
    /// <summary>
    /// View resolver service.
    /// Handles the relationships between Views and ViewModels
    /// </summary>
    public interface IViewResolverRepository<TBaseView>
    {
        /// <summary>
        /// Finds the view for view model.
        /// </summary>
        /// <returns>The view for view model.</returns>
        /// <param name="vm">Vm.</param>
        TBaseView FindViewForViewModel(BaseViewModel vm);

        /// <summary>
        /// Registers the view.
        /// </summary>
        /// <param name="isStartView">If set to <c>true</c> is start view.</param>
        /// <typeparam name="TViewModel">Type of the ViewModel to regsiter.</typeparam>
        /// <typeparam name="TView">Type of the View to register.</typeparam>
        void RegisterView<TViewModel, TView>(bool isStartView = false);

        /// <summary>
        /// Initializes the launch view.
        /// </summary>
        /// <returns>The launch view.</returns>
        TBaseView InitializeLaunchView();
    }
}
