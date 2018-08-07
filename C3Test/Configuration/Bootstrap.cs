using System;
using Autofac;
using Autofac.Features.ResolveAnything;
using C3Test.Repositories.TeamlidRepository;
using C3Test.Repositories.ViewResolverRepository;
using C3Test.Services.NavigationService;
using C3Test.Services.TeamService;
using C3Test.ViewModels;
using C3Test.Views;
using Xamarin.Forms;

namespace C3Test.Configuration
{
    public static class Bootstrap
    {
        private static IViewResolverRepository<Page> _viewResolver;
        public static IContainer Configure()
        {
            _viewResolver = new FormsPageViewResolverRepository();

            var builder = new ContainerBuilder();

            //Register Services
            builder.RegisterType<NavigationService>().As<INavigationService<Page>>();
            builder.RegisterType<TeamService>().Named<ITeamService>("teamservice");


            //Register Repositories
            builder.RegisterInstance(_viewResolver);
            builder.RegisterType<MockTeamMemberRepository>().As<ITeamMemberRepository>().SingleInstance();

            //Register View / ViewModel relations
            _viewResolver.RegisterView<TeamOverviewViewModel, TeamOverviewPage>(true);
            _viewResolver.RegisterView<AddTeamMemberViewModel, AddTeamMemberPage>();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            //Register Decorators
            builder.RegisterDecorator<ITeamService>((c, inner) => new TeamServiceLoggingDecorator(inner), "teamservice");
            builder.RegisterDecorator<ITeamService>((c, inner) => new TeamServiceValidationDecorator(inner), "teamservice");

            return builder.Build();
        }

        public static Page GetFirstScreen()
        {
            return _viewResolver.InitializeLaunchView();
        }
    }
}
