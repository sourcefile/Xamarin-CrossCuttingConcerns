using System;
using System.Threading.Tasks;
using C3Test.ViewModels;

namespace C3Test.Services.NavigationService
{
    public interface INavigationService<TBaseView>
    {
        /// <summary>
        /// Gets the current modal view.
        /// </summary>
        /// <value>The current modal view.</value>
        TBaseView CurrentModalView { get; }

        /// <summary>
        /// Gets the current view.
        /// </summary>
        /// <value>The current view.</value>
        TBaseView CurrentView { get; }

        /// <summary>
        /// Pops the current page modal.
        /// </summary>
        /// <returns>The current page modal.</returns>
        /// <param name="animate">If set to <c>true</c> animate.</param>
        Task PopCurrentPageModal(bool animate = true);

        /// <summary>
        /// Pushs the page modal.
        /// </summary>
        /// <returns>The page modal.</returns>
        /// <param name="vm">Vm.</param>
        /// <param name="animate">If set to <c>true</c> animate.</param>
        /// <param name="hasNavigationBar">If set to <c>true</c> has navigation bar.</param>
        Task PushPageModal(BaseViewModel vm, bool animate = true, bool hasNavigationBar = true);
    }
}
